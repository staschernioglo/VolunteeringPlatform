using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Organization;
using VolunteeringPlatform.Common.Models.PagedRequest;

namespace VolunteeringPlatform.API.Controllers
{
    [Route("api/organizations")]
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [AllowAnonymous]
        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<OrganizationListDto>> GetPagedOrganizations(PagedRequest pagedRequest)
        {
            var pagedOrganizationsDto = await _organizationService.GetPagedOrganizationsAsync(pagedRequest);
            return pagedOrganizationsDto;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<OrganizationDto> GetOrganization(int id)
        {
            var organizationDto = await _organizationService.GetOrganizationAsync(id);
            return organizationDto;
        }
    }
}
