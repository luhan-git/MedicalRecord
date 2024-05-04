using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos;
using MedicalRecord_API.Repository.Implements;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : Controller
    {
        private readonly GenericRepository<Medico> _medicoRepo;
        private readonly IMapper _mapper;
        protected Response _response;
        public MedicoController(GenericRepository<Medico> medicoRepo, IMapper mapper)
        {
            _medicoRepo = medicoRepo;
            _mapper = mapper;
            _response= new();
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
            catch(Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
    }
}
