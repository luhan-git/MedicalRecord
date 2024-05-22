using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using AutoMapper;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Paciente;
using System.Net;

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
                PacienteDto paciente = _mapper.Map<PacienteDto>(await _pacienteRepository.Create(_mapper.Map<Paciente>(dto)));
                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                _response.Resultado = paciente;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                IEnumerable<PacienteDto> pacientes = _mapper.Map<IEnumerable<PacienteDto>>(await _pacienteRepository.QueryAsync());
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = pacientes;

                return Ok(_response);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al intentar obtener pacientes");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<Response>> Update(int id, [FromBody] PacienteUpdateDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id <= 0 || id != dto.Id)
        //    {
        //        _response.Status = HttpStatusCode.BadRequest;
        //        _response.ErrorMensajes = ["El identificador de alergia no es válido."];
        //        return BadRequest(_response);
        //    }

        //    try
        //    {
        //        Paciente paciente = await _pacienteRepository.GetByIdAsync(id);
        //        if (paciente == null)
        //        {
        //            _response.Status = HttpStatusCode.BadRequest;
        //            _response.ErrorMensajes = ["Paciente no encontrado."];
        //            return BadRequest(_response);
        //        }

        //        paciente = _mapper.Map<Paciente>(dto);
        //        paciente.Id = id;
        //        PacienteDto pacienteDto = _mapper.Map<PacienteDto>(await _pacienteRepository.Update(paciente));
        //        _response.Status = HttpStatusCode.OK;
        //        _response.IsExitoso = true;
        //        _response.Resultado = pacienteDto;

        //        return Ok(_response);
        //    }
        //    catch (Exception)
        //    {
        //        _logger.LogError($"Error al intentar actualizar paciente con id {id}");
        //        _response.Status = HttpStatusCode.InternalServerError;
        //        _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
        //        return StatusCode(StatusCodes.Status500InternalServerError, _response);
        //    }
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<Response>> GetById(int id)
        //{
        //    try
        //    {
        //        PacienteDto paciente = _mapper.Map<PacienteDto>(await _pacienteRepository.GetByIdAsync(id));
        //        if (paciente == null)
        //        {
        //            _response.Status = HttpStatusCode.NotFound;
        //            _response.ErrorMensajes = ["Paciente no encontrado."];
        //            return NotFound(_response);
        //        }

        //        _response.Status = HttpStatusCode.OK;
        //        _response.IsExitoso = true;
        //        _response.Resultado = paciente;

        //        return Ok(_response);
        //    }
        //    catch (Exception)
        //    {
        //        _logger.LogError($"Error al intentar obtener paciente con id {id}");
        //        _response.Status = HttpStatusCode.InternalServerError;
        //        _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
        //        return StatusCode(StatusCodes.Status500InternalServerError, _response);
        //    }
        //}

    }
}
