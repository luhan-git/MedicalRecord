using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Consulta;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController(IConsultaRepository consultaRepo, IMapper mapper) : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepo = consultaRepo;
        private readonly IMapper _mapper = mapper;
        protected Response _response = new();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] ConsultaCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ConsultaDto consulta = _mapper.Map<ConsultaDto>(await _consultaRepo.Create(_mapper.Map<Consultum>(dto)));
                _response.Status = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = consulta;

                return Created("", _response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                IEnumerable<ConsultaDto> consultas = _mapper.Map<IEnumerable<ConsultaDto>>(await _consultaRepo.QueryAsync());
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = consultas;

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
