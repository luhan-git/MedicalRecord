using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Alergia;
using MedicalRecord_API.Models;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlergiaController : ControllerBase
    {
        private readonly IAlergiaRepository _alergiaRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<AlergiaController> _logger;
        protected Response _response;

        public AlergiaController(IAlergiaRepository alergiaRepo,IMapper mapper,ILogger<AlergiaController> logger)
        {
            _alergiaRepo = alergiaRepo;
            _mapper = mapper;
            _logger = logger;
            _response = new Response();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] AlergiaCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var alergia = _mapper.Map<Alergium>(dto);
                alergia = await _alergiaRepo.Create(alergia);

                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                _response.Resultado = alergia;

                return Created("", _response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar crear alergia");
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
                IEnumerable<Alergium> lsAlergia = _mapper.Map<IEnumerable<Alergium>>(await _alergiaRepo.Query());
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = lsAlergia;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar obtener alergias");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Update(int id, [FromBody] AlergiaUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (id <= 0)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMensajes = ["Id de alergia no válido."];
                    return BadRequest(_response);
                }

                var alergia = await _alergiaRepo.GetEntity(e => e.Id == id, false);

                if (alergia == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Alergia no encontrada."];
                    return NotFound(_response);
                }

                await _alergiaRepo.Update(_mapper.Map<Alergium>(dto));

                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar actualizar alergia");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["Id de alergia no válido."];
                return BadRequest();
            }

            try
            {
                var alergia = await _alergiaRepo.GetEntity(e => e.Id == id, false);

                if (alergia == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Alergia no encontrada."];
                    return NotFound(_response);
                }

                await _alergiaRepo.Delete(alergia);

                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar eliminar alergia");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Get(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["Id de alergia no válido."];
                return BadRequest(_response);
            }

            try
            {
                var alergia = await _alergiaRepo.GetEntity(e => e.Id == id, false);

                if (alergia == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Alergia no encontrada."];
                    return NotFound(_response);
                }

                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = alergia;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar obtener alergia");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

    }
}
