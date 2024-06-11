using AutoMapper;
using FluentValidation.Results;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Diabetes;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Validators.Diabetes;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "admin")]
    [ApiController]
    public class DiabetesController : ControllerBase
    {
        private readonly IDiabetesService _service;
        private IMapper _mapper;
        protected Response _response;

        public DiabetesController(IDiabetesService service, IMapper mapper)
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
                IEnumerable<DiabetesDto> diabetess = _mapper.Map<IEnumerable<DiabetesDto>>(await _service.QueryAsync());
                _response.Result = diabetess;
                _response.IsSuccess = true;
                _response.Status = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Error al procesar la solicitud en el servidor.", ex.Message];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("{id:int}", Name = "GetDiabetes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetById(int id)
        {

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador no es válido."];
                return BadRequest(_response);
            }
            try
            {
                DiabetesDto dto = _mapper.Map<DiabetesDto>(await _service.GetAsync(c => c.Id == id, false));
                if (dto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Sin registros para este identificador."];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = dto;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Error al procesar la solicitud en el servidor.", ex.Message];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] DiabetesCreateDto dto)
        {
            DiabetesCreateDtoValidator validator = new();
            ValidationResult results = await validator.ValidateAsync(dto);
            if (!results.IsValid)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = results.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(_response);
            }
            if (await _service.GetAsync(d => d.Tipo == dto.Tipo, false) != null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["Ya existe un registro con este nombre"];
                return BadRequest(_response);
            }
            try
            {
                Diabete modelo = _mapper.Map<Diabete>(dto);
                modelo = await _service.Create(modelo);
                _response.Status = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<DiabetesDto>(modelo);
                return CreatedAtRoute("GetDiabetes", new { id = modelo.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Error al procesar la solicitud en el servidor.", ex.Message];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Update(int id, [FromBody] DiabetesUpdateDto dto)
        {

            if (id < 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador de la compañia de seguros no es válido."];
                return BadRequest(_response);
            }

            if (id != dto.Id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador es diferente al id del modelo"];
                return BadRequest(_response);
            }
            DiabetesUpdateDtoValidator validator = new();
            ValidationResult results = await validator.ValidateAsync(dto);
            if (!results.IsValid)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = results.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(_response);
            }
            try
            {
                if (await _service.GetAsync(c => c.Id == id, false) == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Sin registros para este identificador"];
                    return NotFound(_response);
                }

                await _service.Update(_mapper.Map<Diabete>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Error al procesar la solicitud en el servidor.", ex.Message];
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
            bool isValid = id > 0;
            if (!isValid)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador no es valido"];
                return BadRequest(_response);
            }
            try
            {
                Diabete seguro = await _service.GetAsync(c => c.Id == id);
                if (seguro == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Sin registros para este identificador"];
                    return NotFound(_response);
                }
                await _service.Delete(seguro);
                _response.Status = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Error al procesar la solicitud en el servidor."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
