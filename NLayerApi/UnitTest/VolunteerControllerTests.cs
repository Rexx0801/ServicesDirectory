using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NLayerApi.Controllers;

namespace UnitTest;

public class VolunteerControllerTests
{
    private readonly Mock<IVolunteeringService> _mockService;
    private readonly VolunteerController _controller;
    private readonly Mock<IMapper> _mockMapper;

    public VolunteerControllerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockService = new Mock<IVolunteeringService>();
        _controller = new VolunteerController(_mockService.Object);
    }

    /* [Fact]
     public void AddVolunteer_ShouldReturnCreatedResponse()
     {
         // Arrange
         var volunteerDto = new VolunteeringDto
         {
             VolunteeringId = Guid.NewGuid()
         };
         var volunteeringEntity = new Volunteering
         {
             VolunteeringId = volunteerDto.VolunteeringId
         };

         _mockService.Setup(s => s.AddVolunteering(volunteerDto)).Returns(volunteeringEntity);

         _mockMapper.Setup(m => m.Map<VolunteeringDto>(volunteeringEntity)).Returns(volunteerDto);

         // Act
         var result = _controller.AddVolunteer(volunteerDto);

         // Assert
         result.Should().NotBeNull(); 
         result.Value.Should().BeEquivalentTo(volunteerDto);
     }*/


    /*  [Fact]
      public void AddVolunteer_ShouldReturnBadRequest_WhenValidationError()
      {
          // Arrange
          var volunteerDto = new VolunteeringDto();
          _mockService.Setup(s => s.AddVolunteering(volunteerDto)).Throws(new ArgumentException("Validation error"));

          // Act
          var result = _controller.AddVolunteer(volunteerDto);

          // Assert
          result.Should().NotBeNull();
          result.Value.Should().BeAssignableTo<SerializableError>();
      }

      [Fact]
      public void GetVolunteer_ShouldReturnOk_WhenFound()
      {
          // Arrange
          var volunteerId = Guid.NewGuid();
          var volunteerDto = new VolunteeringDto();

          _mockService.Setup(s => s.Get(volunteerId)).Returns(volunteerDto);

          // Act
          var result = _controller.GetVolunteer(volunteerId);

          // Assert
          result.Should().NotBeNull();
          result.Value.Should().BeEquivalentTo(volunteerDto);
      }*/

    [Fact]
    public void GetVolunteer_ShouldReturnNotFound_WhenNotFound()
    {
        // Arrange
        var volunteerId = Guid.NewGuid();
        _mockService.Setup(s => s.Get(volunteerId)).Returns((VolunteeringDto)null);

        // Act
        var result = _controller.GetVolunteer(volunteerId);

        // Assert
        result.Should().NotBeNull();
    }

    /*  [Fact]
      public void GetVolunteers_ShouldReturnOk()
      {
          // Arrange
          var volunteers = new List<VolunteeringDto>
          {
              new VolunteeringDto(),
              new VolunteeringDto()
          };

          _mockService.Setup(s => s.Gets()).Returns(volunteers);

          // Act
          var result = _controller.GetVolunteers();

          // Assert
          result.Should().NotBeNull();
          result.Value.Should().BeEquivalentTo(volunteers);
      }*/

    [Fact]
    public void UpdateVolunteer_ShouldReturnNoContent_WhenSuccessful()
    {
        // Arrange
        var volunteerId = Guid.NewGuid();
        var volunteerDto = new VolunteeringDto
        {
            VolunteeringId = volunteerId
        };
        _mockService.Setup(s => s.Get(volunteerId)).Returns(volunteerDto);

        // Act
        var result = _controller.UpdateVolunteer(volunteerId, volunteerDto) as NoContentResult;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(204);
    }

    [Fact]
    public void UpdateVolunteer_ShouldReturnBadRequest_WhenIdMismatch()
    {
        // Arrange
        var volunteerId = Guid.NewGuid();
        var volunteerDto = new VolunteeringDto
        {
            VolunteeringId = Guid.NewGuid()
        };

        // Act
        var result = _controller.UpdateVolunteer(volunteerId, volunteerDto) as BadRequestObjectResult;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(400);
        result.Value.Should().BeEquivalentTo(new { message = "ID mismatch between URL and body" });
    }

    [Fact]
    public void UpdateVolunteer_ShouldReturnNotFound_WhenNotFound()
    {
        // Arrange
        var volunteerId = Guid.NewGuid();
        var volunteerDto = new VolunteeringDto
        {
            VolunteeringId = volunteerId
        };
        _mockService.Setup(s => s.Get(volunteerId)).Returns((VolunteeringDto)null);

        // Act
        var result = _controller.UpdateVolunteer(volunteerId, volunteerDto) as NotFoundObjectResult;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(404);
        result.Value.Should().BeEquivalentTo(new { message = "Volunteer record not found" });
    }

    [Fact]
    public void DeleteVolunteer_ShouldReturnNoContent_WhenSuccessful()
    {
        // Arrange
        var volunteerId = Guid.NewGuid();
        var volunteerDto = new VolunteeringDto
        {
            VolunteeringId = volunteerId
        };
        _mockService.Setup(s => s.Get(volunteerId)).Returns(volunteerDto);

        // Act
        var result = _controller.DeleteVolunteer(volunteerId) as NoContentResult;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(204);
    }

    [Fact]
    public void DeleteVolunteer_ShouldReturnNotFound_WhenNotFound()
    {
        // Arrange
        var volunteerId = Guid.NewGuid();
        _mockService.Setup(s => s.Get(volunteerId)).Returns((VolunteeringDto)null);

        // Act
        var result = _controller.DeleteVolunteer(volunteerId) as NotFoundResult;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(404);
    }
}
