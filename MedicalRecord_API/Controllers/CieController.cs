using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CieController : ControllerBase
    {
        private readonly ICieRepository _cieRepo;
        private readonly IMapper _mapper;
        protected Response _response;

        public CieController(ICieRepository cieRepo, IMapper mapper)
        {
            _cieRepo = cieRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetCies()
        {
            try
            {
                IEnumerable<CieDto> cieList = _mapper.Map<IEnumerable<CieDto>>(await _cieRepo.QueryAsync());
                _response.Resultado = cieList;
                _response.IsExitoso = true; 
                _response.Status = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }
        }
        [HttpGet("{Id:int}", Name = "GetCie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response>> GetCie(int Id)
        {

            if (Id < 1)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                   _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                   return BadRequest(_response);
                }
            try
            {
                CieDto dto = _mapper.Map<CieDto>(await _cieRepo.GetEntity(c => c.Id == Id, false));
                if (dto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = dto;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] CieCreateDto dto)
        {

            if (dto == null)
            {
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                _response.Status = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            try
            {
                if (await _cieRepo.GetEntity(v => string.Equals(v.Codigo,dto.Codigo), false) != null)
                {
                    return BadRequest(_response);
                }

                Cie modelo = _mapper.Map<Cie>(dto);
                modelo= await _cieRepo.Create(modelo);
                _response.Resultado = _mapper.Map<CieDto>(modelo);
                _response.IsExitoso = true;
                _response.Status = HttpStatusCode.Created;
                return CreatedAtRoute("GetCie", new { id = modelo.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
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


            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            if (dto == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                return BadRequest(_response);
            }
            if (dto.Id != id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento id & modelo.id no pueden ser diferenes"];
                return BadRequest(_response);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            try
            {
                if (await _cieRepo.GetEntity(c => c.Id == id, false) == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["modelo: no esxiste en la base de datos"];
                    return BadRequest(_response);
                }
                if (await _cieRepo.GetEntity(c => string.Equals(c.Codigo, dto.Codigo), false) != null)
                {
                    _response.ErrorMensajes = ["El Cie con este Codigo ya existe"];
                    return BadRequest(_response);
                }
                await _cieRepo.Update(_mapper.Map<Cie>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
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
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            if (patch == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                return BadRequest(_response);
            }
            try
            {

                Cie cie = await _cieRepo.GetEntity(v => v.Id == id, false);
                if (cie == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }

                CieUpdateDto dto = _mapper.Map<CieUpdateDto>(cie);
                patch.ApplyTo(dto, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };

                await _cieRepo.Update(_mapper.Map<Cie>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
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
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];

                BadRequest(_response);
            };
            try
            {
                Cie cie = await _cieRepo.GetEntity(c => c.Id == id, false);
                if (cie == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                await _cieRepo.Delete(cie);
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
