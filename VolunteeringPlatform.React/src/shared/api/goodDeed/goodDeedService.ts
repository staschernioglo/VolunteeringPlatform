import axios from "axios";
import { GoodDeedForCreateDto } from "shared/models/goodDeedModel";

export async function addGoodDeed(goodDeed: GoodDeedForCreateDto) {
    let response = await axios.post("https://localhost:7091/api/gooddeeds", goodDeed, { headers: {'Content-type': 'multipart/form-data'}} );
    return response.data;
} 