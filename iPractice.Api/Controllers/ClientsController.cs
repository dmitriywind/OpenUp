﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using iPractice.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iPractice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        
        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// The client can see when his psychologists are available.
        /// Get available slots from his two psychologists.
        /// </summary>
        /// <param name="clientId">The client ID</param>
        /// <returns>All time slots for the selected client</returns>
        [HttpGet("{clientId}/timeslots")]
        [ProducesResponseType(typeof(IEnumerable<TimeSlotApiModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TimeSlotApiModel>>> GetAvailableTimeSlots(long clientId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create an appointment for a given availability slot
        /// </summary>
        /// <param name="clientId">The client ID</param>
        /// <param name="timeSlot">Identifies the client and availability slot</param>
        /// <returns>Ok if appointment was made</returns>
        [HttpPost("{clientId}/appointment")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateAppointment(long clientId, [FromBody] TimeSlotApiModel timeSlot)
        {
            throw new NotImplementedException();
        }
    }
}
