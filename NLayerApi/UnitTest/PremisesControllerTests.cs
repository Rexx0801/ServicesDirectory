using BusinessLayer.Interfaces;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NLayerApi.Controllers;

namespace UnitTest
{

    public class PremisesControllerTests
    {
        private readonly Mock<IPremiseService> _mockService;
        private readonly PremisesController _controller;

        public PremisesControllerTests()
        {
            _mockService = new Mock<IPremiseService>();
            _controller = new PremisesController(_mockService.Object);
        }

        [Fact]
        public void GetPremises_ShouldReturnOkResult_WithPremises()
        {
            // Arrange
            var premises = new List<PremiseDto>
        {
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1" },
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2" }
        };
            _mockService.Setup(service => service.GetPremises(It.IsAny<bool>(), It.IsAny<string>())).Returns(premises);

            // Act
            var result = _controller.GetPremises(false, "");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PremiseDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void GetPremiseDetails_ShouldReturnOkResult_WithPremise()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            var premise = new PremiseDto { PremiseId = premiseId, PremiseName = "Test Premise" };
            _mockService.Setup(service => service.GetPremiseById(premiseId)).Returns(premise);

            // Act
            var result = _controller.GetPremiseDetails(premiseId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PremiseDto>(okResult.Value);
            Assert.Equal(premiseId, returnValue.PremiseId);
        }

        [Fact]
        public void GetPremiseDetails_ShouldReturnNotFound_WhenPremiseDoesNotExist()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockService.Setup(service => service.GetPremiseById(premiseId)).Returns((PremiseDto)null);

            // Act
            var result = _controller.GetPremiseDetails(premiseId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ActivatePremise_ShouldReturnOkResult_WhenActivationIsSuccessful()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockService.Setup(service => service.ActivatePremise(premiseId)).Returns(true);

            // Act
            var result = _controller.ActivatePremise(premiseId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void ActivatePremise_ShouldReturnBadRequest_WhenActivationFails()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockService.Setup(service => service.ActivatePremise(premiseId)).Returns(false);

            // Act
            var result = _controller.ActivatePremise(premiseId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Unable to activate premise.", badRequestResult.Value);
        }

        [Fact]
        public void DeactivatePremise_ShouldReturnOkResult_WhenDeactivationIsSuccessful()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockService.Setup(service => service.DeactivatePremise(premiseId)).Returns(true);

            // Act
            var result = _controller.DeactivatePremise(premiseId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeactivatePremise_ShouldReturnBadRequest_WhenDeactivationFails()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockService.Setup(service => service.DeactivatePremise(premiseId)).Returns(false);

            // Act
            var result = _controller.DeactivatePremise(premiseId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Unable to deactivate premise.", badRequestResult.Value);
        }

        [Fact]
        public void FilterPremises_ShouldReturnOkResult_WithFilteredPremises()
        {
            // Arrange
            var premises = new List<PremiseDto>
        {
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1" },
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2" }
        };
            _mockService.Setup(service => service.FilterPremises(It.IsAny<string>())).Returns(premises);

            // Act
            var result = _controller.FilterPremises("filter");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PremiseDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void SortPremises_ShouldReturnOkResult_WithSortedPremises()
        {
            // Arrange
            var premises = new List<PremiseDto>
        {
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1" },
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2" }
        };
            _mockService.Setup(service => service.SortPremises(It.IsAny<string>())).Returns(premises);

            // Act
            var result = _controller.SortPremises("columnName");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PremiseDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void GetNewPremises_ShouldReturnOkResult_WithNewPremises()
        {
            // Arrange
            var premises = new List<PremiseDto>
        {
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1" },
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2" }
        };
            _mockService.Setup(service => service.GetNewPremises()).Returns(premises);

            // Act
            var result = _controller.GetNewPremises();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PremiseDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void IncludeInactivePremises_ShouldReturnOkResult_WithAllPremises()
        {
            // Arrange
            var premises = new List<PremiseDto>
        {
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1" },
            new PremiseDto { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2" }
        };
            _mockService.Setup(service => service.GetAllPremises(true)).Returns(premises);

            // Act
            var result = _controller.IncludeInactivePremises();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PremiseDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void HandleInactivePremise_ShouldActivatePremise_WhenActivateIsTrue()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockService.Setup(service => service.ActivatePremise(premiseId)).Returns(true);

            // Act
            var result = _controller.HandleInactivePremise(premiseId, true);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void HandleInactivePremise_ShouldDeactivatePremise_WhenActivateIsFalse()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockService.Setup(service => service.DeactivatePremise(premiseId)).Returns(true);

            // Act
            var result = _controller.HandleInactivePremise(premiseId, false);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
