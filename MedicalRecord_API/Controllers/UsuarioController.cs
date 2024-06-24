using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Net;

namespace MedicalRecord_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;
        protected Response _response;

        public UsuarioController(IMapper mapper, IUsuarioService service)
        {
            _service = service;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuarios()
        {
            try
            {
                IEnumerable<Usuario> usuarios =await _service.List();
                _response.Result = _mapper.Map<IEnumerable<UsuarioListDto>>(usuarios);
                _response.IsSuccess = true;
                _response.Status = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud.",ex.Message];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("Perfil/{id:int}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetUsuario(int id)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador no es valido"];
                return BadRequest(_response);
            }
            try
            {
                Usuario usuario = await _service.GetById(id);
                if (usuario == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["No existen registros para este usuario."];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<PerfilDto>(usuario);
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud.",ex.Message];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] UsuarioCreateDto dto)
        {
            if (dto == null)
            {
                _response.ErrorMessages = ["no se puede procesar un modelo vacio"];
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
                modelo = await _service.Create(modelo);
                if (modelo == null)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Error al registrar Usuario"];
                    return BadRequest(_response);
                }
                _response.Result = _mapper.Map<PerfilDto>(modelo);
                _response.Status = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetUsuario", new { id = modelo.Id }, _response);

            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud.", ex.Message];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }

}
