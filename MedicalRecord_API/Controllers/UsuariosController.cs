using AutoMapper;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                _response.StatusCode = HttpStatusCode.OK;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Request handled successfully", StatusCodes.Status200OK, HttpStatusCode.OK);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
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
        public async Task<ActionResult<Response>> GetUsuario(int Id)
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Handling GETUSUARIO request", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling GETUSUARIO request", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    return BadRequest(_response);
                }
                UsuarioCreateDto usuarioDto = _mapper.Map<UsuarioCreateDto>(await _usuarioRepo.GetEntity(u =>u.Id == Id, false));
                if (usuarioDto == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling GETUSUARIO request", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    return NotFound(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = usuarioDto;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Request handled successfully", StatusCodes.Status200OK, HttpStatusCode.OK);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error handling GETUSUARIOS request", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }
        }
    }
}
