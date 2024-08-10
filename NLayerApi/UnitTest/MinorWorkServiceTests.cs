using AutoMapper;
using BusinessLayer.Services;
using Common.Dto;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTest
{
    public class MinorWorkServiceTests
    {
        private readonly Mock<Team04DbContext> _mockContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MinorWorkService _service;

        public MinorWorkServiceTests()
        {
            _mockContext = new Mock<Team04DbContext>();
            _mockMapper = new Mock<IMapper>();
            _service = new MinorWorkService(_mockContext.Object, _mockMapper.Object);
        }

        private Mock<DbSet<T>> CreateMockDbSet<T>(List<T> elements) where T : class
        {
            var queryable = elements.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();

            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>(elements.Add);
            dbSet.Setup(d => d.Update(It.IsAny<T>())).Callback<T>(t =>
            {
                var index = elements.FindIndex(e => e == t);
                if (index >= 0)
                {
                    elements[index] = t;
                }
            });

            return dbSet;
        }

        private MinorWorkDto CreateMinorWorkDto(MinorWork minorWork)
        {
            return new MinorWorkDto
            {
                MinorWorkId = minorWork.MinorWorkId,
                Description = minorWork.Description,
                IsMinorWorks = minorWork.IsMinorWorks,
                NotesActions = minorWork.NotesActions,
                EstimatedCost = minorWork.EstimatedCost,
                ActualCost = minorWork.ActualCost,
                Directorate = minorWork.Directorate,
                Contact = minorWork.Contact,
                AuthorisedByName = minorWork.AuthorisedByName,
                Status = minorWork.Status,
                EnqReceivedDate = minorWork.EnqReceivedDate,
                AuthorisedDate = minorWork.AuthorisedDate,
                ActualStartDate = minorWork.ActualStartDate,
                AnticipatedCompletion = minorWork.AnticipatedCompletion,
                ActualCompletionDate = minorWork.ActualCompletionDate,
                IsActive = minorWork.IsActive,
                PremiseId = minorWork.PremiseId
            };
        }

        private MinorWork CreateMinorWork(Guid id)
        {
            return new MinorWork
            {
                MinorWorkId = id,
                Description = "Test Description",
                IsMinorWorks = true,
                NotesActions = "Test Notes",
                EstimatedCost = 1000.00,
                ActualCost = 950.00,
                Directorate = "Test Directorate",
                Contact = "Test Contact",
                AuthorisedByName = "Test Authoriser",
                Status = true,
                EnqReceivedDate = DateTime.Now.AddDays(-10),
                AuthorisedDate = DateTime.Now.AddDays(-8),
                ActualStartDate = DateTime.Now.AddDays(-7),
                AnticipatedCompletion = DateTime.Now.AddDays(-3),
                ActualCompletionDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                PremiseId = Guid.NewGuid()
            };
        }

        [Fact]
        public void AddMinorWork_ValidData_ReturnsMinorWork()
        {
            var minorDto = CreateMinorWorkDto(CreateMinorWork(Guid.NewGuid()));
            var minorWork = CreateMinorWork(Guid.NewGuid());
            var minorWorks = new List<MinorWork>();
            var mockDbSet = CreateMockDbSet(minorWorks);

            _mockContext.Setup(m => m.MinorWorks).Returns(mockDbSet.Object);
            _mockMapper.Setup(m => m.Map<MinorWork>(minorDto)).Returns(minorWork);

            // Act
            var result = _service.AddMinorWork(minorDto);

            // Assert
            Assert.NotNull(result);
            mockDbSet.Verify(m => m.Add(It.IsAny<MinorWork>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void AddMinorWork_InvalidDate_ThrowsArgumentException()
        {
            var minorWorkDto = new MinorWorkDto
            {
                EnqReceivedDate = DateTime.Now,
                AuthorisedDate = DateTime.Now.AddDays(-1),
                ActualStartDate = DateTime.Now.AddDays(-2),
                ActualCompletionDate = DateTime.Now.AddDays(-3)
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _service.AddMinorWork(minorWorkDto));
            Assert.Equal("Invalid date sequence", ex.Message);
        }

        [Fact]
        public void DeleteMinorWork_ExistingId_SetsIsActiveToFalse()
        {
            var minorWorkId = Guid.NewGuid();
            var minorWork = CreateMinorWork(minorWorkId);
            var minorWorks = new List<MinorWork> { minorWork };
            var mockDbSet = CreateMockDbSet(minorWorks);

            _mockContext.Setup(m => m.MinorWorks).Returns(mockDbSet.Object);

            _service.DeleteMinorWork(minorWorkId);

            Assert.False(minorWork.IsActive);
            mockDbSet.Verify(m => m.Update(It.IsAny<MinorWork>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void DeleteMinorWork_NonExistingId_ThrowsArgumentException()
        {
            var minorWorkId = Guid.NewGuid();
            var minorWorks = new List<MinorWork>();
            var mockDbSet = CreateMockDbSet(minorWorks);

            _mockContext.Setup(m => m.MinorWorks).Returns(mockDbSet.Object);

            var ex = Assert.Throws<ArgumentException>(() => _service.DeleteMinorWork(minorWorkId));
            Assert.Equal("Minor work not found", ex.Message);
        }

        /*  [Fact]
          public void Get_ExistingId_ReturnsMinorWorkDto()
          {
              var minorWorkId = Guid.NewGuid();
              var minorWork = CreateMinorWork(minorWorkId);
              var minorWorks = new List<MinorWork> { minorWork };
              var mockDbSet = CreateMockDbSet(minorWorks);

              _mockContext.Setup(c => c.MinorWorks).Returns(mockDbSet.Object);
              var minorWorkDto = CreateMinorWorkDto(minorWork);
              _mockMapper.Setup(m => m.Map<MinorWorkDto>(minorWork)).Returns(minorWorkDto);

              var result = _service.Get(minorWorkId);

              Assert.NotNull(result);
              Assert.Equal(minorWorkId, result.MinorWorkId);
          }
  */
        [Fact]
        public void Gets_SortOrderAsc_ReturnsSortedMinorWorkDtos()
        {
            var minorWorks = new List<MinorWork>
            {
                CreateMinorWork(Guid.NewGuid()),
                CreateMinorWork(Guid.NewGuid())
            };
            minorWorks[0].Description = "B";
            minorWorks[1].Description = "A";

            var mockDbSet = CreateMockDbSet(minorWorks);

            _mockContext.Setup(c => c.MinorWorks).Returns(mockDbSet.Object);

            _mockMapper.Setup(m => m.Map<IEnumerable<MinorWorkDto>>(It.IsAny<IEnumerable<MinorWork>>())).Returns(
                (IEnumerable<MinorWork> source) => source.Select(mw => CreateMinorWorkDto(mw)).ToList());

            var result = _service.Gets("asc");

            Assert.Equal("A", result.First().Description);
        }

        [Fact]
        public void Gets_SortOrderDesc_ReturnsSortedMinorWorkDtos()
        {
            var minorWorks = new List<MinorWork>
            {
                CreateMinorWork(Guid.NewGuid()),
                CreateMinorWork(Guid.NewGuid())
            };
            minorWorks[0].Description = "A";
            minorWorks[1].Description = "B";

            var mockDbSet = CreateMockDbSet(minorWorks);

            _mockContext.Setup(c => c.MinorWorks).Returns(mockDbSet.Object);

            _mockMapper.Setup(m => m.Map<IEnumerable<MinorWorkDto>>(It.IsAny<IEnumerable<MinorWork>>())).Returns(
                (IEnumerable<MinorWork> source) => source.Select(mw => CreateMinorWorkDto(mw)).ToList());

            var result = _service.Gets("desc");

            Assert.Equal("B", result.First().Description);
        }

        /*  [Fact]
          public void UpdateMinorWork_ExistingMinorWork_UpdatesSuccessfully()
          {
              var minorWorkDto = CreateMinorWorkDto(CreateMinorWork(Guid.NewGuid()));
              var minorWork = CreateMinorWork(minorWorkDto.MinorWorkId);
              var minorWorks = new List<MinorWork> { minorWork };
              var mockDbSet = CreateMockDbSet(minorWorks);

              _mockContext.Setup(c => c.MinorWorks).Returns(mockDbSet.Object);

              _service.UpdateMinorWork(minorWorkDto);

              _mockMapper.Verify(m => m.Map(minorWorkDto, minorWork), Times.Once);
              _mockContext.Verify(m => m.SaveChanges(), Times.Once);
          }
  */
        [Fact]
        public void UpdateMinorWork_NonExistingMinorWork_DoesNothing()
        {
            var minorWorkDto = CreateMinorWorkDto(CreateMinorWork(Guid.NewGuid()));
            var minorWorks = new List<MinorWork>();
            var mockDbSet = CreateMockDbSet(minorWorks);

            _mockContext.Setup(c => c.MinorWorks).Returns(mockDbSet.Object);

            _service.UpdateMinorWork(minorWorkDto);

            _mockMapper.Verify(m => m.Map(It.IsAny<MinorWorkDto>(), It.IsAny<MinorWork>()), Times.Never);
            _mockContext.Verify(m => m.SaveChanges(), Times.Never);
        }
    }
}
