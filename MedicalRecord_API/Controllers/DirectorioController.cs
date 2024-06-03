using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.Directorio;
using MedicalRecord_API.Models;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorioController(IDirectorioRepository directorioRepo, IMapper mapper) : ControllerBase
    {
        private readonly IDirectorioRepository _directorioRepo = directorioRepo;
        private readonly IMapper _mapper = mapper;
        protected Response _response = new();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Create([FromBody] DirectorioCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DirectorioDto directorio = _mapper.Map<DirectorioDto>(await _directorioRepo.Create(_mapper.Map<Directorio>(dto)));
                _response.Status = HttpStatusCode.Created;
                _response.IsExitoso = true;
                _response.Resultado = directorio;

                return Created("", _response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud."];
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
                IEnumerable<DirectorioDto> directorios = _mapper.Map<IEnumerable<DirectorioDto>>(await _directorioRepo.QueryAsync());
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = directorios;

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
        public async Task<ActionResult<Response>> Update(int id, [FromBody] DirectorioUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id != dto.Id)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["El identificador de directorio telefonico no es válido."];
                return BadRequest(_response);
            }

            try
            {
                var directorio = await _directorioRepo.GetAsync(e => e.Id == id, false);

                if (directorio == null)
                {
                    _response.Status = HttpStatusCode.BadRequest;
                    _response.ErrorMensajes = ["El directorio no existe."];
                    return BadRequest(_response);
                }

                await _directorioRepo.Update(_mapper.Map<Directorio>(dto));

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
                _response.ErrorMensajes = ["El identificador de directorio telefonico no es válido."];
                return BadRequest(_response);
            }

            try
            {
                var directorio = await _directorioRepo.GetAsync(e => e.Id == id, false);

                if (directorio == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Directorio no encontrado."];
                    return NotFound(_response);
                }

                await _directorioRepo.Delete(directorio);

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
        public async Task<ActionResult<Response>> GetById(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["El identificador de directorio telefonico no es válido."];
                return BadRequest(_response);
            }

            try
            {
                DirectorioDto directorio = _mapper.Map<DirectorioDto>(await _directorioRepo.GetAsync(e => e.Id == id, false));

                if (directorio == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = ["Directorio no encontrado."];
                    return NotFound(_response);
                }

                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = directorio;

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
