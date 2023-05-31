using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VolunteeringPlatform.API.Infrastructure.Extentions;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Project;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Dal.Constants;

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
        public async Task<PaginatedResult<ProjectListDto>> GetPagedProjects(PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            var pagedProjectsDto = await _projectService.GetPagedProjectsAsync(pagedRequest, cancellationToken);
            return pagedProjectsDto;

        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ProjectDto> GetProject(int id, CancellationToken cancellationToken)
        {
            var projectDto = await _projectService.GetProjectAsync(id, cancellationToken);
            return projectDto;
        }

        [Authorize(Roles = RoleConstants.Organization)]
        [HttpGet("mine")]
        public async Task<List<MyProjectsListDto>> GetMyProjects(CancellationToken cancellationToken)
        {
            var organizationId = User.GetLoggedInUserId();
            var projectDto = await _projectService.GetMyProjectsAsync(organizationId, cancellationToken);
            return projectDto;
        }

        [Authorize(Roles = RoleConstants.Organization)]
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromForm]ProjectForCreateDto projectForCreateDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizationId = User.GetLoggedInUserId();
            projectForCreateDto.OrganizationId = organizationId;

            var projectDto = await _projectService.CreateProjectAsync(projectForCreateDto, cancellationToken);

            return CreatedAtAction(nameof(GetProject), new { id = projectDto.Id }, projectDto);
        }

        [Authorize(Roles = RoleConstants.Organization)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectForUpdateDto projectForUpdateDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _projectService.UpdateProjectAsync(id, projectForUpdateDto, cancellationToken);
            return Ok();
        }

        [Authorize(Roles = RoleConstants.Organization)]
        [HttpDelete("{id}")]
        public async Task DeleteProject(int id, CancellationToken cancellationToken)
        {
            await _projectService.DeleteProjectAsync(id, cancellationToken);
        }
    }
}
