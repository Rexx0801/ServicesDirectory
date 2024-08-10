using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NLayerApi.Controllers;

namespace UnitTest
{
    public class MinorWorkControllerUiTests
    {
        private readonly Mock<IMinorWorkService> _mockService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MinorWorkController _controller;

        public MinorWorkControllerUiTests()
        {
            _mockService = new Mock<IMinorWorkService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new MinorWorkController(_mockService.Object);
        }
        /*
                [Fact]
                public void AddMinorWork_ValidData_ReturnsCreatedAtActionResult()
                {
                    // Arrange
                    var minorWorkDto = new MinorWorkDto { Description = "Test" };
                    var createdMinorWork = new MinorWork { MinorWorkId = Guid.NewGuid(), Description = "Test" };
                    _mockService.Setup(s => s.AddMinorWork(It.IsAny<MinorWorkDto>())).Returns(createdMinorWork);

                    // Act
                    var result = _controller.AddMinorWork(minorWorkDto);

                    // Assert
                    var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
                    var returnedValue = Assert.IsType<MinorWorkDto>(createdResult.Value);
                    Assert.Equal(createdMinorWork.MinorWorkId, returnedValue.MinorWorkId);
                }*/

        [Fact]
        public void AddMinorWork_InvalidData_ReturnsBadRequest()
        {
            // Arrange
            var minorWorkDto = new MinorWorkDto { Description = "Test" };
            _mockService.Setup(s => s.AddMinorWork(It.IsAny<MinorWorkDto>())).Throws(new ArgumentException("Invalid date sequence"));

            // Act
            var result = _controller.AddMinorWork(minorWorkDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var modelState = Assert.IsType<SerializableError>(badRequestResult.Value);
            Assert.True(modelState.ContainsKey("DateValidation"));
        }

        [Fact]
        public void GetMinorWork_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            var minorWorkDto = new MinorWorkDto { MinorWorkId = minorWorkId, Description = "Test" };
            _mockService.Setup(s => s.Get(minorWorkId)).Returns(minorWorkDto);

            // Act
            var result = _controller.GetMinorWork(minorWorkId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedValue = Assert.IsType<MinorWorkDto>(okResult.Value);
            Assert.Equal(minorWorkId, returnedValue.MinorWorkId);
        }

        [Fact]
        public void GetMinorWork_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            _mockService.Setup(s => s.Get(minorWorkId)).Returns((MinorWorkDto)null);

            // Act
            var result = _controller.GetMinorWork(minorWorkId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetMinorWorks_ReturnsOkResult()
        {
            // Arrange
            var minorWorkDtos = new List<MinorWorkDto>
            {
                new MinorWorkDto { Description = "Test 1" },
                new MinorWorkDto { Description = "Test 2" }
            };
            _mockService.Setup(s => s.Gets(It.IsAny<string>())).Returns(minorWorkDtos);

            // Act
            var result = _controller.GetMinorWorks(null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedValue = Assert.IsType<List<MinorWorkDto>>(okResult.Value);
            Assert.Equal(2, returnedValue.Count);
        }

        [Fact]
        public void UpdateMinorWork_ValidData_ReturnsNoContentResult()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            var minorWorkDto = new MinorWorkDto { MinorWorkId = minorWorkId, Description = "Updated Description" };
            _mockService.Setup(s => s.Get(minorWorkId)).Returns(minorWorkDto);

            // Act
            var result = _controller.UpdateMinorWork(minorWorkId, minorWorkDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockService.Verify(s => s.UpdateMinorWork(It.IsAny<MinorWorkDto>()), Times.Once);
        }
        /*
                [Fact]
                public void UpdateMinorWork_NonExistingId_ReturnsNotFoundResult()
                {
                    // Arrange
                    var minorWorkId = Guid.NewGuid();
                    var minorWorkDto = new MinorWorkDto { MinorWorkId = minorWorkId, Description = "Updated Description" };
                    _mockService.Setup(s => s.Get(minorWorkId)).Returns((MinorWorkDto)null);

                    // Act
                    var result = _controller.UpdateMinorWork(minorWorkId, minorWorkDto);

                    // Assert
                    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                    var errorMessage = Assert.IsType<Dictionary<string, string>>(notFoundResult.Value);
                    Assert.Equal("Minor work not found", errorMessage["message"]);
                }
        */
        [Fact]
        public void DeleteMinorWork_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            var minorWorkDto = new MinorWorkDto { MinorWorkId = minorWorkId, Description = "Test" };
            _mockService.Setup(s => s.Get(minorWorkId)).Returns(minorWorkDto);

            // Act
            var result = _controller.DeleteMinorWork(minorWorkId);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockService.Verify(s => s.DeleteMinorWork(minorWorkId), Times.Once);
        }

        [Fact]
        public void DeleteMinorWork_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            _mockService.Setup(s => s.Get(minorWorkId)).Returns((MinorWorkDto)null);

            // Act
            var result = _controller.DeleteMinorWork(minorWorkId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
