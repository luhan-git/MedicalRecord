using AutoMapper;
using MedicalRecord_API.Models.Dtos.Laboratorio;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalRecord_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaboratorioController : ControllerBase
    {
        private readonly ILaboratorioRepository _laboratorioRepo;
        private readonly IMapper _mapper;
        internal Response _response;
        public LaboratorioController(ILaboratorioRepository laboratorioRepo, IMapper mapper)
        {
            _laboratorioRepo = laboratorioRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        public async Task<ActionResult<Response>> Laboratorios()
        {
            try
            {
                IEnumerable<LaboratorioDto> listLaboratorio = _mapper.Map<IEnumerable<LaboratorioDto>>(await _laboratorioRepo.QueryAsync());
                _response.Result = listLaboratorio;
                _response.Status = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = [ex.ToString()];
                _response.Status = HttpStatusCode.InternalServerError;
                return _response;
            }
        }

    }
}