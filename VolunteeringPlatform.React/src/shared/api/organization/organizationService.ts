import axios from "axios";
import { OrganizationListDto } from "shared/models/organizationModel";
import { PagedRequest, PagedResult } from "shared/models/pagedRequestModel";

export async function getPagedOrganizations(pagedRequest: PagedRequest) {
    let response = await axios.post<PagedResult<OrganizationListDto>>("https://localhost:7091/api/organizations/paginated-search", pagedRequest );
    return response.data;
}
