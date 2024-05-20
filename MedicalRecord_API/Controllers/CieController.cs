using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly ILogger<CieController> _logger;
        protected Response _response;
        public CieController(ICieRepository cieRepo, IMapper mapper, ILogger<CieController> logger)
        {
            _cieRepo = cieRepo;
            _mapper = mapper;
            _logger = logger;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetCies()
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a GETCIES", StatusCodes.Status102Processing, HttpStatusCode.Processing);
            try
            {
                IEnumerable<CieDto> cieList = _mapper.Map<IEnumerable<CieDto>>(await _cieRepo.Query());
                _response.Resultado = cieList;
                _response.IsExitoso = true; 
                _response.Status = HttpStatusCode.OK;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Respuesta exitosa de GETCIES", StatusCodes.Status200OK, HttpStatusCode.OK);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de GETCIES", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
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
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a GETCIE", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            if (Id < 1)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                   _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                   _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento no puede ser 0", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                   return BadRequest(_response);
                }
            try
            {
                CieDto dto = _mapper.Map<CieDto>(await _cieRepo.GetEntity(c => c.Id == Id, false));
                if (dto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: no esxiste en la base de datos", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = dto;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Respuesta exitosa de GETCIE", StatusCodes.Status200OK, HttpStatusCode.OK);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de GETCIE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] CieCreateDto dto)
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud CREATE", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            if (dto == null)
            {
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                _response.Status = HttpStatusCode.BadRequest;
                _logger.LogError("{StatusCode}[{HttpStatusCode}] : modelo: modelo no puede ser null", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            };
            if (!ModelState.IsValid)
            {
                _logger.LogError("{StatusCode}[{HttpStatusCode}] {ModelState}", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest, ModelState.ToString());
                return BadRequest(ModelState);
            };
            try
            {
                if (await _cieRepo.GetEntity(v => string.Equals(v.Codigo,dto.Codigo), false) != null)
                {
                    _response.ErrorMensajes = ["codigoExiste", "El Cie con este Codigo ya existe"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: El Cie con este Codigo ya existe", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    return BadRequest(_response);
                }

                Cie modelo = _mapper.Map<Cie>(dto);
                modelo= await _cieRepo.Create(modelo);
                _response.Resultado = _mapper.Map<CieDto>(modelo);
                _response.IsExitoso = true;
                _response.Status = HttpStatusCode.Created;
                _logger.LogWarning("{StatusCode}[{HttpStatusCode}]: Respuesta existosa de CREATE", StatusCodes.Status201Created, HttpStatusCode.Created);
                return CreatedAtRoute("GetCie", new { id = modelo.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error en la respuesta de CREATE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
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
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a UPDATE", StatusCodes.Status102Processing, HttpStatusCode.Processing);


            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento no puede ser 0", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            }
            if (dto == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: argumento no puede ser null", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            }
            if (dto.Id != id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento id & modelo.id no pueden ser diferenes"];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento id & modelo.id no pueden ser diferenes", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("{StatusCode}[{HttpStatusCode}] {ModelState}", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest, ModelState.ToString());
                return BadRequest(ModelState);
            };
            try
            {
                if (await _cieRepo.GetEntity(c => c.Id == id, false) == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["modelo: no esxiste en la base de datos"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: no esxiste en la base de datos", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    return BadRequest(_response);
                }
                if (await _cieRepo.GetEntity(c => string.Equals(c.Codigo, dto.Codigo), false) != null)
                {
                    _response.ErrorMensajes = ["El Cie con este Codigo ya existe"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}] El Cie con este Codigo ya existe", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                    return BadRequest(_response);
                }
                await _cieRepo.Update(_mapper.Map<Cie>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                _logger.LogWarning("{StatusCode}[{HttpStatusCode}]: Respuesta de UPDATE ha sido exitosa", StatusCodes.Status204NoContent, HttpStatusCode.NoContent);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error al intentar UPDATE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
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
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a PARTIALUPDATE", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento no puede ser 0", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            }
            if (patch == null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: argumento no puede ser null", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);
                return BadRequest(_response);
            }
            try
            {

                Cie cie = await _cieRepo.GetEntity(v => v.Id == id, false);
                if (cie == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: no esxiste en la base de datos", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    return NotFound(_response);
                }

                CieUpdateDto dto = _mapper.Map<CieUpdateDto>(cie);
                patch.ApplyTo(dto, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("{StatusCode}[{HttpStatusCode}] {ModelState}", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest, ModelState.ToString());
                    return BadRequest(ModelState);
                };

                await _cieRepo.Update(_mapper.Map<Cie>(dto));
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                _logger.LogWarning("{StatusCode}[{HttpStatusCode}]: Respuesta de UPDATE ha sido exitosa", StatusCodes.Status204NoContent, HttpStatusCode.NoContent);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error al intentar UPDATE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
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
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]:Procesando la solicitud a DELETE", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: id: argumento no puede ser 0", StatusCodes.Status400BadRequest, HttpStatusCode.BadRequest);

                BadRequest(_response);
            };
            try
            {
                Cie cie = await _cieRepo.GetEntity(c => c.Id == id, false);
                if (cie == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["modelo: no esxiste en la base de datos"];
                    _logger.LogError("{StatusCode}[{HttpStatusCode}]: modelo: no esxiste en la base de datos", StatusCodes.Status404NotFound, HttpStatusCode.NotFound);
                    return NotFound(_response);
                }
                await _cieRepo.Delete(cie);
                _response.Status = HttpStatusCode.NoContent;
                _response.IsExitoso = true;
                _logger.LogWarning("{StatusCode}[{HttpStatusCode}]: Respuesta de DELETE ha sido exitosa", StatusCodes.Status204NoContent, HttpStatusCode.NoContent);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
                _logger.LogError("{StatusCode}[{HttpStatusCode}]: Error al intentar DELETE", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
