using VolunteeringPlatform.Common.Dtos.Project;

namespace VolunteeringPlatform.Bll.Interfaces
{
    public interface IProjectVolunteerService
    {
        public Task<List<ProjectVolunteerListDto>> GetProjectParticipants(int Id, CancellationToken cancellationToken);
    }
}
