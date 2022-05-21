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
        Task<PaginatedResult<ProjectListDto>> GetPagedProjects(PagedRequest pagedRequest);

        Task<ProjectDto> GetProject(int id);

        Task<ProjectDto> CreateProject(ProjectForCreateDto projectForCreateDto);

        Task UpdateProject(int id, ProjectForUpdateDto projectForUpdateDto);

        Task DeleteProject(int id);
    }
}
