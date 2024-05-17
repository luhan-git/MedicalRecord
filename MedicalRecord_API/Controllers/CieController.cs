using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
                IEnumerable<CieDto> medicoList = _mapper.Map<IEnumerable<CieDto>>(await _cieRepo.Query());
                _response.Resultado = medicoList;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
        [HttpGet("Id:int", Name = "GetCie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response>> GetCie(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                CieDto cieDto = _mapper.Map<CieDto>(await _cieRepo.GetEntity(c => c.Id == Id, false));
                if (cieDto == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = cieDto;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] CieCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (createDto == null) return BadRequest(createDto);
                if (await _cieRepo.GetEntity(v => v.Codigo.ToUpper() == createDto.Codcie.ToUpper(), false) != null)
                {
                    ModelState.AddModelError("CodigoExiste", "El cie con este codigo ya existe");
                    return BadRequest(ModelState);
                }

                Cie modelo = _mapper.Map<Cie>(createDto);
                int idModelo = await _cieRepo.Create(modelo);
                modelo.Id = idModelo;
                _response.Resultado = _mapper.Map<CieDto>(modelo);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetCie", new { id = modelo.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    BadRequest(_response);
                };
                Cie cie = await _cieRepo.GetEntity(v => v.Id == id, false);
                if (cie == null)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _cieRepo.Delete(cie);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return BadRequest(_response);
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CieUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (updateDto == null) return BadRequest(updateDto);
                if (await _cieRepo.GetEntity(c => c.Codigo.ToUpper() == updateDto.Codcie.ToUpper(), false) != null)
                {
                    ModelState.AddModelError("CodigoExiste", "El cie con este codigo ya existe");
                    return BadRequest(ModelState);
                }
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (updateDto == null || id != updateDto.IdCie)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                await _cieRepo.Update(_mapper.Map<Cie>(updateDto));
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return BadRequest(_response);
        }
    }
}
