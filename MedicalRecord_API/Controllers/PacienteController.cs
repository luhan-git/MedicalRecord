using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using AutoMapper;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Paciente;
using System.Net;
using MedicalRecord_API.Models.Dtos.Usuario;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        protected Response _response;
        private readonly ILogger<PacienteController> _logger;

        public PacienteController(IPacienteRepository pacienteRepository, IMapper mapper, ILogger<PacienteController> logger)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _logger = logger;
            _response = new();
        }

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
                PacienteDto pacienteDto = _mapper.Map<PacienteDto>(paciente);

                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                _response.Resultado = pacienteDto;

                return CreatedAtRoute("GetPaciente", new { id = paciente.Id }, _response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar crear paciente {ex.Message}");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetPacientes()
        {
            try
            {
                IEnumerable<PacienteDto> pacientes = _mapper.Map<IEnumerable<PacienteDto>>(await _pacienteRepository.QueryAsync());
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = pacientes;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar obtener pacientes: {ex.Message}");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}", Name = "GetPaciente")]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetPaciente(int id)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["Identificador fuera del rango permitido"];
                return BadRequest(_response);
            }
            try
            {
                PacienteDetalleDto pacienteDto = _mapper.Map<PacienteDetalleDto>(await _pacienteRepository.GetEntity(p => p.Id == id, false));
                if (pacienteDto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["modelo: no existe en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = pacienteDto;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar crear paciente: {ex.Message}");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

    }
}
