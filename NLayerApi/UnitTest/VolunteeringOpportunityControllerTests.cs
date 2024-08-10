using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NLayerApi.Controllers;
using Assert = Xunit.Assert;

namespace UnitTest
{
    public class VolunteeringOpportunityControllerTests
    {
        private readonly Mock<IVolunteeringService> _mockService;
        private readonly VolunteerController _controller;
        private readonly Mock<IMapper> _mockMapper;

        public VolunteeringOpportunityControllerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockService = new Mock<IVolunteeringService>();
            _controller = new VolunteerController(_mockService.Object);
        }

        /* [Fact]
         public void AddVolunteer_ShouldReturnCreated_WhenSuccessful()
         {
             // Arrange
             var volunteerDto = new VolunteeringDto
             {
                 VolunteeringId = Guid.NewGuid(),
                 VolunteeringContact = "Contact",
                 VolunteeringPurpose = "Purpose",
                 VolunteeringOpportunityDetails = "Details",
                 StartDate = DateTime.Now,
                 EndDate = DateTime.Now.AddMonths(1),
                 VolunteerNos = 10,
                 IsActive = true,
                 PremiseId = Guid.NewGuid()
             };
             var volunteeringEntity = new Volunteering
             {
                 VolunteeringId = volunteerDto.VolunteeringId
             };
             _mockService.Setup(s => s.AddVolunteering(volunteerDto)).Returns(volunteeringEntity);

             // Mock AutoMapper to map from entity to DTO
             _mockMapper.Setup(m => m.Map<VolunteeringDto>(volunteeringEntity)).Returns(volunteerDto);

             // Act
             var result = _controller.AddVolunteer(volunteerDto);

             // Assert
             Assert.NotNull(result);
             Assert.Equal(volunteerDto, result.Value);
         }
 */
        /* [Fact]
         public void GetVolunteer_ShouldReturnOk_WhenVolunteerExists()
         {
             // Arrange
             var volunteerId = Guid.NewGuid();
             var volunteerDto = new VolunteeringDto { VolunteeringId = volunteerId };

             _mockService.Setup(service => service.Get(volunteerId))
                 .Returns(volunteerDto);

             // Act
             var result = _controller.GetVolunteer(volunteerId);

             // Assert
             Assert.NotNull(result);
             Assert.Equal(volunteerDto, result.Value);
         }

         [Fact]
         public void GetVolunteer_ShouldReturnNotFound_WhenVolunteerDoesNotExist()
         {
             // Arrange
             var volunteerId = Guid.NewGuid();

             _mockService.Setup(service => service.Get(volunteerId))
                 .Returns((VolunteeringDto)null);

             // Act
             var result = _controller.GetVolunteer(volunteerId);

             // Assert
             Assert.NotNull(result);
         }

         [Fact]
         public void GetVolunteers_ShouldReturnOk_WhenVolunteersExist()
         {
             // Arrange
             var volunteers = new List<VolunteeringDto>
     {
         new VolunteeringDto { VolunteeringId = Guid.NewGuid() },
         new VolunteeringDto { VolunteeringId = Guid.NewGuid() }
     };

             _mockService.Setup(service => service.Gets())
                 .Returns(volunteers);

             // Act
             var result = _controller.GetVolunteers();

             // Assert
             Assert.NotNull(result);
             Assert.Equal(volunteers, result.Value);
         }*/

        [Fact]
        public void UpdateVolunteer_ShouldReturnNoContent_WhenUpdateSuccessful()
        {
            // Arrange
            var volunteerId = Guid.NewGuid();
            var volunteerDto = new VolunteeringDto { VolunteeringId = volunteerId };
            var existingVolunteer = new VolunteeringDto { VolunteeringId = volunteerId };

            _mockService.Setup(service => service.Get(volunteerId))
                .Returns(existingVolunteer);
            _mockService.Setup(service => service.UpdateVolunteering(It.IsAny<VolunteeringDto>()))
                .Verifiable();

            // Act
            var result = _controller.UpdateVolunteer(volunteerId, volunteerDto) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
            _mockService.Verify();
        }

        /*  [Fact]
          public void UpdateVolunteer_ShouldReturnBadRequest_WhenIdMismatch()
          {
              // Arrange
              var volunteerId = Guid.NewGuid();
              var volunteerDto = new VolunteeringDto { VolunteeringId = Guid.NewGuid() };

              // Act
              var result = _controller.UpdateVolunteer(volunteerId, volunteerDto) as BadRequestObjectResult;

              // Assert
              Assert.NotNull(result);
              Assert.Equal(400, result.StatusCode);
              Assert.Equal("ID mismatch between URL and body", result.Value);
          }*/

        /*  [Fact]
          public void UpdateVolunteer_ShouldReturnNotFound_WhenVolunteerNotFound()
          {
              // Arrange
              var volunteerId = Guid.NewGuid();
              var volunteerDto = new VolunteeringDto { VolunteeringId = volunteerId };

              _mockService.Setup(service => service.Get(volunteerId))
                  .Returns((VolunteeringDto)null);

              // Act
              var result = _controller.UpdateVolunteer(volunteerId, volunteerDto) as NotFoundObjectResult;

              // Assert
              Assert.NotNull(result);
              Assert.Equal(404, result.StatusCode);
              Assert.Equal("Volunteer record not found", result.Value);
          }
  */
        [Fact]
        public void DeleteVolunteer_ShouldReturnNoContent_WhenDeleteSuccessful()
        {
            // Arrange
            var volunteerId = Guid.NewGuid();
            var volunteerDto = new VolunteeringDto { VolunteeringId = volunteerId };

            _mockService.Setup(service => service.Get(volunteerId))
                .Returns(volunteerDto);
            _mockService.Setup(service => service.DeleteVolunteering(volunteerId))
                .Verifiable();

            // Act
            var result = _controller.DeleteVolunteer(volunteerId) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
            _mockService.Verify();
        }

        [Fact]
        public void DeleteVolunteer_ShouldReturnNotFound_WhenVolunteerDoesNotExist()
        {
            // Arrange
            var volunteerId = Guid.NewGuid();

            _mockService.Setup(service => service.Get(volunteerId))
                .Returns((VolunteeringDto)null);

            // Act
            var result = _controller.DeleteVolunteer(volunteerId) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }
    }
}