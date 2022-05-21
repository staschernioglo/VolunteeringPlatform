﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Dtos.Account;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.Bll.Profiles
{
    public class VolunteerProfile : Profile
    {
        public VolunteerProfile()
        {
            CreateMap<VolunteerForRegisterDto, Volunteer>()
                .ForMember(x => x.Description, y => y.MapFrom(s => s.PersonalInformation))
                .ForMember(x => x.PasswordHash, y => y.MapFrom(s => s.Password));
        }
    }
}
