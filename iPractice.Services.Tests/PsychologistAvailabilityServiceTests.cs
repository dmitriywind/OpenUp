using NUnit.Framework;
using System.Threading.Tasks;
using System;
using iPractice.ApiModels;
using iPractice.DataAccess.Contracts;
using iPractice.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace iPractice.Services.Tests
{
    [TestFixture]
    public class PsychologistAvailabilityServiceTests
    {
        private Mock<IPsychologistsRepository> _psychologistsRepository;
        private Mock<IPsychologistAvailabilityRepository> _psychologistAvailabilityRepository;
        private Mock<ILogger<PsychologistAvailabilityService>> _logger;

        private PsychologistAvailabilityService _psychologistAvailabilityService;

        [SetUp]
        public void SetUp()
        {
            _psychologistsRepository = new Mock<IPsychologistsRepository>();
            _psychologistAvailabilityRepository = new Mock<IPsychologistAvailabilityRepository>();
            _logger = new Mock<ILogger<PsychologistAvailabilityService>>();

            _psychologistAvailabilityService = new PsychologistAvailabilityService(
                _psychologistsRepository.Object,
                _psychologistAvailabilityRepository.Object,
                _logger.Object);
        }

        [Test]
        public async Task CreateAvailability_ValidPsychologistId_ReturnsAvailabilityResponse()
        {
            // Arrange
            long psychologistId = 1;
            var availabilityRequest = new AvailabilityRequest { From = DateTime.UtcNow, To = DateTime.UtcNow.AddHours(2) };

            _psychologistsRepository.Setup(s => s.GetPsychologist(It.IsAny<long>())).ReturnsAsync(new PsychologistDto()); // Adjust this based on your actual implementation

            _psychologistAvailabilityRepository.Setup(r => r.CreateOrUpdateAvailability(It.IsAny<AvailabilityDto>()))
                .ReturnsAsync(new AvailabilityDto { Id = 123, From = availabilityRequest.From, To = availabilityRequest.To });

            // Act
            var result = await _psychologistAvailabilityService.CreateAvailability(psychologistId, availabilityRequest);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(123));
            Assert.That(result.From, Is.EqualTo(availabilityRequest.From));
            Assert.That(result.To, Is.EqualTo(availabilityRequest.To));
        }

        [Test]
        public void CreateAvailability_InvalidPsychologistId_ThrowsException()
        {
            // Arrange
            long psychologistId = 1;
            var availabilityRequest = new AvailabilityRequest { From = DateTime.UtcNow, To = DateTime.UtcNow.AddHours(2) };

            _psychologistsRepository.Setup(s => s.GetPsychologist(It.IsAny<long>())).ThrowsAsync(new Exception());

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => _psychologistAvailabilityService.CreateAvailability(psychologistId, availabilityRequest));
        }
    }
}