import { Grid, TextField, Select, MenuItem, Button, Container, Box } from '@mui/material';
import { useForm, Controller } from 'react-hook-form';
import OrganizationRegisterDto from 'shared/models/userModel';
import { registerOrganization } from 'shared/api/signup/signupService';
import { useNavigate } from 'react-router-dom';


const RegisterOrganization = () => {

  const { control, handleSubmit, formState: { errors } } = useForm<OrganizationRegisterDto>();
  const navigate = useNavigate();


  const onSubmit = async (form: OrganizationRegisterDto) => {
    let result = await registerOrganization(form);
    if (result) {
      navigate("/login");
    }
  };

  return <Box margin='auto'
              justifyContent='center'
              width='450px' >
    <form noValidate onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={3} sx={{
        '& .MuiTextField-root': { width: '50ch' },
        '& .MuiSelect-root': { width: '50ch' },
        '.MuiFormControl-root': { margin: 0 }
      }}>
        <Grid item xs={12}>
          <Controller
            control={control}
            name="userName"
            defaultValue={''}
            rules={{
              required: true,
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.userName !== undefined}
                variant="outlined"
                margin="normal"
                required
                type="text"
                label="UserName"
                autoFocus
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="email"
            defaultValue={''}
            rules={{
              required: true,
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.email !== undefined}
                variant="outlined"
                margin="normal"
                required
                type="text"
                label="Email"
                autoFocus
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="password"
            defaultValue={''}
            rules={{
              required: true,
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.password !== undefined}
                variant="outlined"
                margin="normal"
                required
                type="password"
                label="Password"
                autoFocus
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="confirmPassword"
            defaultValue={''}
            rules={{
              required: true,
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.confirmPassword !== undefined}
                variant="outlined"
                margin="normal"
                required
                type="password"
                label="Confirm password"
                autoFocus
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="fullName"
            defaultValue={''}
            rules={{
              required: true,
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.fullName !== undefined}
                variant="outlined"
                margin="normal"
                required
                type="text"
                label="Name"
                autoFocus
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="description"
            defaultValue={''}
            rules={{
              required: false,
            }}
            render={({ field }) => (
              <TextField
                {...field}
                // error={errors.email !== undefined}
                id="outlined-multiline-flexible"
                multiline
                maxRows={10}
                variant="outlined"
                margin="normal"
                type="text"
                label="Description"
                autoFocus
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="address"
            defaultValue={''}
            rules={{
              required: false,
              minLength: 3
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.address !== undefined}
                variant="outlined"
                margin="normal"
                type="text"
                label="Address"
                autoFocus
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="phoneNumber"
            defaultValue={''}
            rules={{
              required: false,
              minLength: 5,
              maxLength: 20
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.phoneNumber !== undefined}
                variant="outlined"
                margin="normal"
                type="text"
                label="Phone Number"
                autoFocus
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>

          <Button
            type="submit"
            variant="contained"
            color="primary"
          >
            Register
          </Button>
        </Grid>
      </Grid>
    </form>
  </Box>
}

export default RegisterOrganization;