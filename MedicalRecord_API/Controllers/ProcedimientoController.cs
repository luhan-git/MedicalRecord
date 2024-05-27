using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Procedimiento;
using MedicalRecord_API.Models;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcedimientoController(IProcedimientoRepository procedimientoRepo, IMapper mapper) : ControllerBase
    {
        private readonly IProcedimientoRepository _procedimientoRepo = procedimientoRepo;
        private readonly IMapper _mapper = mapper;
        protected Response _response = new();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] ProcedimientoCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProcedimientoDto procedimiento = _mapper.Map<ProcedimientoDto>(await _procedimientoRepo.Create(_mapper.Map<Procedimiento>(dto)));
                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                _response.Resultado = procedimiento;

                return Created("", _response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                IEnumerable<ProcedimientoDto> procedimientos = _mapper.Map<IEnumerable<ProcedimientoDto>>(await _procedimientoRepo.QueryAsync());
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = procedimientos;

                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Update(int id, [FromBody] ProcedimientoUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["El identificador del procedimiento no es válido"];
                return BadRequest(_response);
            }

            try
            {
                var procedimiento = await _procedimientoRepo.GetEntity(e => e.Id == id, false);

                if (procedimiento == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Procedimiento no encontrado"];
                    return NotFound(_response);
                }

                await _procedimientoRepo.Update(_mapper.Map<Procedimiento>(dto));

                _response.Status = HttpStatusCode.OK;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["El identificador del procedimiento no es válido"];
                return BadRequest(_response);
            }

            try
            {
                var procedimiento = await _procedimientoRepo.GetEntity(e => e.Id == id, false);

                if (procedimiento == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Procedimiento no encontrado"];
                    return NotFound(_response);
                }

                await _procedimientoRepo.Delete(procedimiento);

                _response.Status = HttpStatusCode.OK;
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

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["El identificador del procedimiento no es válido"];
                return BadRequest(_response);
            }

            try
            {
                ProcedimientoDto procedimiento = _mapper.Map<ProcedimientoDto>(await _procedimientoRepo.GetEntity(e => e.Id == id, false));

                if (procedimiento == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Procedimiento no encontrado"];
                    return NotFound(_response);
                }

                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = procedimiento;

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
