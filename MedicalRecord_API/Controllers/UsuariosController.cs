using AutoMapper;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MedicalRecord_API.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuariosController> _logger;
        protected Response _response;

        public UsuariosController(IMapper mapper, IUsuarioRepository usuarioRepo, ILogger<UsuariosController> logger)
        {
            _logger = logger;
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
            _response = new Response();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuarios()
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Handling GETUSUARIOS request", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            try
            {
                IEnumerable<UsuarioDto> usuarioList = _mapper.Map<IEnumerable<UsuarioDto>>(await _usuarioRepo.Query());
                _response.Resultado = usuarioList;
                _response.Status = HttpStatusCode.OK;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Request handled successfully", StatusCodes.Status200OK, HttpStatusCode.OK);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes =[ ex.ToString() ];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling GETUSUARIOS request", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("Id:int", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuario(int Id)
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Handling GETUSUARIO request", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            try
            {
                if (Id == 0)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling GETUSUARIO request", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    return BadRequest(_response);
                }
                UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(await _usuarioRepo.GetEntity(u =>u.Id == Id, false));
                if (usuarioDto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling GETUSUARIO request", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.Resultado = usuarioDto;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Request handled successfully", StatusCodes.Status200OK, HttpStatusCode.OK);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling GETUSUARIOS request", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] UsuarioCreateDto dto)
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Handling CREATE request", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (dto == null) return BadRequest(dto);
                if (await _usuarioRepo.GetEntity(u => u.Correo.ToUpper() == dto.Correo.ToUpper(), false) != null)
                {
                    ModelState.AddModelError("correoExiste", "El Usuario con este Correo ya existe");
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling CREATE request", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    return BadRequest(ModelState);
                }

                Usuario modelo = _mapper.Map<Usuario>(dto);
                modelo = await _usuarioRepo.Create(modelo);
                _response.Resultado = _mapper.Map<UsuarioDto>(modelo);
                _response.Status = HttpStatusCode.Created;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Request handled successfully", StatusCodes.Status201Created, HttpStatusCode.Created);
                return CreatedAtRoute("GetUsuario", new { id = modelo.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling CREATE request", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }  
           
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id,[FromBody] UsuarioUpdateDto dto)
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a UPDATE", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMensajes= ["id: argumento no puede ser 0"];
                   _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento no puede ser 0", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                   return BadRequest(_response);
                }
                if (dto == null)
                {
                    _response.IsExitoso = false;
                    _response.Status = HttpStatusCode.BadRequest;
                   _response.ErrorMensajes = ["modelo: argumento no puede ser null"];
                   _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: argumento no puede ser null", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                   return BadRequest(_response);
                }
              if (dto.Id!=id)
                 {
                _response.IsExitoso = false;
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento id & modelo.id no pueden ser diferenes"];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento id & modelo.id no pueden ser diferenes", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
                }
            if (!ModelState.IsValid) 
            {
                _logger.LogError(ModelState.ToString(),"{StatusCode}[{HttpStatusCode}]", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(ModelState);
            };
            try
            {
                await _usuarioRepo.Update(_mapper.Map<Usuario>(dto));
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Respuesta de UPDATE ha sido exitosa", StatusCodes.Status204NoContent, HttpStatusCode.NoContent);
                _response.Status = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Status= HttpStatusCode.BadRequest;
                _response.ErrorMensajes = [ex.ToString()];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error al intentar UPDATE", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            }
            

        }
    }
}
