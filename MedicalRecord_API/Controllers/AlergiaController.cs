using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Alergia;
using MedicalRecord_API.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Models.Dtos.Cie;

namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlergiaController: ControllerBase
    {
        private readonly IAlergiaService _service;
        private readonly IMapper _mapper;
        protected Response _response;
        public AlergiaController(IAlergiaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                IEnumerable<AlergiaDto> alergias = _mapper.Map<IEnumerable<AlergiaDto>>(await _service.QueryAsync());
                _response.Result = alergias;
                _response.IsSuccess = true;
                _response.Status = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("{Id:int}", Name = "GetAlergia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetById(int Id)
        {
            try
            {
                AlergiaDto dto = _mapper.Map<AlergiaDto>(await _service.GetAsync(a => a.Id == Id, false));
                if (dto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = dto;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] AlergiaCreateDto dto)
        {
            try
            {
                 Alergium modelo=_mapper.Map<Alergium>(dto);
                 modelo=await _service.Create(modelo);
                _response.Status = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<AlergiaCreateDto>(modelo);
                return CreatedAtRoute("GetAlergia", new { id = modelo.Id }, _response);
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Update(int id, [FromBody] AlergiaUpdateDto dto)
        {
            if (id != dto.Id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador no coinicde con el id del modelo"];
                return BadRequest(_response);
            }

            try
            {
                if (await _service.GetAsync(a=> a.Id==id,false)==null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Identificador no encontrado en los registros"];
                    return NotFound(_response);
                }

                await _service.Update(_mapper.Map<Alergium>(dto));
                _response.Status = HttpStatusCode.NoContent;
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
            try
            {
                Alergium alergia =await _service.GetAsync(a => a.Id == id);
                if (alergia==null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["este identificador ya no existe en los registros"];
                    return NotFound(_response);
                }
                await _service.Delete(alergia);
                _response.Status = HttpStatusCode.NoContent;
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
    }
}
