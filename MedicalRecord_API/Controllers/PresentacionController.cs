using AutoMapper;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.Presentacion;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionController : ControllerBase
    {
        private readonly IPresentacionRepository _presentacionRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<PresentacionController> _logger;
        protected Response _response;
        public PresentacionController(IPresentacionRepository presentacionRepo, IMapper mapper, ILogger<PresentacionController> logger)
        {
            _presentacionRepo = presentacionRepo;
            _mapper = mapper;
            _logger = logger;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetPresentaciones()
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a GETPRESENTACIONES", StatusCodes.Status102Processing, HttpStatusCode.Processing);
            try
            {
                IEnumerable<PresentacionDto> presentacionList = _mapper.Map<IEnumerable<PresentacionDto>>(await _presentacionRepo.Query());
                _response.Resultado = presentacionList;
                _response.IsExitoso = true;
                _response.Status = HttpStatusCode.OK;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Respuesta exitosa de GETPRESENTACIONES", StatusCodes.Status200OK, HttpStatusCode.OK);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de GETPRESENTACIONES", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }
        }
        [HttpGet("{Id:int}", Name = "GetPresentacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response>> GetPresentacion(int Id)
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a GETCIE", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            if (Id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento no puede ser 0", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            }
            try
            {
                CieDto dto = _mapper.Map<CieDto>(await _presentacionRepo.GetEntity(c => c.Id == Id, false));
                if (dto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: no esxiste en la base de datos", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = dto;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Respuesta exitosa de GETCIE", StatusCodes.Status200OK, HttpStatusCode.OK);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de GETCIE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
