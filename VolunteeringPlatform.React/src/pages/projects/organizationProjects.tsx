import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import { useCallback, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getMyProjects } from 'shared/api/organization/organizationService';
import { MyProjectDto } from "shared/models/projectModel";
import IconButton from '@mui/material/IconButton';
import DeleteIcon from '@mui/icons-material/Delete';
import { deleteProject } from 'shared/api/project/projectService';

const MyProjects = () => {

    const [projects, setProjects] = useState<MyProjectDto[]>([{}]);
	const [deleting, setDeleting] = useState(false);

    const handleResponse = useCallback((response: MyProjectDto[]) => {
        setProjects([...response]);
    }, []);

    useEffect( () => {
        getMyProjects().then(handleResponse);
    },[deleting]);

	const handleDelete = (id?: number) => {
		deleteProject(id);
		setDeleting(!deleting);
	}

	return (
		<Box margin='auto'
			justifyContent='center'
			textAlign='center'
			width='1000px' >
			<h1 className='heads'>MY PROJECTS</h1>
			<TableContainer component={Paper} sx={{ mt: 2 }}>
				<Table sx={{ minWidth: 650 }} aria-label="simple table">
					<TableHead>
						<TableRow>
							<TableCell align="center">
							</TableCell>
							<TableCell sx={{ fontSize: 20 }} align="center">
									Name
							</TableCell>
							<TableCell sx={{ fontSize: 20 }} align="center">
							</TableCell >
						</TableRow>
					</TableHead>
					<TableBody>
						{
							projects.map((row) => (
								<TableRow
									key={row.id}
									sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
								>
									<TableCell align="center">
										<Box
												component="img"
												sx={{
													height: 267,
													width: 400,
													maxHeight: { xs: 267, md: 167 },
													maxWidth: { xs: 400, md: 250 },
													borderRadius: 3,
													}}
												alt="Project image"
												src={row.imageUrl}
										/>
									</TableCell>
									<TableCell sx={{ fontSize: 25 }} align="center">
										<Link to={String(row.id)}>
										{row.name}
										</Link>
										</TableCell>
									<TableCell sx={{ fontSize: 25 }} align="center">
										<IconButton onClick={() => handleDelete(row.id)} aria-label="delete" size="large" color="error">
											<DeleteIcon fontSize="inherit" />
										</IconButton>
									</TableCell>
								</TableRow>
							))
						}
					</TableBody>
				</Table>
			</TableContainer>
		</Box>
	)
}

export { MyProjects };