using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MedicalRecord_API.Controllers;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos;
using MedicalRecord_API.Repository.Interfaces;
using System.Net;
using MedicalRecord_API.Models.Dtos.Alergia;
using MedicalRecord_API.Utils.Response;

namespace MedicalRecord_API.Tests.Controllers
{
    public class AlergiaControllerTests
    {
        private readonly Mock<IAlergiaRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AlergiaController _controller;

        public AlergiaControllerTests()
        {
            _mockRepo = new Mock<IAlergiaRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AlergiaController(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task ModeloInvalidoRetornaSolicitudInvalida()
        {
            // Preparamos escenario
            _controller.ModelState.AddModelError("Test", "Test eror");

            // Ejecutamos una accion
            var result = await _controller.Create(new AlergiaCreateDto());

            // Verificamos la respuesta
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
