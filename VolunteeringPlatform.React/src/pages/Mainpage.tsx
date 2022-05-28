import { Button } from "@mui/material"
import axios from "axios";
import { ProjectDto } from "shared/models/userModel";

const Mainpage = () => {

    var test: ProjectDto = {
        name: "Sadfessa",
        category: "Mafrfessa",
    };

    const handleClick = async () => {
        console.log(test);
        const response = axios({
            method: 'post',
            url: 'https://localhost:7091/api/gooddeeds',
            data: {
              name: 'Zxxxcc',
              category: 'Flintstone',
              userId: 1002
            }
          });
        console.log((await response).data);
    }
    return (
        <>
            <div>
                <h1>MAIN PAGE INFO</h1>
                <Button onClick={ handleClick } >Test</Button>
            </div>
        </>
    )
}

export {Mainpage}