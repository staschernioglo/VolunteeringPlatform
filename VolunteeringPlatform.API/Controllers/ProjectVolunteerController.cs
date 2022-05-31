using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Project;

namespace VolunteeringPlatform.API.Controllers
{
    [Route("api/projectvolunteers")]
    [ApiController]
    public class ProjectVolunteerController : BaseController
    {
        private readonly IProjectVolunteerService _projectVolunteerService;

        public ProjectVolunteerController(IProjectVolunteerService projectVolunteerService)
        {
            _projectVolunteerService = projectVolunteerService;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<List<ProjectVolunteerListDto>> GetParticipants(int id, CancellationToken cancellationToken)
        {
            var projectVolunteerDto = await _projectVolunteerService.GetProjectParticipants(id, cancellationToken);
            return projectVolunteerDto;
        }

    }
}
