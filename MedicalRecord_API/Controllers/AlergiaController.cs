﻿using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Alergia;
using MedicalRecord_API.Models;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlergiaController : ControllerBase
    {
        private readonly IAlergiaRepository _alergiaRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<AlergiaController> _logger;
        protected Response _response;

        public AlergiaController(IAlergiaRepository alergiaRepo,IMapper mapper,ILogger<AlergiaController> logger)
        {
            _alergiaRepo = alergiaRepo;
            _mapper = mapper;
            _logger = logger;
            _response = new Response();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] AlergiaCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                AlergiaDto alergia = _mapper.Map<AlergiaDto>(await _alergiaRepo.Create(_mapper.Map<Alergium>(dto)));
                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                _response.Resultado = alergia;

                return Created("", _response);
            }
            catch(Exception ex)
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString(),"Ocurrió un error al procesar la solicitud."];
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
                IEnumerable<AlergiaDto> alergias = _mapper.Map<IEnumerable<AlergiaDto>>(await _alergiaRepo.QueryAsync());
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = alergias;

                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Update(int id, [FromBody] AlergiaUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id <= 0 || id != dto.Id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["El identificador de alergia no es válido."];
                return BadRequest(_response);
            }

            try
            {
                var alergia = await _alergiaRepo.GetEntity(e => e.Id == id, false);

                if (alergia == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Alergia no encontrada."];
                    return NotFound(_response);
                }

                await _alergiaRepo.Update(_mapper.Map<Alergium>(dto));

                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;

                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["Id de alergia no válido."];
                return BadRequest();
            }

            try
            {
                var alergia = await _alergiaRepo.GetEntity(e => e.Id == id, false);

                if (alergia == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Alergia no encontrada."];
                    return NotFound(_response);
                }

                await _alergiaRepo.Delete(alergia);

                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;

                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Get(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["Id de alergia no válido."];
                return BadRequest(_response);
            }

            try
            {
                AlergiaDto alergia = _mapper.Map<AlergiaDto>(await _alergiaRepo.GetEntity(e => e.Id == id, false));

                if (alergia == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Alergia no encontrada."];
                    return NotFound(_response);
                }

                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = alergia;

                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

    }
}
