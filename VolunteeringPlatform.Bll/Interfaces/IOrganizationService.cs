using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Dtos.Organization;
using VolunteeringPlatform.Common.Models.PagedRequest;

namespace VolunteeringPlatform.Bll.Interfaces
{
    public interface IOrganizationService
    {
        Task<PaginatedResult<OrganizationListDto>> GetPagedOrganizations(PagedRequest pagedRequest);

        Task<OrganizationDto> GetOrganization(int id);
    }
}
