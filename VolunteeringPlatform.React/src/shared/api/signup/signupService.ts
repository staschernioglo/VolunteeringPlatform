import axios from "axios";
import OrganizationRegisterDto from "shared/models/userModel";

export async function registerOrganization(organization: OrganizationRegisterDto) {
    let response = await axios.post("https://localhost:7091/api/account/register/organization", organization);
    return response.data;
} 