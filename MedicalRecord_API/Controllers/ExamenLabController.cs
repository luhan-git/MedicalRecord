using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.ExamenLab;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenLabController : ControllerBase
    {
        private readonly IExamenLaboratorioRepository _examenRepo;
        private readonly IMapper _mapper;
        protected Response _response;
        public ExamenLabController(IExamenLaboratorioRepository examenRepo, IMapper mapper)
        {
            _examenRepo = examenRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetExamenesLaboratorio()
        {
            try
            {
                IEnumerable<ExamenLabDto> examenList = _mapper.Map<IEnumerable<ExamenLabDto>>(await _examenRepo.QueryAsync());
                _response.Resultado = examenList;
                _response.IsExitoso = true;
                _response.Status = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("{Id:int}", Name = "GetExamenLaboratorio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response>> GetExamenLaboratorio(int Id)
        {

            if (Id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            try
            {
                ExamenLabDto dto = _mapper.Map<ExamenLabDto>(await _examenRepo.GetEntity(c => c.Id == Id, false));
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
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
