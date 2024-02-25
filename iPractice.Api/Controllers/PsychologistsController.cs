using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using iPractice.ApiModels;
using iPractice.ApiModels.Validators;
using iPractice.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iPractice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PsychologistsController : ControllerBase
    {
        private readonly IPsychologistAvailabilityService _psychologistAvailabilityService;
        private readonly AvailabilityRequestValidator _availabilityRequestValidator;
        private readonly ILogger<PsychologistsController> _logger;

        public PsychologistsController(
            IPsychologistAvailabilityService psychologistAvailabilityService,
            AvailabilityRequestValidator availabilityRequestValidator,
            ILogger<PsychologistsController> logger)
        {
            _psychologistAvailabilityService = psychologistAvailabilityService;
            _availabilityRequestValidator = availabilityRequestValidator;
            _logger = logger;
        }

        [HttpGet("{psychologistId}/availability")]
        [ProducesResponseType(typeof(List<AvailabilityResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AvailabilityResponse>>> Get([FromRoute] long psychologistId)
        {
            return await _psychologistAvailabilityService.GetAvailability(psychologistId);
        }

        /// <summary>
        /// Add a block of time during which the psychologist is available during normal business hours
        /// </summary>
        /// <param name="psychologistId"></param>
        /// <param name="availability">Availability</param>
        /// <returns>Ok if the availability was created</returns>
        [HttpPost("{psychologistId}/availability")]
        [ProducesResponseType(typeof(AvailabilityResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<long>> CreateAvailability([FromRoute] long psychologistId, [FromBody] AvailabilityRequest availability)
        {
            var validationResult = await _availabilityRequestValidator.ValidateAsync(availability);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var createdAvailability = await _psychologistAvailabilityService.CreateAvailability(psychologistId, availability);
            return Ok(createdAvailability);
        }

        /// <summary>
        /// Update availability of a psychologist
        /// </summary>
        /// <param name="psychologistId">The psychologist's ID</param>
        /// <param name="availabilityId">The ID of the availability block</param>
        /// <returns>List of availability slots</returns>
        [HttpPut("{psychologistId}/availability/{availabilityId}")]
        [ProducesResponseType(typeof(AvailabilityResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AvailabilityResponse>> UpdateAvailability([FromRoute] long psychologistId, [FromRoute] long availabilityId, [FromBody] AvailabilityRequest availability)
        {
            var validationResult = await _availabilityRequestValidator.ValidateAsync(availability);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var updatedAvailability = await _psychologistAvailabilityService.UpdateAvailability(psychologistId, availabilityId, availability);
            return Ok(updatedAvailability);
        }
    }
}
