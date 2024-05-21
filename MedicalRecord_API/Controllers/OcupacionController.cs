using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Ocupacion;
using MedicalRecord_API.Models;
using System.Net;


namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcupacionController : ControllerBase
    {
        private readonly IOcupacionRepository _ocupacionRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<OcupacionController> _logger;
        protected Response _response;

        public OcupacionController(IOcupacionRepository ocupacionRepo,IMapper mapper,ILogger<OcupacionController> logger)
        {
            _ocupacionRepo = ocupacionRepo;
            _mapper = mapper;
            _logger = logger;
            _response = new Response();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] OcupacionCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ocupacion = _mapper.Map<Ocupacion>(dto);
                ocupacion = await _ocupacionRepo.Create(ocupacion);

                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                _response.Resultado = ocupacion;

                return Created("", _response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar crear ocupación");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Update([FromBody] OcupacionUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _ocupacionRepo.Update(_mapper.Map<Ocupacion>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar actualizar ocupación");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                IEnumerable<Ocupacion> ocupaciones = _mapper.Map<IEnumerable<Ocupacion>>(await _ocupacionRepo.Query());
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = ocupaciones;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar obtener ocupaciones");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
