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

        [HttpGet()]
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
            catch (Exception)
            {
                _logger.LogError($"Error al intentar obtener pacientes");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("{Id:int}", Name = "GetPaciente")]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetPaciente(int Id)
        {
            if (Id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            try
            {
                PacienteDetalleDto pacienteDto = _mapper.Map<PacienteDetalleDto>(await _pacienteRepository.GetEntity(p => p.Id == Id, false));
                if (pacienteDto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = pacienteDto;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMensajes = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] PacienteCreateDto dto)
        {
            if (dto == null)
            {
                _response.ErrorMensajes = ["modelo: no puede ser null"];
                _response.Status = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PacienteDetalleDto modelo = _mapper.Map<PacienteDetalleDto>(await _pacienteRepository.Create(_mapper.Map<Paciente>(dto)));
                if (await _pacienteRepository.GetEntity(p => string.Equals(p.NumeroDocumento, dto.NumeroDocumento), false) != null)
                {
                    _response.ErrorMensajes = ["El paciente con este identificador ya existe"];
                    return BadRequest(_response);
                }
                _response.Status = HttpStatusCode.Created;
                _response.Resultado = modelo;
                _response.IsExitoso = true;
                return CreatedAtRoute("GetPaciente", new { id = modelo.Id }, _response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar crear paciente");
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString(),"Ocurrió un error al procesar la solicitud."];
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



    }
}
