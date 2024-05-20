using AutoMapper;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalRecord_API.Utils.Response;
using MedicalRecord_API.Models.Dtos.CiaSeguro;
using MedicalRecord_API.Models;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiaSeguroController : ControllerBase
    {
        private readonly ICiaSeguroRepository _ciaRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CiaSeguroController> _logger;
        protected Response _response;

        public CiaSeguroController(
            ICiaSeguroRepository ciaRepo,
            IMapper mapper,
            ILogger<CiaSeguroController> logger)
        {
            _ciaRepo = ciaRepo;
            _mapper = mapper;
            _logger = logger;
            _response = new Response();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Create([FromBody] CiaSeguroCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    IsExitoso = false,
                    ErrorMensajes = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                });
            }

            try
            {
                var cia = _mapper.Map<Ciaseguro>(dto);
                cia = await _ciaRepo.Create(cia);

                return Created("", new Response
                {
                    Status = HttpStatusCode.Created,
                    IsExitoso = true,
                    Resultado = cia
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al intentar crear cia de seguro: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = HttpStatusCode.InternalServerError,
                    IsExitoso = false,
                    ErrorMensajes = new List<string> { "Ocurrió un error al procesar la solicitud." }
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> Update([FromBody] CiaSeguroUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    IsExitoso = false,
                    ErrorMensajes = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                });
            }

            try
            {
                var cia = _mapper.Map<Ciaseguro>(dto);
                cia = await _ciaRepo.Update(cia);

                return Ok(new Response
                {
                    Status = HttpStatusCode.OK,
                    IsExitoso = true,
                    Resultado = cia
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al intentar actualizar cia de seguro: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = HttpStatusCode.InternalServerError,
                    IsExitoso = false,
                    ErrorMensajes = new List<string> { "Ocurrió un error al procesar la solicitud." }
                });
            }
        }

    }
}
