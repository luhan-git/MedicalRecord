using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Ubicacion;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly IGenericRepository<Departamento> _departamentoRepository;
        private readonly IGenericRepository<Provincium> _provinciaRepository;
        private readonly IGenericRepository<Distrito> _distritoRepository;
        private readonly IMapper _mapper;
        internal Response _response;
        public UbicacionController(IGenericRepository<Departamento> departamentoRepository, IGenericRepository<Provincium> provinciaRepository, IGenericRepository<Distrito> distritoRepository, IMapper mapper)
        {
            _departamentoRepository = departamentoRepository;
            _provinciaRepository = provinciaRepository;
            _distritoRepository = distritoRepository;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet("Departamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetDepartamentos()
        {
            try
            {
                IEnumerable<DepartamentoDto> dpaList = _mapper.Map<IEnumerable<DepartamentoDto>>(await _departamentoRepository.QueryAsync());
                _response.Result = dpaList;
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
        [HttpGet("Provincias_x_Departamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response>> Provincia_x_Departamento(int IdDepartamento)
        {

            if (IdDepartamento < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            try
            {
                IEnumerable<ProvinciaDto> provList = _mapper.Map<IEnumerable<ProvinciaDto>>(await _provinciaRepository.QueryAsync(p => p.IdDepartamento == IdDepartamento));
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = provList;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("Distritos_x_Provincia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response>> Distritos_x_Provincia(int IdProvincia)
        {

            if (IdProvincia < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            try
            {
                IEnumerable<DistritoDto> distList = _mapper.Map<IEnumerable<DistritoDto>>(await _distritoRepository.QueryAsync(d => d.IdProvincia == IdProvincia));
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = distList;
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
