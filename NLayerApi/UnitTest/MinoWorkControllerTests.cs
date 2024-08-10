using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NLayerApi.Controllers;

namespace UnitTest
{
    public class MinorWorkControllerTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IMinorWorkService> _mockService;
        private readonly MinorWorkController _controller;

        public MinorWorkControllerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockService = new Mock<IMinorWorkService>();
            _controller = new MinorWorkController(_mockService.Object);
        }

        [Fact]
        public void AddMinorWork_ValidData_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var minorWorkDto = new MinorWorkDto { Description = "Test" };
            var minorWork = new MinorWork { Description = "Test" };
            var createdMinorWork = new MinorWork { MinorWorkId = Guid.NewGuid(), Description = "Test" };
            var createdMinorWorkDto = new MinorWorkDto { MinorWorkId = createdMinorWork.MinorWorkId, Description = "Test" };

            _mockMapper.Setup(m => m.Map<MinorWork>(minorWorkDto)).Returns(minorWork);
            _mockService.Setup(s => s.AddMinorWork(It.IsAny<MinorWorkDto>())).Returns(createdMinorWork);
            _mockMapper.Setup(m => m.Map<MinorWorkDto>(createdMinorWork)).Returns(createdMinorWorkDto);

            // Act
            var result = _controller.AddMinorWork(minorWorkDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedValue = Assert.IsType<MinorWork>(createdResult.Value);
            Assert.Equal(createdMinorWork.MinorWorkId, returnedValue.MinorWorkId);
        }

        [Fact]
        public void AddMinorWork_InvalidDateSequence_ReturnsBadRequest()
        {
            // Arrange
            var minorWorkDto = new MinorWorkDto
            {
                EnqReceivedDate = DateTime.Now,
                AuthorisedDate = DateTime.Now.AddDays(-1)
            };
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
            var minorWorkDto = new MinorWorkDto { MinorWorkId = minorWorkId };
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
                new MinorWorkDto { Description = "A" },
                new MinorWorkDto { Description = "B" }
            };
            _mockService.Setup(s => s.Gets(It.IsAny<string>())).Returns(minorWorkDtos);

            // Act
            var result = _controller.GetMinorWorks("asc");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedValue = Assert.IsType<List<MinorWorkDto>>(okResult.Value);
            Assert.Equal(2, returnedValue.Count);
        }

        [Fact]
        public void UpdateMinorWork_ValidData_ReturnsNoContent()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            var minorWorkDto = new MinorWorkDto { MinorWorkId = minorWorkId, Description = "Updated Description" };
            var existingMinorWork = new MinorWork();
            _mockService.Setup(s => s.Get(minorWorkId)).Returns(minorWorkDto);
            _mockMapper.Setup(m => m.Map(minorWorkDto, existingMinorWork)).Returns(existingMinorWork);

            // Act
            var result = _controller.UpdateMinorWork(minorWorkId, minorWorkDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateMinorWork_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            var minorWorkDto = new MinorWorkDto { MinorWorkId = Guid.NewGuid(), Description = "Updated Description" };

            // Act
            var result = _controller.UpdateMinorWork(minorWorkId, minorWorkDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("ID mismatch between URL and body", badRequestResult.Value.GetType().GetProperty("message").GetValue(badRequestResult.Value));
        }

        [Fact]
        public void UpdateMinorWork_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            var minorWorkDto = new MinorWorkDto { MinorWorkId = minorWorkId, Description = "Updated Description" };
            _mockService.Setup(s => s.Get(minorWorkId)).Returns((MinorWorkDto)null);

            // Act
            var result = _controller.UpdateMinorWork(minorWorkId, minorWorkDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Minor work not found", notFoundResult.Value.GetType().GetProperty("message").GetValue(notFoundResult.Value));
        }

        [Fact]
        public void DeleteMinorWork_ExistingId_ReturnsNoContent()
        {
            // Arrange
            var minorWorkId = Guid.NewGuid();
            var minorWorkDto = new MinorWorkDto { MinorWorkId = minorWorkId };
            _mockService.Setup(s => s.Get(minorWorkId)).Returns(minorWorkDto);

            // Act
            var result = _controller.DeleteMinorWork(minorWorkId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteMinorWork_NonExistingId_ReturnsNotFound()
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
