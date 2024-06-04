using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using AutoMapper;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Paciente;
using System.Net;
using MedicalRecord_API.Models.Dtos.Usuario;
using Microsoft.AspNetCore.Authorization;

namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController(IPacienteRepository pacienteRepository, IMapper mapper) : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository = pacienteRepository;
        private readonly IMapper _mapper = mapper;
        protected Response _response = new();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] PacienteCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                DateTime fechaNacimiento = dto.FechaNacimiento;
                int edad = DateTime.Today.Year - fechaNacimiento.Year;
                if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                    edad--;

                Paciente paciente = _mapper.Map<Paciente>(dto);
                paciente.Edad = edad.ToString();
                paciente = await _pacienteRepository.Create(paciente);

                _response.Result = _mapper.Map<PacienteDto>(paciente);
                _response.Status = HttpStatusCode.Created;
                _response.IsSuccess = true;

                return CreatedAtRoute("GetPaciente", new { id = paciente.Id }, _response);

            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetPacientes()
        {
            try
            {
                IEnumerable<PacienteDto> pacientes = _mapper.Map<IEnumerable<PacienteDto>>(await _pacienteRepository.QueryAsync());
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = pacientes;

                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}", Name = "GetPaciente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetPaciente(int id)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["Identificador fuera del rango permitido"];
                return BadRequest(_response);
            }
            try
            {
                PacienteDetalleDto pacienteDto = _mapper.Map<PacienteDetalleDto>(await _pacienteRepository.GetAsync(p => p.Id == id, false));
                if (pacienteDto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["modelo: no existe en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = pacienteDto;
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
