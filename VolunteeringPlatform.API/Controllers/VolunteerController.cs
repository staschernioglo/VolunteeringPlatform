﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunteeringPlatform.API.Infrastructure.Extentions;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Volunteer;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.API.Controllers
{
    [Route("api/volunteers")]
    public class VolunteerController : BaseController
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        [AllowAnonymous]
        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<VolunteerListDto>> GetPagedVolunteers(PagedRequest pagedRequest)
        {
            var pagedVolunteersDto = await _volunteerService.GetPagedVolunteers(pagedRequest);
            return pagedVolunteersDto;
        }

        [HttpPost("{projectId}")]
        public async Task<IActionResult> ParticipateInProject(int projectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var volunteerId = User.GetLoggedInUserId();

            await _volunteerService.ParticipateInProject(projectId, volunteerId);
            return Ok();
        }

        [HttpPost("{goodDeedId}")]
        public async Task<IActionResult> ParticipateInGoodDeed(int goodDeedId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var volunteerId = User.GetLoggedInUserId();

            await _volunteerService.ParticipateInProject(goodDeedId, volunteerId);
            return Ok();
        }
    }
}