
import Box from '@mui/material/Box';
import { useCallback, useContext, useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import { ProjectDto } from 'shared/models/projectModel';
import { getProject } from 'shared/api/project/projectService';
import { MainInfo } from 'widgets/details/mainInfo';
import { Details } from 'widgets/details/details';
import { AuthContext } from 'app/App';
import { Button } from '@mui/material';
import { participateInProject } from 'shared/api/volunteer/volunteerService';
import { Description } from 'widgets/details/description';
import { Participants } from 'widgets/details/participants';

const ProjectPage = () => {

    const [project, setProject] = useState<ProjectDto>({});
    const [participation, setParticipation] = useState(false);
    const projectId = Number(useParams().id);
    const { role } = useContext(AuthContext);

    const handleResponse = useCallback((response: ProjectDto) => {
        setProject(response);
    }, []);

    useEffect( () => {
        getProject(projectId).then(handleResponse);
    },[participation])

    const handleParticipation = async () => {
        await participateInProject(project.id);
        setParticipation(true);

    }

	return (
		<Box margin='auto'
			justifyContent='center'
			width='800px' 
            sx={{ mt:5 }} >
            
			<MainInfo name={project.name} category={project.category} organization={project.organization} 
            organizationId={project.organizationId} imageUrl={project.imageUrl} />
            
            { (project.description) ? <Description value={project.description} /> : <></> }
            { (project.locality) ? <Details title="Locality:" value={project.locality} /> : <></> }
            { (project.address) ? <Details title="Address:" value={project.address} /> : <></> }
            { (project.date) ? <Details title="Date:" value={new Date(project.date).toLocaleDateString() } /> : <></> }
            { (project.requiredNumberOfvolunteers) ? <Details title="Required number of volunteers:" value={project.requiredNumberOfvolunteers} /> : <></> }
            { (project.numberOfParticipatingVolunteers !== 0) ? <Participants id = {project.id} title="Already participating volunteers:" value={project.numberOfParticipatingVolunteers} /> : <></> }
            { (role === 'volunteer') ? <Button disabled={participation} sx={{ mt: 1, ml: 2, fontSize: 18}} onClick = {handleParticipation} variant="contained">Participate</Button> : <></>}
		</Box>
	)
}

export { ProjectPage };