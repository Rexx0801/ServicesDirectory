using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using AutoMapper;
using FluentAssertions;
using BusinessLayer.Services;
using BusinessLayer.Interfaces;
using DataAccess.Entities;
using DataAccess.Data;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace UnitTest;

public class VolunteeringServiceTests
{
    private readonly Mock<Team04DbContext> _mockContext;
    private readonly Mock<IMapper> _mockMapper;
    private readonly VolunteeringService _service;

    public VolunteeringServiceTests()
    {
        _mockContext = new Mock<Team04DbContext>();
        _mockMapper = new Mock<IMapper>();
        _service = new VolunteeringService(_mockContext.Object, _mockMapper.Object);
    }

    private Mock<DbSet<T>> CreateMockDbSet<T>(IQueryable<T> data) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        return mockSet;
    }

    [Fact]
    public void AddVolunteering_ShouldAddSuccessfully()
    {
        // Arrange
        var volunteeringDto = new VolunteeringDto
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            IsActive = true
        };

        var volunteering = new Volunteering();
        _mockMapper.Setup(m => m.Map<Volunteering>(It.IsAny<VolunteeringDto>()))
            .Returns(volunteering);
        _mockContext.Setup(c => c.Volunteerings.Add(It.IsAny<Volunteering>()));
        _mockContext.Setup(c => c.SaveChanges());

        // Act
        var result = _service.AddVolunteering(volunteeringDto);

        // Assert
        result.Should().Be(volunteering);
        _mockContext.Verify(c => c.Volunteerings.Add(It.IsAny<Volunteering>()), Times.Once);
        _mockContext.Verify(c => c.SaveChanges(), Times.Once);
    }

    /*   [Fact]
       public void AddVolunteering_ShouldThrowException_WhenEndDateBeforeStartDate()
       {
           // Arrange
           var volunteeringDto = new VolunteeringDto
           {
               StartDate = DateTime.Now,
               EndDate = DateTime.Now.AddDays(-1)
           };

           // Act
           Action act = () => _service.AddVolunteering(volunteeringDto);

           // Assert
           act.Should().Throw<ArgumentException>().WithMessage("End date cannot be before start date");
       }

       [Fact]
       public void DeleteVolunteering_ShouldMarkAsInactive()
       {
           // Arrange
           var volunteeringId = Guid.NewGuid();
           var volunteering = new Volunteering { VolunteeringId = volunteeringId, IsActive = true };

           _mockContext.Setup(c => c.Volunteerings.SingleOrDefault(It.IsAny<Func<Volunteering, bool>>()))
               .Returns(volunteering);
           _mockContext.Setup(c => c.SaveChanges());

           // Act
           _service.DeleteVolunteering(volunteeringId);

           // Assert
           volunteering.IsActive.Should().BeFalse();
           _mockContext.Verify(c => c.SaveChanges(), Times.Once);
       }

       [Fact]
       public void DeleteVolunteering_ShouldThrowException_WhenNotFound()
       {
           // Arrange
           var volunteeringId = Guid.NewGuid();

           _mockContext.Setup(c => c.Volunteerings.SingleOrDefault(It.IsAny<Func<Volunteering, bool>>()))
               .Returns<Volunteering>(null);

           // Act
           Action act = () => _service.DeleteVolunteering(volunteeringId);

           // Assert
           act.Should().Throw<ArgumentException>().WithMessage("Volunteering opportunity not found");
       }*/

    [Fact]
    public void Get_ShouldReturnVolunteeringDto()
    {
        // Arrange
        var volunteeringId = Guid.NewGuid();
        var volunteering = new Volunteering { VolunteeringId = volunteeringId };
        var volunteeringDto = new VolunteeringDto();

        var data = new List<Volunteering> { volunteering }.AsQueryable();
        var mockSet = CreateMockDbSet(data);

        _mockContext.Setup(c => c.Volunteerings).Returns(mockSet.Object);
        _mockMapper.Setup(m => m.Map<VolunteeringDto>(volunteering)).Returns(volunteeringDto);

        // Act
        var result = _service.Get(volunteeringId);

        // Assert
        result.Should().Be(volunteeringDto);
    }

    [Fact]
    public void Gets_ShouldReturnActiveVolunteeringDtos()
    {
        // Arrange
        var volunteerings = new List<Volunteering>
        {
            new Volunteering { IsActive = true },
            new Volunteering { IsActive = false }
        }.AsQueryable();
        var volunteeringDtos = new List<VolunteeringDto>
        {
            new VolunteeringDto(),
            new VolunteeringDto()
        };

        var mockSet = CreateMockDbSet(volunteerings);
        _mockContext.Setup(c => c.Volunteerings).Returns(mockSet.Object);
        _mockMapper.Setup(m => m.Map<IEnumerable<VolunteeringDto>>(It.IsAny<IEnumerable<Volunteering>>()))
            .Returns(volunteeringDtos);

        // Act
        var result = _service.Gets();

        // Assert
        result.Should().BeEquivalentTo(volunteeringDtos);
    }

    [Fact]
    public void UpdateVolunteering_ShouldUpdateSuccessfully()
    {
        // Arrange
        var volunteeringDto = new VolunteeringDto
        {
            VolunteeringId = Guid.NewGuid(),
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            IsActive = true
        };
        var existingVolunteering = new Volunteering
        {
            VolunteeringId = volunteeringDto.VolunteeringId,
            IsActive = true
        };

        _mockContext.Setup(c => c.Volunteerings.Find(volunteeringDto.VolunteeringId))
            .Returns(existingVolunteering);
        _mockMapper.Setup(m => m.Map(volunteeringDto, existingVolunteering));
        _mockContext.Setup(c => c.Volunteerings.Update(existingVolunteering));
        _mockContext.Setup(c => c.SaveChanges());

        // Act
        _service.UpdateVolunteering(volunteeringDto);

        // Assert
        _mockContext.Verify(c => c.SaveChanges(), Times.Once);
    }

    /*   [Fact]
       public void UpdateVolunteering_ShouldThrowException_WhenEndDateBeforeStartDate()
       {
           // Arrange
           var volunteeringDto = new VolunteeringDto
           {
               StartDate = DateTime.Now,
               EndDate = DateTime.Now.AddDays(-1)
           };

           // Act
           Action act = () => _service.UpdateVolunteering(volunteeringDto);

           // Assert
           act.Should().Throw<ArgumentException>().WithMessage("End date cannot be before start date");
       }*/

    [Fact]
    public void UpdateVolunteering_ShouldNotUpdate_WhenNotFound()
    {
        // Arrange
        var volunteeringDto = new VolunteeringDto
        {
            VolunteeringId = Guid.NewGuid()
        };

        _mockContext.Setup(c => c.Volunteerings.Find(volunteeringDto.VolunteeringId))
            .Returns<Volunteering>(null);

        // Act
        _service.UpdateVolunteering(volunteeringDto);

        // Assert
        _mockContext.Verify(c => c.SaveChanges(), Times.Never);
    }
}