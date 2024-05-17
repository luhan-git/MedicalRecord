using AutoMapper;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuariosController> _logger;
        protected Response _response;

        public UsuariosController(IMapper mapper, IUsuarioRepository usuarioRepo, ILogger<UsuariosController> logger)
        {
            _logger = logger;
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
            _response = new Response();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status102Processing)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetAll()
        {
            _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Handling GET_All request", StatusCodes.Status102Processing, HttpStatusCode.Processing);

            try
            {
                IEnumerable<UsuarioDto> usuarioList = _mapper.Map<IEnumerable<UsuarioDto>>(await _usuarioRepo.Query());
                _response.Resultado = usuarioList;
                _response.StatusCode = HttpStatusCode.OK;
                _logger.LogInformation("{StatusCode}[{HttpStatusCode}]: Request handled successfully", StatusCodes.Status200OK, HttpStatusCode.OK);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes =[ ex.ToString() ];
                _logger.LogError(ex, "{StatusCode}[{HttpStatusCode}]: Error handling GET_ALL request", StatusCodes.Status500InternalServerError, HttpStatusCode.InternalServerError);

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
