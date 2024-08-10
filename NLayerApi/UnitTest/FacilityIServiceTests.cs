using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using DataAccess.Entities;
using DataAccess.Repositories;
using FluentAssertions;
using Moq;
namespace UnitTest
{
    public class FacilityIServiceTests
    {
        private readonly Mock<IFacilityRepository> _facilityRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IFacilityService _facilityService;

        public FacilityIServiceTests()
        {
            _facilityRepositoryMock = new Mock<IFacilityRepository>();
            _mapperMock = new Mock<IMapper>();
            _facilityService = new FacilityIService(_facilityRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllFacilitiesAsync_ShouldReturnMappedFacilities()
        {
            // Arrange
            var facilities = new List<Facility> { new Facility { FacilityId = Guid.NewGuid() } };
            var facilityDtos = new List<FacilityDto> { new FacilityDto { FacilityId = Guid.NewGuid() } };

            _facilityRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(facilities);
            _mapperMock.Setup(m => m.Map<IEnumerable<FacilityDto>>(facilities)).Returns(facilityDtos);

            // Act
            var result = await _facilityService.GetAllFacilitiesAsync(null, null);

            // Assert
            result.Should().BeEquivalentTo(facilityDtos);
        }

        [Fact]
        public async Task GetFacilityByIdAsync_ShouldReturnMappedFacility()
        {
            // Arrange
            var facilityId = Guid.NewGuid();
            var facility = new Facility { FacilityId = facilityId };
            var facilityDto = new FacilityDto { FacilityId = facilityId };

            _facilityRepositoryMock.Setup(repo => repo.GetByIdAsync(facilityId)).ReturnsAsync(facility);
            _mapperMock.Setup(m => m.Map<FacilityDto>(facility)).Returns(facilityDto);

            // Act
            var result = await _facilityService.GetFacilityByIdAsync(facilityId);

            // Assert
            result.Should().BeEquivalentTo(facilityDto);
        }

        [Fact]
        public async Task AddFacilityAsync_ShouldCallRepositoryWithMappedEntity()
        {
            // Arrange
            var facilityDto = new FacilityDto { FacilityId = Guid.NewGuid() };
            var facility = new Facility { FacilityId = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Facility>(facilityDto)).Returns(facility);

            // Act
            await _facilityService.AddFacilityAsync(facilityDto);

            // Assert
            _facilityRepositoryMock.Verify(repo => repo.AddAsync(facility), Times.Once);
        }

        [Fact]
        public async Task UpdateFacilityAsync_ShouldCallRepositoryWithMappedEntity()
        {
            // Arrange
            var facilityDto = new FacilityDto { FacilityId = Guid.NewGuid() };
            var facility = new Facility { FacilityId = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Facility>(facilityDto)).Returns(facility);

            // Act
            await _facilityService.UpdateFacilityAsync(facilityDto);

            // Assert
            _facilityRepositoryMock.Verify(repo => repo.UpdateAsync(facility), Times.Once);
        }

        [Fact]
        public async Task MarkFacilityAsInactiveAsync_ShouldUpdateFacilityIsActiveStatus()
        {
            // Arrange
            var facilityId = Guid.NewGuid();
            var facility = new Facility { FacilityId = facilityId, IsActive = true };

            _facilityRepositoryMock.Setup(repo => repo.GetByIdAsync(facilityId)).ReturnsAsync(facility);

            // Act
            await _facilityService.MarkFacilityAsInactiveAsync(facilityId);

            // Assert
            facility.IsActive.Should().BeFalse();
            _facilityRepositoryMock.Verify(repo => repo.UpdateAsync(facility), Times.Once);
        }
    }

}