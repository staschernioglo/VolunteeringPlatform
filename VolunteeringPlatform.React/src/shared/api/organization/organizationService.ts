import axios from "axios";
import { OrganizationListDto } from "shared/models/organizationModel";
import { PagedRequest, PagedResult } from "shared/models/pagedRequestModel";
import { MyProjectDto } from "shared/models/projectModel";

export async function getPagedOrganizations(pagedRequest: PagedRequest) {
    let response = await axios.post<PagedResult<OrganizationListDto>>("https://localhost:7091/api/organizations/paginated-search", pagedRequest );
    return response.data;
}

export async function getMyProjects() {
    let response = await axios.get<MyProjectDto[]>("https://localhost:7091/api/projects/mine");
    return response.data;
}


