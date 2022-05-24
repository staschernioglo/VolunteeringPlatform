using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Project;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Dal.Interfaces;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Bll.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAzureStorageService _azureStorageService;

        public ProjectService(IRepository repository, IMapper mapper, IAzureStorageService azureStorageService)
        {
            _repository = repository;
            _mapper = mapper;
            _azureStorageService = azureStorageService;
        }

        public async Task<ProjectDto> CreateProjectAsync(ProjectForCreateDto projectForCreateDto)
        {
            var project = _mapper.Map<Project>(projectForCreateDto);

            if (projectForCreateDto.Image != null)
            {
                var imageProps = await _azureStorageService.UploadAsync(projectForCreateDto.Image, "projects");
                project.ImageName = imageProps.ImageName;
                project.ImageUrl = imageProps.ImageUrl;
            }
            else
            {
                project.ImageUrl = "https://msdocsstoragefunc.blob.core.windows.net/projects/default.png";
            }
            
            _repository.Add(project);
            await _repository.SaveChangesAsync();

            var projectDto = _mapper.Map<ProjectDto>(project);

            return projectDto;
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _repository.GetByIdAsync<Project>(id);
            if (project == null)
            {
                throw new ValidationException($"Project with id { id } not found");
            }

            if (project.ImageName != null)
            {
                await _azureStorageService.DeleteAsync(project.ImageName, "projects");
            }
            
            await _repository.DeleteAsync<Project>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<PaginatedResult<ProjectListDto>> GetPagedProjectsAsync(PagedRequest pagedRequest)
        {
            var pagedProjectsDto = await _repository.GetPagedDataAsync<Project, ProjectListDto>(pagedRequest);
            return pagedProjectsDto;
        }

        public async Task<ProjectDto> GetProjectAsync(int id)
        {
            var project = await _repository.GetByIdWithIncludeAsync<Project>(id, project => project.Organization);
            var projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;
        }

        public async Task UpdateProjectAsync(int id, ProjectForUpdateDto projectForUpdateDto)
        {
            var project = await _repository.GetByIdAsync<Project>(id);
            _mapper.Map(projectForUpdateDto, project);
            await _repository.SaveChangesAsync();
        }
    }
}
