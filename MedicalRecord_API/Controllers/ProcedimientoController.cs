using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Procedimiento;
using MedicalRecord_API.Models;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientoController : ControllerBase
    {
        private readonly IProcedimientoRepository _procedimientoRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<ProcedimientoController> _logger;
        protected Response _response;

        public ProcedimientoController(
                       IProcedimientoRepository procedimientoRepo,
                                  IMapper mapper,
                                             ILogger<ProcedimientoController> logger)
        {
            _procedimientoRepo = procedimientoRepo;
            _mapper = mapper;
            _logger = logger;
            _response = new Response();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] ProcedimientoCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var procedimiento = _mapper.Map<Procedimiento>(dto);
                procedimiento = await _procedimientoRepo.Create(procedimiento);

                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                _response.Resultado = procedimiento;

                return Created("", _response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar crear procedimiento");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Update([FromBody] ProcedimientoUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _procedimientoRepo.Update(_mapper.Map<Procedimiento>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar actualizar procedimiento");
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
                IEnumerable<Procedimiento> lsprocedimiento = _mapper.Map<IEnumerable<Procedimiento>>(await _procedimientoRepo.Query());
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = lsprocedimiento;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar obtener procedimientos");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

    }
}
