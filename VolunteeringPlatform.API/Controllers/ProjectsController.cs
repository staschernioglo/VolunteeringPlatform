using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VolunteeringPlatform.API.Infrastructure.Extentions;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Project;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [AllowAnonymous]
        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<ProjectListDto>> GetPagedProjects(PagedRequest pagedRequest)
        {
            var pagedProjectsDto = await _projectService.GetPagedProjects(pagedRequest);
            return pagedProjectsDto;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ProjectDto> GetProject(int id)
        {
            var projectDto = await _projectService.GetProject(id);
            return projectDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectForCreateDto projectForCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizationId = User.GetLoggedInUserId();
            projectForCreateDto.OrganizationId = organizationId;

            var projectDto = await _projectService.CreateProject(projectForCreateDto);

            return CreatedAtAction(nameof(GetProject), new { id = projectDto.Id }, projectDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectForUpdateDto projectForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _projectService.UpdateProject(id, projectForUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);
        }
    }
}
