import axios from "axios";
import { PagedRequest, PagedResult } from "shared/models/pagedRequestModel";
import { VolunteerListDto } from "shared/models/volunteerModel";

export async function getPagedVolunteers(pagedRequest: PagedRequest) {
    let response = await axios.post<PagedResult<VolunteerListDto>>("https://localhost:7091/api/volunteers/paginated-search", pagedRequest );
    return response.data;
}

export async function participateInProject(projectId?: number) {
    console.log(`projectId = ${projectId}`);
    console.log(typeof(projectId));
    let response = await axios.post(`https://localhost:7091/api/volunteers/participateproj/${projectId}`, projectId );
    return response.data;
}

