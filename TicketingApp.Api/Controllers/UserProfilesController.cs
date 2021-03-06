﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.Services.Interfaces;
using TicketingApp.Shared.Models;
using TicketingApp.Shared.Requests;
using TicketingApp.Shared.Responses;

namespace TicketingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfilesService _userProfilesService;

        public UserProfilesController(IUserProfilesService userProfilesService)
        {
            _userProfilesService = userProfilesService;
        }

        [ProducesResponseType(200, Type = typeof(OperationResponse<UserProfileDetail>))]
        [ProducesResponseType(404)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userProfilesService.GetProfileByUserIdAsync();
            if (result.IsSuccess)
                return Ok(result);

            return NotFound();
        }

        [ProducesResponseType(200, Type = typeof(OperationResponse<UserProfileDetail>))]
        [ProducesResponseType(400, Type = typeof(OperationResponse<UserProfileDetail>))]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateProfileRequest model)
        {
            var result = await _userProfilesService.CreateProfileAsync(model);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
