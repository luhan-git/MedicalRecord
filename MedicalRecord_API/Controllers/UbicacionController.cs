using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Ubicacion;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionService _service;
        private readonly IMapper _mapper;
        internal Response _response;
        public UbicacionController(IUbicacionService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
            _response = new();
        }


        [HttpGet("Departamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetDepartamentos()
        {
            try
            {
                IEnumerable<Departamento> departamentos =await _service.Departamentos();
                _response.Result = _mapper.Map<IEnumerable<DepartamentoDto>>(departamentos);
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return _response;

            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("Provincias/Departamento/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response>> ProvinciaxDepartamento(int id)
        {

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["Identificador de departameto no es valido."];
                return BadRequest(_response);
            }
            try
            {
                IEnumerable<Provincia> provincias = await _service.Provincias(id);
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<IEnumerable<ProvinciaDto>>(provincias);
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("Distritos/Provincia/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response>> DistritosxProvincia(int id)
        {

            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador para provinvia no es valido."];
                return BadRequest(_response);
            }
            try
            {
                IEnumerable<Distrito> distritos = await _service.Distritos(id);
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<IEnumerable<DistritoDto>>(distritos);
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
