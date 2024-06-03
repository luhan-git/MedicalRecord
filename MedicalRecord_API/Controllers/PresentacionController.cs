using AutoMapper;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.Presentacion;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Roles = "admin")]
    [ApiController]
    public class PresentacionController:ControllerBase
    {
        private readonly IPresentacionService _service;
        private readonly IMapper _mapper;
        protected Response _response;

        public PresentacionController(IPresentacionService service,IMapper mapper)
        {
            _service=service;
            _mapper=mapper;
            _response=new();
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> Get()
        {
            try
            {
                IEnumerable<PresentacionDto> presentacionList = _mapper.Map<IEnumerable<PresentacionDto>>(await _service.QueryAsync());
                _response.Resultado = presentacionList;
                _response.IsExitoso = true;
                _response.Status = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
        [HttpGet("{Id:int}", Name = "GetPresentacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> GetById(int Id)
        {

            if (Id < 1)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMensajes = ["id: argumento no puede ser 0"];
                return BadRequest(_response);
            }
            try
            {
                PresentacionDto dto = _mapper.Map<PresentacionDto>(await _service.GetAsync(p => p.Id == Id, false));
                if (dto == null)
                {
                    _response.Status = HttpStatusCode.NotFound;
                    _response.ErrorMensajes = [" modelo: no esxiste en la base de datos"];
                    return NotFound(_response);
                }
                _response.Status = HttpStatusCode.OK;
                _response.IsExitoso = true;
                _response.Resultado = dto;
                return Ok(_response);
            }
            catch
            {
                _response.Status = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = ["Ocurrió un error al procesar la solicitud"];
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
