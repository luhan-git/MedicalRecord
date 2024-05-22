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
            _response = new Response();
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

                return Created("", _response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar crear paciente");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

    }
}
