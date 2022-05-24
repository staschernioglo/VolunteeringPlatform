using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Volunteer;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Dal.Interfaces;
using VolunteeringPlatform.Domain.Auth;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Bll.Services
{
    public class VolunteerService : IVolunteerService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public VolunteerService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<VolunteerListDto>> GetPagedVolunteersAsync(PagedRequest pagedRequest)
        {
            var pagedVolunteersDto = await _repository.GetPagedDataAsync<Volunteer, VolunteerListDto>(pagedRequest);
            return pagedVolunteersDto;
        }

        public async Task ParticipateInProjectAsync(int projectId, int volunteerId)
        {
            var projectVolunteer = new ProjectVolunteer() { ProjectId = projectId, VolunteerId = volunteerId };
            _repository.Add(projectVolunteer);
            await _repository.SaveChangesAsync();
        }

        public async Task ParticipateInGoodDeedAsync(int goodDeedId, int volunteerId)
        {
            var goodDeedVolunteer = new GoodDeedVolunteer() { GoodDeedId = goodDeedId, VolunteerId = volunteerId };
            _repository.Add(goodDeedVolunteer);
            await _repository.SaveChangesAsync();
        }
    }
}
