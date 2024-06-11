using AutoMapper;
using FluentValidation.Results;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Validators.Cie;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Roles = "admin")]
    [ApiController]
    public class CieController : ControllerBase
    {
        private readonly ICieService _service;
        private readonly IMapper _mapper;
        protected Response _response;

        public CieController(ICieService service, IMapper mapper)
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
                IEnumerable<CieDto> cies = _mapper.Map<IEnumerable<CieDto>>(await _service.QueryAsync());
                _response.Result = cies;
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
        [HttpGet("{id:int}", Name = "GetCie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response>> GetById(int id)
        {

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador del cie no es válido."];
                return BadRequest(_response);
            }
            try
            {
                CieDto dto = _mapper.Map<CieDto>(await _service.GetAsync(c => c.Id == id, false));
                if (dto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Sin registros para este identificador"];
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
        public async Task<ActionResult<Response>> Create([FromBody] CieCreateDto dto)
        {
            CieCreateDtoValidator validator = new();
            ValidationResult result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(_response);
            }
            try
            {
                if (await _service.GetAsync(v => string.Equals(v.Codigo, dto.Codigo), false) != null)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Ya existe un registro con este nombre"];
                    return BadRequest(_response);
                }

                Cie modelo = _mapper.Map<Cie>(dto);
                modelo = await _service.Create(modelo);
                _response.Result = _mapper.Map<CieDto>(modelo);
                _response.IsSuccess = true;
                _response.Status = HttpStatusCode.Created;
                return CreatedAtRoute("GetCie", new { id = modelo.Id }, _response);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CieUpdateDto dto)
        {
            CieUpdateDtoValidator validator = new();
            ValidationResult result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(_response);
            }

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador del cie no es válido."];
                return BadRequest(_response);
            }
            if (dto.Id != id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador es diferente al id del modelo"];
                return BadRequest(_response);
            }
            try
            {
                if (await _service.GetAsync(c => c.Id == id, false) == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Sin registros para este identificador"];
                    return BadRequest(_response);
                }
                await _service.Update(_mapper.Map<Cie>(dto));
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
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PartialUpdate(int id, [FromBody] JsonPatchDocument<CieUpdateDto> patch)
        {

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador del cie no es válido."];
                return BadRequest(_response);
            }
            if (patch == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El modelo no puede enviarse vacio."];
                return BadRequest(_response);
            }
            try
            {

                Cie cie = await _service.GetAsync(v => v.Id == id, false);
                if (cie == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Sin registros para este identificador"];
                    return NotFound(_response);
                }

                CieUpdateDto dto = _mapper.Map<CieUpdateDto>(cie);
                patch.ApplyTo(dto, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };

                await _service.Update(_mapper.Map<Cie>(dto));
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador no es valido"];
                BadRequest(_response);
            };
            try
            {
                Cie cie = await _service.GetAsync(c => c.Id == id, false);
                if (cie == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["Sin registros para este identificador."];
                    return NotFound(_response);
                }
                await _service.Delete(cie);
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
    }
}
