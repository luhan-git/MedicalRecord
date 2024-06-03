using AutoMapper;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MedicalRecord_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using MedicalRecord_API.Utils.Recursos.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MedicalRecord_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IMapper _mapper;
        private readonly IUtilsService _utilsService;
        private readonly ILogger<UsuarioController> _logger;
        protected Response _response;

        public UsuarioController(IMapper mapper, IUsuarioRepository usuarioRepo, IUtilsService utilsService, ILogger<UsuarioController> logger)
        {
            _logger = logger;
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
            _utilsService = utilsService;
            _response = new();
        }
        [HttpGet]
        // [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuarios()
        {
            try
            {
                IEnumerable<UsuarioDto> usuarioList = _mapper.Map<IEnumerable<UsuarioDto>>(await _usuarioRepo.QueryAsync());
                _response.Resultado = usuarioList;
                _response.IsExitoso = true;
                _response.Status = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("{Id:int}", Name = "GetUsuario")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuario(int Id)
        {
            if (Id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            try
            {
                UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(await _usuarioRepo.GetAsync(u => u.Id == Id, false));
                if (usuarioDto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = usuarioDto;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Response>> Login([FromBody] LoginRequestDto modelo)
        {
            modelo.Password = await _utilsService.ConvertirSha256Async(modelo.Password);

            LoginResponseDto loginResponseDto = await _usuarioRepo.Login(modelo);
            if (loginResponseDto == null || loginResponseDto.Token == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["username o password es incorrecto"];
                return BadRequest(_response);
            }
            _response.Status = HttpStatusCode.OK;
            _response.IsExitoso = true;
            _response.Resultado = loginResponseDto;
            return Ok(_response);
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] UsuarioRegistroDto dto)
        {
            if (dto == null)
            {
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                _response.Status = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            try
            {
                bool unique = await _usuarioRepo.IsUserUnique(dto.Correo);
                if (!unique)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMensajes = ["El Usuario con este Correo ya existe"];
                    return BadRequest(_response);
                }

                Usuario modelo = _mapper.Map<Usuario>(dto);
                modelo.Clave = await _utilsService.ConvertirSha256Async(dto.Clave);
                modelo = await _usuarioRepo.Create(modelo);
                if (modelo == null)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMensajes = ["Error al registrar Usuario"];
                    return BadRequest(_response);
                }
                _response.Resultado = _mapper.Map<UsuarioDto>(modelo);
                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                return Ok(_response);

            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateDto dto)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            if (dto == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                return BadRequest(_response);
            }
            if (dto.Id != id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento id & modelo.id no pueden ser diferenes"];
                return BadRequest(_response);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            try
            {
                if (await _usuarioRepo.GetAsync(u => u.Id == id, false) == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["modelo: no esxiste en la base de datos"];
                    return BadRequest(_response);
                }
                if (await _usuarioRepo.GetAsync(u => string.Equals(u.Correo, dto.Correo), false) != null)
                {
                    _response.ErrorMensajes = ["El Usuario con este Correo ya existe"];
                    return BadRequest(_response);
                }
                await _usuarioRepo.Update(_mapper.Map<Usuario>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PartialUpdate(int id, [FromBody] JsonPatchDocument<UsuarioUpdateDto> patch)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            if (patch == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                return BadRequest(_response);
            }
            try
            {

                Usuario usuario = await _usuarioRepo.GetAsync(v => v.Id == id, false);
                if (usuario == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }

                UsuarioUpdateDto dto = _mapper.Map<UsuarioUpdateDto>(usuario);
                patch.ApplyTo(dto, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };

                await _usuarioRepo.Update(_mapper.Map<Usuario>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                BadRequest(_response);
            };
            try
            {
                Usuario usuario = await _usuarioRepo.GetAsync(u => u.Id == id, false);
                if (usuario == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                await _usuarioRepo.Delete(usuario);
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }
        [HttpPut("ChangePassword/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordDto dto)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            if (dto == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                return BadRequest(_response);
            }
            if (dto.Id != id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento id & modelo.id no pueden ser diferenes"];
                return BadRequest(_response);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            try
            {

                Usuario usuario = await _usuarioRepo.GetAsync(u => u.Id == id);
                if (usuario == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" usuario no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                if (usuario.Clave != await _utilsService.ConvertirSha256Async(dto.CurrentPassword))
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMensajes = ["Contraseña ingresasa no coincide con la contraseña actual"];
                    BadRequest(_response);
                }

                usuario.Clave = await _utilsService.ConvertirSha256Async(dto.NewPassword);
                await _usuarioRepo.Update(usuario);
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                return Ok(_response);

            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
