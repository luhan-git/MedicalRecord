using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Repository.Interfaces;
using AutoMapper;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos;
using System.Net;
using MedicalRecord_API.Models;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiaSegurosController : ControllerBase
    {
        /*private readonly ICiaSeguroRepository _ciaSegurosRepo;
        private readonly IMapper _mapper;
        protected Response _response;

        public CiaSegurosController(ICiaSeguroRepository ciaSegurosRepo, IMapper mapper)
        {
            _ciaSegurosRepo = ciaSegurosRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet(Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                IEnumerable<CiaSeguroDto> ciaSegurosList = _mapper.Map<IEnumerable<CiaSeguroDto>>(await _ciaSegurosRepo.Query());
                _response.Resultado = ciaSegurosList;
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

        [HttpGet("Id:int", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response>> Get(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                CiaSeguroDto ciaSeguroDto = _mapper.Map<CiaSeguroDto>(await _ciaSegurosRepo.GetEntity(c => c.IdCia == Id, false));
                if (ciaSeguroDto == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Resultado = ciaSeguroDto;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create(CiaSeguroDto ciaSeguroDto)
        {
            try
            {
                //Debo revisar de nuevo
                if (ciaSeguroDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                CiaSeguros ciaSeguro = _mapper.Map<CiaSeguros>(ciaSeguroDto);
                int idModelo = await _ciaSegurosRepo.Create(ciaSeguro);
                if (idModelo == 0)
                {
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.IsExitoso = false;
                    return StatusCode((int)HttpStatusCode.InternalServerError, _response);
                }
                _response.Resultado = idModelo;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }*/
    }
}
