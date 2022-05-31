using AutoMapper;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Project;
using VolunteeringPlatform.Dal.Interfaces;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Bll.Services
{
    public class ProjectVolunteerService : IProjectVolunteerService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProjectVolunteerService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProjectVolunteerListDto>> GetProjectParticipants(int id, CancellationToken cancellationToken)
        {
            var projectVolunteers = await _repository.GetAllWithFilterAndInclude<ProjectVolunteer>(x => x.ProjectId == id, cancellationToken, x => x.Volunteer );
            var projectVolunteersDto = _mapper.Map<List<ProjectVolunteer>, List<ProjectVolunteerListDto>>(projectVolunteers);
            return projectVolunteersDto;
        }
    }
}
