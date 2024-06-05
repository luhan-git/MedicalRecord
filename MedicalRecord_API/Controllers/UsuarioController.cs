using AutoMapper;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MedicalRecord_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using MedicalRecord_API.Services.Interfaces;

namespace MedicalRecord_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;
        private readonly IUtilsService _utilsService;
        protected Response _response;

        public UsuarioController(IMapper mapper, IUsuarioService service, IUtilsService utilsService)
        {
            _service=service;
            _mapper = mapper;
            _utilsService = utilsService;
            _response = new();
        }
        [HttpGet]
        // [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Get()
        {
            try
            {
                IEnumerable<UsuarioDto> usuarios = _mapper.Map<IEnumerable<UsuarioDto>>(await _service.QueryAsync());
                _response.Result = usuarios;
                _response.IsSuccess = true;
                _response.Status = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("{Id:int}", Name = "GetUsuario")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuario(int Id)
        {
            if (Id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            try
            {
                UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(await _service.GetAsync(u => u.Id == Id, false));
                if (usuarioDto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = usuarioDto;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("Perfil/{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>>Perfil(int Id){
             if (Id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            try{
                PerfilDto perfil=_mapper.Map<PerfilDto>(await _service.GetAsync(u=> u.Id==Id));
                if (perfil == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                 _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = perfil;
                return Ok(_response);
            }catch{
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
            
        }
        [HttpPost("Login")]
        public async Task<ActionResult<Response>> Login([FromBody] LoginRequestDto modelo)
        {
            modelo.Password = await _utilsService.ConvertirSha256(modelo.Password);

            LoginResponseDto loginResponseDto = await _service.Login(modelo);
            if (loginResponseDto.Usuario == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["username o password es incorrecto"];
                return BadRequest(_response);
            }
            
            _response.IsSuccess = true;
            _response.Result = loginResponseDto;
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
                _response.ErrorMessages = ["modelo: no puede ser null"];
                _response.Status = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            };
            try
            {
                bool unique = await _service.IsUserUnique(dto.Correo);
                if (!unique)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["El Usuario con este Correo ya existe"];
                    return BadRequest(_response);
                }

                Usuario modelo = _mapper.Map<Usuario>(dto);
                modelo.Clave = await _utilsService.ConvertirSha256(dto.Clave);
                modelo = await _service.Create(modelo);
                if (modelo == null)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Error al registrar Usuario"];
                    return BadRequest(_response);
                }
                _response.Result = _mapper.Map<UsuarioDto>(modelo);
                _response.Status = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetUsuario", new { id = modelo.Id }, _response);

            }
            catch(Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages=["Error al registrar usuario",ex.ToString()];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpPut("{id:int}")]
        // [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateDto dto)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            if (dto == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["modelo: no puede ser null"];
                return BadRequest(_response);
            }
            if (dto.Id != id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["id: argumento id & modelo.id no pueden ser diferenes"];
                return BadRequest(_response);
            }
            try
            {
                if (await _service.GetAsync(u => u.Id == id, false) == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["modelo: no esxiste en la base de datos"];
                    return BadRequest(_response);
                }
                await _service.Update(_mapper.Map<Usuario>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud.",ex.ToString()];
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
                _response.ErrorMessages = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            if (patch == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["modelo: no puede ser null"];
                return BadRequest(_response);
            }
            try
            {

                Usuario usuario = await _service.GetAsync(v => v.Id == id, false);
                if (usuario == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }

                UsuarioUpdateDto dto = _mapper.Map<UsuarioUpdateDto>(usuario);
                patch.ApplyTo(dto, ModelState);

                await _service.Update(_mapper.Map<Usuario>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
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
                _response.ErrorMessages = ["id: argumento no puede ser 0"];
                BadRequest(_response);
            };
            try
            {
                Usuario usuario = await _service.GetAsync(u => u.Id == id, false);
                if (usuario == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                await _service.Delete(usuario);
                _response.Status = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
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
                _response.ErrorMessages = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            if (dto == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["modelo: no puede ser null"];
                return BadRequest(_response);
            }
            if (dto.Id != id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["id: argumento id & modelo.id no pueden ser diferenes"];
                return BadRequest(_response);
            }
            try
            {

                Usuario usuario = await _service.GetAsync(u => u.Id == id);
                if (usuario == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = [" usuario no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                if (usuario.Clave != await _utilsService.ConvertirSha256(dto.CurrentPassword))
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Contraseña ingresada no coincide con la contraseña actual"];
                    BadRequest(_response);
                }

                usuario.Clave = await _utilsService.ConvertirSha256(dto.NewPassword);
                await _service.Update(usuario);
                _response.Status = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);

            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

    }

}
