using BusinessLayer.Interfaces;
using Common.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NLayerApi.Controllers;

namespace UnitTest
{
    public class FacilityControllerTests
    {
        private readonly Mock<IFacilityService> _facilityServiceMock;
        private readonly FacilityController _controller;

        public FacilityControllerTests()
        {
            _facilityServiceMock = new Mock<IFacilityService>();
            _controller = new FacilityController(_facilityServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithFacilities()
        {
            // Arrange
            var facilityDtos = new List<FacilityDto> { new FacilityDto { FacilityId = Guid.NewGuid() } };

            _facilityServiceMock.Setup(service => service.GetAllFacilitiesAsync(null, null))
                .ReturnsAsync(facilityDtos);

            // Act
            var result = await _controller.GetAll(null, null);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeEquivalentTo(facilityDtos);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithEmptyList()
        {
            // Arrange
            var facilityDtos = new List<FacilityDto>();

            _facilityServiceMock.Setup(service => service.GetAllFacilitiesAsync(null, null))
                .ReturnsAsync(facilityDtos);

            // Act
            var result = await _controller.GetAll(null, null);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeEquivalentTo(facilityDtos);
        }
        [Fact]

        public async Task GetAll_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            _facilityServiceMock.Setup(service => service.GetAllFacilitiesAsync(null, null))
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetAll(null, null);

            // Assert
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.Should().NotBeNull();
            statusCodeResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkWithFacility()
        {
            // Arrange
            var facilityId = Guid.NewGuid();
            var facilityDto = new FacilityDto { FacilityId = facilityId };

            _facilityServiceMock.Setup(service => service.GetFacilityByIdAsync(facilityId))
                .ReturnsAsync(facilityDto);

            // Act
            var result = await _controller.GetById(facilityId);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeEquivalentTo(facilityDto);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var facilityDto = new FacilityDto { FacilityId = Guid.NewGuid() };

            // Act
            var result = await _controller.Create(facilityDto);

            // Assert
            var createdAtActionResult = result as CreatedAtActionResult;
            createdAtActionResult.Should().NotBeNull();
            createdAtActionResult.Value.Should().Be(facilityDto);
        }

        [Fact]
        public async Task Update_ShouldReturnNoContent()
        {
            // Arrange
            var facilityId = Guid.NewGuid();
            var facilityDto = new FacilityDto { FacilityId = facilityId };

            // Act
            var result = await _controller.Update(facilityId, facilityDto);

            // Assert
            var noContentResult = result as NoContentResult;
            noContentResult.Should().NotBeNull();
        }

        [Fact]
        public async Task MarkAsInactive_ShouldReturnNoContent()
        {
            // Arrange
            var facilityId = Guid.NewGuid();

            // Act
            var result = await _controller.MarkAsInactive(facilityId);

            // Assert
            var noContentResult = result as NoContentResult;
            noContentResult.Should().NotBeNull();
        }
    }
}
