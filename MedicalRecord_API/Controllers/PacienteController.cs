using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Paciente;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;
        private readonly IDetalleAlergiaService _detAlergia;
        private readonly IAntecedenteService _antecedente;
        private readonly IMapper _mapper;
        private readonly Response _response;
        public PacienteController(IPacienteService service,IMapper mapper,
                                  IDetalleAlergiaService detAlergia,
                                  IAntecedenteService antecedente)
        {
            _mapper = mapper;
            _service = service;
            _detAlergia = detAlergia;
            _antecedente= antecedente;
            _response = new();
        }

        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetPacientes()
        {
            try
            {
                IEnumerable<Paciente> pacientes = await _service.List();
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<IEnumerable<PacienteListDto>>(pacientes);
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
                _response.ErrorMessages = ["El identificador no es válido."];
                return BadRequest(_response);
            }
            try
            {
                Paciente paciente = await _service.GetById(id);
                if (paciente == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["modelo: no existe en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<PacienteDto>(paciente);
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud.",ex.ToString()];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("Antecedentes/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAntecedentes(int id)
        {
            if (id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["El identificador no es válido."];
                return BadRequest(_response);
            }
            try
            {
                Antecedente antecedente = await _antecedente.GetAntecendente(a=> a.IdPaciente==id);
                if (antecedente == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMessages = ["modelo: no existe en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<AntecedenteDto>(antecedente);
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<Response>> Create([FromBody] PacienteCreateDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {

        //        DateTime fechaNacimiento = dto.FechaNacimiento;
        //        int edad = DateTime.Today.Year - fechaNacimiento.Year;
        //        if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
        //            edad--;

        //        Paciente paciente = _mapper.Map<Paciente>(dto);
        //        paciente.Edad = edad.ToString();
        //        paciente = await _pacienteRepository.Create(paciente);

        //        _response.Result = _mapper.Map<PacienteDto>(paciente);
        //        _response.Status = HttpStatusCode.Created;
        //        _response.IsSuccess = true;

        //        return CreatedAtRoute("GetPaciente", new { id = paciente.Id }, _response);

        //    }
        //    catch
        //    {
        //        _response.Status = HttpStatusCode.InternalServerError;
        //        _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
        //        return StatusCode(StatusCodes.Status500InternalServerError, _response);
        //    }
        //}
    }
}
