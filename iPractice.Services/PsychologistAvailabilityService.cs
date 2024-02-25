using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iPractice.ApiModels;
using iPractice.Contracts;
using iPractice.DataAccess.Contracts;
using iPractice.Models;
using Microsoft.Extensions.Logging;

namespace iPractice.Services
{
    public class PsychologistAvailabilityService : IPsychologistAvailabilityService
    {
        private readonly IPsychologistsRepository _psychologistsRepository;
        private readonly IPsychologistAvailabilityRepository _psychologistAvailabilitiesRepository;
        private readonly ILogger<PsychologistAvailabilityService> _logger;

        public PsychologistAvailabilityService(
            IPsychologistsRepository psychologistsRepository,
            IPsychologistAvailabilityRepository psychologistAvailabilitiesRepository,
            ILogger<PsychologistAvailabilityService> logger)
        {
            _psychologistsRepository = psychologistsRepository;
            _psychologistAvailabilitiesRepository = psychologistAvailabilitiesRepository;
            _logger = logger;
        }

        public async Task<AvailabilityResponse> CreateAvailability(long psychologistId, AvailabilityRequest availability)
        {
            await GetPsychologistOrThrow(psychologistId);
            var newAvailability = new AvailabilityDto
            {
                From = availability.From,
                To = availability.To,
            };

            // business flow to be defined what needs to be if new availability crossing others created in the past

            var createdAvailability = await _psychologistAvailabilitiesRepository.CreateOrUpdateAvailability(newAvailability);
            return new AvailabilityResponse
            {
                Id = createdAvailability.Id,
                From = availability.From,
                To = availability.To,
            };
        }

        public async Task<AvailabilityResponse> UpdateAvailability(long psychologistId, long availabilityId, AvailabilityRequest availability)
        {
            await GetPsychologistOrThrow(psychologistId);
            await GetPsychologistAvailabilityOrThrow(availabilityId);

            var updatedAvailability = new AvailabilityDto
            {
                Id = availabilityId,
                From = availability.From,
                To = availability.To,
            };

            // business flow to be defined what needs to be done with existing booked time slots for this period of time

            updatedAvailability = await _psychologistAvailabilitiesRepository.CreateOrUpdateAvailability(updatedAvailability);

            return new AvailabilityResponse
            {
                Id = updatedAvailability.Id,
                From = availability.From,
                To = availability.To,
            };
        }

        public async Task<List<AvailabilityResponse>> GetAvailability(long psychologistId)
        {
            await GetPsychologistOrThrow(psychologistId);
            var psychologistAvailability = await _psychologistAvailabilitiesRepository.GetAvailabilityForPsychologist(psychologistId);
            return psychologistAvailability.Select(x => new AvailabilityResponse
            {
                Id = x.Id,
                From = x.From,
                To = x.To
            }).ToList();
        }

        private async Task<PsychologistDto> GetPsychologistOrThrow(long psychologistId)
        {
            try
            {
                var psychologist = await _psychologistsRepository.GetPsychologist(psychologistId);
                if (psychologist != null)
                {
                    return psychologist;
                }

                throw new Exception($"{nameof(GetPsychologistOrThrow)} didn't find entity for id = {psychologistId}.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(GetPsychologistOrThrow)} has failed for id = {psychologistId}.", e);
                throw;
            }
        }
        public async Task<AvailabilityDto> GetPsychologistAvailabilityOrThrow(long availabilityId)
        {
            try
            {
                var availability = await _psychologistAvailabilitiesRepository.GetAvailability(availabilityId);
                if (availability != null)
                {
                    return availability;
                }

                throw new Exception($"{nameof(GetPsychologistAvailabilityOrThrow)} didn't find entity for id = {availabilityId}.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(GetPsychologistAvailabilityOrThrow)} has failed for id = {availabilityId}.", e);
                throw;
            }
        }
    }
}
