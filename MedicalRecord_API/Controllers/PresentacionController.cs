//using AutoMapper;
//using MedicalRecord_API.Models;
//using MedicalRecord_API.Models.Dtos.Presentacion;
//using MedicalRecord_API.Services.Interfaces;
//using MedicalRecord_API.Utils.Response;
//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace MedicalRecord_API.Controllers
//{
//    [Route("api/[controller]")]
//    // [Authorize(Roles = "admin")]
//    [ApiController]
//    public class PresentacionController : ControllerBase
//    {
//        private readonly IPresentacionService _service;
//        private readonly IMapper _mapper;
//        protected Response _response;

//        public PresentacionController(IPresentacionService service, IMapper mapper)
//        {
//            _service = service;
//            _mapper = mapper;
//            _response = new();
//        }

//        [HttpGet]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<Response>> Get()
//        {
//            try
//            {
//                IEnumerable<PresentacionDto> presentacionList = _mapper.Map<IEnumerable<PresentacionDto>>(await _service.QueryAsync());
//                _response.Result = presentacionList;
//                _response.IsSuccess = true;
//                _response.Status = HttpStatusCode.OK;
//                return Ok(_response);
//            }
//            catch
//            {
//                _response.Status = HttpStatusCode.InternalServerError;
//                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
//                return StatusCode(StatusCodes.Status500InternalServerError, _response);
//            }
//        }
//        [HttpGet("{Id:int}", Name = "GetPresentacion")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<Response>> GetById(int Id)
//        {

//            if (Id < 1)
//            {
//                _response.Status = HttpStatusCode.BadRequest;
//                _response.ErrorMessages = ["id: argumento no puede ser 0"];
//                return BadRequest(_response);
//            }
//            try
//            {
//                PresentacionDto dto = _mapper.Map<PresentacionDto>(await _service.GetAsync(p => p.Id == Id, false));
//                if (dto == null)
//                {
//                    _response.Status = HttpStatusCode.NotFound;
//                    _response.ErrorMessages = [" modelo: no esxiste en la base de datos"];
//                    return NotFound(_response);
//                }
//                _response.Status = HttpStatusCode.OK;
//                _response.IsSuccess = true;
//                _response.Result = dto;
//                return Ok(_response);
//            }
//            catch
//            {
//                _response.Status = HttpStatusCode.InternalServerError;
//                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
//                return StatusCode(StatusCodes.Status500InternalServerError, _response);
//            }
//        }
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<Response>> Create([FromBody] PresentacionCreateDto dto)
//        {
//            if (dto == null)
//            {
//                _response.ErrorMessages = ["modelo: no puede ser null"];
//                _response.Status = HttpStatusCode.BadRequest;
//                return BadRequest(_response);
//            };
//            try
//            {

//                Presentacion modelo = await _service.Create(_mapper.Map<Presentacion>(dto));
//                modelo = _mapper.Map<Presentacion>(modelo);
//                _response.Result = _mapper.Map<PresentacionCreateDto>(modelo);
//                _response.IsSuccess = true;
//                _response.Status = HttpStatusCode.Created;
//                return CreatedAtRoute("GetPresentacion", new { id = modelo.Id }, _response);
//            }
//            catch (Exception ex)
//            {
//                _response.Status = HttpStatusCode.InternalServerError;
//                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud", ex.ToString()];
//                return StatusCode(StatusCodes.Status500InternalServerError, _response);
//            }

//        }
//        [HttpPut("{id:int}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<IActionResult> Update(int id, [FromBody] PresentacionUpdateDto dto)
//        {

//            if (id < 1)
//            {
//                _response.Status = HttpStatusCode.BadRequest;
//                _response.ErrorMessages = ["id: argumento no puede ser 0"];
//                return BadRequest(_response);
//            }
//            if (dto == null)
//            {
//                _response.Status = HttpStatusCode.BadRequest;
//                _response.ErrorMessages = ["modelo: no puede ser null"];
//                return BadRequest(_response);
//            }
//            if (dto.Id != id)
//            {
//                _response.Status = HttpStatusCode.BadRequest;
//                _response.ErrorMessages = ["id: argumento id & modelo.id no pueden ser diferenes"];
//                return BadRequest(_response);
//            }
//            try
//            {
//                if (await _service.GetAsync(c => c.Id == id, false) == null)
//                {
//                    _response.Status = HttpStatusCode.NotFound;
//                    _response.ErrorMessages = ["modelo: no esxiste en la base de datos"];
//                    return BadRequest(_response);
//                }
//                if (await _service.GetAsync(c => string.Equals(c.Nombre, dto.Nombre), false) != null)
//                {
//                    _response.ErrorMessages = ["El Presentacion con este Nombre ya existe"];
//                    return BadRequest(_response);
//                }
//                await _service.Update(_mapper.Map<Presentacion>(dto));
//                _response.Status = HttpStatusCode.NoContent;
//                _response.IsSuccess = true;
//                return Ok(_response);
//            }
//            catch
//            {
//                _response.Status = HttpStatusCode.InternalServerError;
//                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud"];
//                return StatusCode(StatusCodes.Status500InternalServerError, _response);
//            }
//        }
//        [HttpDelete("{id:int}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            if (id < 1)
//            {
//                _response.Status = HttpStatusCode.BadRequest;
//                _response.ErrorMessages = ["id: argumento no puede ser 0"];
//                BadRequest(_response);
//            };
//            try
//            {
//                Presentacion presentacion = await _service.GetAsync(u => u.Id == id, false);
//                if (presentacion == null)
//                {
//                    _response.Status = HttpStatusCode.NotFound;
//                    _response.ErrorMessages = ["modelo: no esxiste en la base de datos"];
//                    return NotFound(_response);
//                }
//                await _service.Delete(presentacion);
//                _response.Status = HttpStatusCode.NoContent;
//                _response.IsSuccess = true;
//                return Ok(_response);
//            }
//            catch
//            {
//                _response.Status = HttpStatusCode.InternalServerError;
//                _response.ErrorMessages = ["Ocurrió un error al procesar la solicitud."];
//                return StatusCode(StatusCodes.Status500InternalServerError, _response);
//            }
//        }

//    }
//}
