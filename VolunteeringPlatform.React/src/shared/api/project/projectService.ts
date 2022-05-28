import axios from "axios";
import { ProjectForCreateDto } from "shared/models/projectModel";

export async function addProject(project: ProjectForCreateDto) {
    let response = await axios.post("https://localhost:7091/api/projects", project, { headers: {'Content-type': 'multipart/form-data'}} );
    return response.data;
} 