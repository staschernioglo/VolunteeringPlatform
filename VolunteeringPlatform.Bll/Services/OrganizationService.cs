﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Organization;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Dal.Interfaces;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.Bll.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public OrganizationService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrganizationDto> GetOrganization(int id)
        {
            var organization = await _repository.GetById<Organization>(id);
            var organizationDto = _mapper.Map<OrganizationDto>(organization);
            return organizationDto;
        }

        public async Task<PaginatedResult<OrganizationListDto>> GetPagedOrganizations(PagedRequest pagedRequest)
        {
            var pagedOrganizationsDto = await _repository.GetPagedData<Organization, OrganizationListDto>(pagedRequest);
            return pagedOrganizationsDto;
        }
    }
}