using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Dtos.Account;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.Bll.Profiles
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<OrganizationForRegisterDto, Organization>()
                .ForMember(x => x.PasswordHash, y => y.MapFrom(s => s.Password));
        }
    }
}
