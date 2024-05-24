using AutoMapper;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MedicalRecord_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using MedicalRecord_API.Utils.Recursos.Interfaces;

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

        public UsuarioController(IMapper mapper, IUsuarioRepository usuarioRepo,  IUtilsService utilsService, ILogger<UsuarioController> logger)
        {
            _logger = logger;
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
            _utilsService = utilsService;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuarios()
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a GETUSUARIOS", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            try
            {
                IEnumerable<UsuarioDto> usuarioList = _mapper.Map<IEnumerable<UsuarioDto>>(await _usuarioRepo.QueryAsync());
                _response.Resultado = usuarioList;
                _response.IsExitoso = true;
                _response.Status = HttpStatusCode.OK; 
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Respuesta exitosa de GETUSUARIO", StatusCodes.Status200OK, HttpStatusCode.OK);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes =[ ex.ToString() ];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de GETUSUARIOS", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("{Id:int}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuario(int Id)
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a GETUSUARIO", StatusCodes.Status102Processing, HttpStatusCode.Processing);           
                if (Id <1)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMensajes=["id: argumento no puede ser 0"];
                   _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento no puede ser 0", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    return BadRequest(_response);
                }
            try
            {
                UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(await _usuarioRepo.GetEntity(u =>u.Id == Id, false));
                if (usuarioDto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: no esxiste en la base de datos", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = usuarioDto;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Respuesta exitosa de GETUSUARIO", StatusCodes.Status200OK, HttpStatusCode.OK);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de GETUSUARIO", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Response>> Login([FromBody] LoginRequestDto modelo)
        {
            modelo.Password=await _utilsService.ConvertirSha256Async(modelo.Password);

            LoginResponseDto loginResponseDto = await _usuarioRepo.Login(modelo);
            if(loginResponseDto == null|| loginResponseDto.Token == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["username o password es incorrecto"];
                return BadRequest(_response);
            }
            _response.Status= HttpStatusCode.OK;
            _response.IsExitoso = true;
            _response.Resultado=loginResponseDto;
            return Ok(_response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] UsuarioRegistroDto dto)
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud CREATE", StatusCodes.Status102Processing, HttpStatusCode.Processing);
            if (dto == null) 
            {
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                _response.Status = HttpStatusCode.BadRequest;
                _logger.LogError("{StatusCode}[{HttpStatusCode}] : modelo: modelo no puede ser null", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            };
            if (!ModelState.IsValid)
            {
                _logger.LogError("{StatusCode}[{HttpStatusCode}] {ModelState}", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest, ModelState.ToString());
                return BadRequest(ModelState);
            };
            try
            {
                bool unique = await _usuarioRepo.IsUserUnique(dto.Correo);
                if (!unique)
                {
                    _response.Status=HttpStatusCode.BadRequest; 
                    _response.ErrorMensajes = ["El Usuario con este Correo ya existe"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}] El Usuario con este Correo ya existe", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    return BadRequest(_response);
                }

                Usuario modelo = _mapper.Map<Usuario>(dto);
                modelo.Clave= await _utilsService.ConvertirSha256Async(dto.Clave);
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
                _logger.LogWarning("{StatusCode}[{HttpStatusCode}]: Respuesta existosa de CREATE", StatusCodes.Status201Created, HttpStatusCode.Created);
                return CreatedAtRoute("GetUsuario", new { id = modelo.Id }, _response);
            catch (Exception ex)
            }
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            catch
            {
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de CREATE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);

                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de CREATE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }  
           
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a UPDATE", StatusCodes.Status102Processing, HttpStatusCode.Processing);

        public async Task<IActionResult> Update(int id,[FromBody] UsuarioUpdateDto dto)
        {
            if (id < 1)
                {
                   _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento no puede ser 0", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMensajes= ["id: argumento no puede ser 0"];
                   return BadRequest(_response);
                }
                if (dto == null)
                {
                   _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: argumento no puede ser null", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    _response.Status = HttpStatusCode.BadRequest;
                   _response.ErrorMensajes = ["modelo: no puede ser null"];
                   return BadRequest(_response);
                }
              if (dto.Id!=id)
                 {
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento id & modelo.id no pueden ser diferenes", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento id & modelo.id no pueden ser diferenes"];
                return BadRequest(_response);
                }
                _logger.LogError("{StatusCode}[{HttpStatusCode}] {ModelState}", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest, ModelState.ToString());
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            };
            try
            {
                if (await _usuarioRepo.GetEntity(u => u.Id == id,false) == null) {
                    _logger.LogWarning("{StatusCode}[{HttpStatusCode}]: modelo: no esxiste en la base de datos", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["modelo: no esxiste en la base de datos"];
                    return BadRequest(_response);
                }
                if(await _usuarioRepo.GetEntity(u=> string.Equals(u.Correo,dto.Correo),false)!=null)
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]El Usuario con este Correo ya existe", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                {
                    _response.ErrorMensajes = ["El Usuario con este Correo ya existe"];
                    return BadRequest(_response);
                _logger.LogWarning("{StatusCode}[{HttpStatusCode}]: Respuesta de UPDATE ha sido exitosa", StatusCodes.Status204NoContent, HttpStatusCode.NoContent);
                }
                await _usuarioRepo.Update(_mapper.Map<Usuario>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
            catch (Exception ex)
            }
            catch
                _response.ErrorMensajes = [ex.ToString()];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error al intentar UPDATE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                _response.Status= HttpStatusCode.InternalServerError;
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

                Usuario usuario = await _usuarioRepo.GetEntity(v => v.Id == id, false);
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
                Usuario usuario = await _usuarioRepo.GetEntity(u => u.Id == id, false);
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

                Usuario usuario = await _usuarioRepo.GetEntity(u => u.Id ==id);
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
