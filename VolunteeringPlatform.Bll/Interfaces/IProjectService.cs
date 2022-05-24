using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Dtos.Project;
using VolunteeringPlatform.Common.Models.PagedRequest;

namespace VolunteeringPlatform.Bll.Interfaces
{
    public interface IProjectService
    {
        Task<PaginatedResult<ProjectListDto>> GetPagedProjectsAsync(PagedRequest pagedRequest);

        Task<ProjectDto> GetProjectAsync(int id);

        Task<ProjectDto> CreateProjectAsync(ProjectForCreateDto projectForCreateDto);

        Task UpdateProjectAsync(int id, ProjectForUpdateDto projectForUpdateDto);

        Task DeleteProjectAsync(int id);
    }
}
