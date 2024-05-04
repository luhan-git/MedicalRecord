﻿using AutoMapper;
using MedicalRecord_API.Models.Dtos;
using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Implements;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MedicalRecord_API.Repository.Interfaces;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IGenericRepository<Medico> _medicoRepo;
        private readonly IMapper _mapper;
        protected Response _response;
        public MedicoController(IGenericRepository<Medico> medicoRepo, IMapper mapper)
        {
            _medicoRepo = medicoRepo;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                IEnumerable<MedicoDto> medicoList = _mapper.Map<IEnumerable<MedicoDto>>(await _medicoRepo.Query());
                _response.Resultado = medicoList;
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
                MedicoDto medicoDto = _mapper.Map<MedicoDto>(await _medicoRepo.GetEntity(c => c.IdMedico == Id, false));
                if (medicoDto == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = medicoDto;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] MedicoCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (createDto == null) return BadRequest(createDto);
                if (await _medicoRepo.GetEntity(v => v.NombreMed.ToUpper() == createDto.NombreMed.ToUpper(), false) != null)
                {
                    ModelState.AddModelError("NombreExiste", "La el medico con este nombre ya existe");
                    return BadRequest(ModelState);
                }
   
                Medico modelo = _mapper.Map<Medico>(createDto);
                await _medicoRepo.Create(modelo);
                _response.Resultado = _mapper.Map<MedicoDto>(modelo);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("Get", new { id = modelo.IdMedico }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
    }
}
