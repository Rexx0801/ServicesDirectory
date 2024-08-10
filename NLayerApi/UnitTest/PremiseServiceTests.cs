using AutoMapper;
using BusinessLayer.Services;
using Common.Dto;
using DataAccess.Entities;
using DataAccess.Repositories;
using Moq;


namespace UnitTest
{
    public class PremiseServiceTests
    {
        private readonly Mock<IPremiseRepository> _mockRepository;
        private readonly IMapper _mapper;
        private readonly PremiseService _service;

        public PremiseServiceTests()
        {
            _mockRepository = new Mock<IPremiseRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Premise, PremiseDto>();
            });
            _mapper = config.CreateMapper();

            _service = new PremiseService(_mapper, _mockRepository.Object);
        }

        [Fact]
        public void GetPremises_ShouldReturnPremises()
        {
            // Arrange
            var premises = new List<Premise>
        {
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1", IsActive = true },
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2", IsActive = false }
        };
            _mockRepository.Setup(repo => repo.GetPremises(It.IsAny<bool>(), It.IsAny<string>())).Returns(premises);

            // Act
            var result = _service.GetPremises(true, "");

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetPremiseById_ShouldReturnPremise_WhenPremiseExists()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            var premise = new Premise { PremiseId = premiseId, PremiseName = "Test Premise" };
            _mockRepository.Setup(repo => repo.GetPremiseById(premiseId)).Returns(premise);

            // Act
            var result = _service.GetPremiseById(premiseId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(premiseId, result.PremiseId);
            Assert.Equal("Test Premise", result.PremiseName);
        }

        [Fact]
        public void GetPremiseById_ShouldReturnNull_WhenPremiseDoesNotExist()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.GetPremiseById(premiseId)).Returns((Premise)null);

            // Act
            var result = _service.GetPremiseById(premiseId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ActivatePremise_ShouldReturnTrue_WhenPremiseIsActivated()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            var premise = new Premise { PremiseId = premiseId, IsActive = false };
            _mockRepository.Setup(repo => repo.GetPremiseById(premiseId)).Returns(premise);

            // Act
            var result = _service.ActivatePremise(premiseId);

            // Assert
            Assert.True(result);
            Assert.True(premise.IsActive);
        }

        [Fact]
        public void ActivatePremise_ShouldReturnFalse_WhenPremiseDoesNotExistOrAlreadyActive()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.GetPremiseById(premiseId)).Returns((Premise)null);

            // Act
            var result = _service.ActivatePremise(premiseId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeactivatePremise_ShouldReturnTrue_WhenPremiseIsDeactivated()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            var premise = new Premise { PremiseId = premiseId, IsActive = true };
            _mockRepository.Setup(repo => repo.GetPremiseById(premiseId)).Returns(premise);

            // Act
            var result = _service.DeactivatePremise(premiseId);

            // Assert
            Assert.True(result);
            Assert.False(premise.IsActive);
        }

        [Fact]
        public void DeactivatePremise_ShouldReturnFalse_WhenPremiseDoesNotExistOrAlreadyInactive()
        {
            // Arrange
            var premiseId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.GetPremiseById(premiseId)).Returns((Premise)null);

            // Act
            var result = _service.DeactivatePremise(premiseId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetNewPremises_ShouldReturnNewPremises()
        {
            // Arrange
            var premises = new List<Premise>
        {
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1", IsActive = true, ShopFlagDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30)) },
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2", IsActive = true, ShopFlagDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-90)) }
        };
            _mockRepository.Setup(repo => repo.GetNewPremises()).Returns(premises);

            // Act
            var result = _service.GetNewPremises();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void FilterPremises_ShouldReturnFilteredPremises()
        {
            // Arrange
            var premises = new List<Premise>
        {
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1", IsActive = true },
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2", IsActive = false }
        };
            _mockRepository.Setup(repo => repo.FilterPremises(It.IsAny<string>())).Returns(premises);

            // Act
            var result = _service.FilterPremises("filter");

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void SortPremises_ShouldReturnSortedPremises()
        {
            // Arrange
            var premises = new List<Premise>
        {
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1", IsActive = true },
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2", IsActive = false }
        };
            _mockRepository.Setup(repo => repo.SortPremises(It.IsAny<string>())).Returns(premises);

            // Act
            var result = _service.SortPremises("Name");

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAllPremises_ShouldReturnAllPremises()
        {
            // Arrange
            var premises = new List<Premise>
        {
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 1", IsActive = true },
            new Premise { PremiseId = Guid.NewGuid(), PremiseName = "Premise 2", IsActive = false }
        };
            _mockRepository.Setup(repo => repo.GetAllPremises(It.IsAny<bool>())).Returns(premises);

            // Act
            var result = _service.GetAllPremises(true);

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}
