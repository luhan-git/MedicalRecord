using AutoMapper;
using MedicalRecord_API.Models.Dtos.Auth;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IMapper _mapper;
        internal Response _response;
        public AuthController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _response = new();
        }
        [HttpPost()]
        public async Task<ActionResult<Response>> Auth([FromBody] AuthRequest auth)
        {
            AuthResponse authResponse = await _service.RetunrAuth(auth);
            if (!authResponse.IsSuccess)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ["username o password es incorrecto"];
                return BadRequest(_response);
            }

            _response.IsSuccess = true;
            _response.Result = authResponse;
            return Ok(_response);
        }
    }
}