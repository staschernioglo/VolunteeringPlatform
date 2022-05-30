﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Dtos.Project;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Bll.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectListDto>()
                .ForMember(x => x.Organization, y => y.MapFrom(s => s.Organization.FullName));

            CreateMap<Project, ProjectDto>()
                .ForMember(x => x.Organization, y => y.MapFrom(s => s.Organization.FullName));

            CreateMap<ProjectForCreateDto, Project>();
            CreateMap<ProjectForUpdateDto, Project>();
            CreateMap<Project, MyProjectsListDto>();

        }
    }
}
