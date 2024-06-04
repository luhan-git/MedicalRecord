using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Ocupacion;
using MedicalRecord_API.Models;
using System.Net;


namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcupacionController(IOcupacionRepository ocupacionRepo, IMapper mapper) : ControllerBase
    {
        private readonly IOcupacionRepository _ocupacionRepo = ocupacionRepo;
        private readonly IMapper _mapper = mapper;
        protected Response _response = new();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] OcupacionCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                OcupacionDto ocupacion = _mapper.Map<OcupacionDto>(await _ocupacionRepo.Create(_mapper.Map<Ocupacion>(dto)));
                _response.Status = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = ocupacion;

                return Created("", _response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
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
                IEnumerable<OcupacionDto> ocupaciones = _mapper.Map<IEnumerable<OcupacionDto>>(await _ocupacionRepo.QueryAsync());
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = ocupaciones;

                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Update(int id, [FromBody] OcupacionUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador de ocupación no es válido"];

                return BadRequest(_response);
            }

            try
            {
                var ocupacion = await _ocupacionRepo.GetAsync(e => e.Id == id, false);

                if (ocupacion == null)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Ocupación no encontrada"];

                    return BadRequest(_response);
                }

                await _ocupacionRepo.Update(_mapper.Map<Ocupacion>(dto));

                _response.Status = HttpStatusCode.OK;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador de ocupación no es válido"];

                return BadRequest(_response);
            }

            try
            {
                var ocupacion = await _ocupacionRepo.GetAsync(e => e.Id == id, false);

                if (ocupacion == null)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Ocupación no encontrada"];

                    return BadRequest(_response);
                }

                await _ocupacionRepo.Delete(ocupacion);

                _response.Status = HttpStatusCode.OK;
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
                _response.ErrorMessages = ["El identificador de ocupación no es válido"];

                return BadRequest(_response);
            }

            try
            {
                OcupacionDto ocupacion = _mapper.Map<OcupacionDto>(await _ocupacionRepo.GetAsync(e => e.Id == id, false));

                if (ocupacion == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Ocupación no encontrada"];

                    return NotFound(_response);
                }

                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = ocupacion;

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
