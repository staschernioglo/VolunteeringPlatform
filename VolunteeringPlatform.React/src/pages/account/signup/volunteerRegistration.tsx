import { Grid, TextField, Button, Box } from '@mui/material';
import { useForm, Controller } from 'react-hook-form';
import { VolunteerRegisterDto } from 'shared/models/userModel';
import { registerVolunteer } from 'shared/api/signup/signupService';
import { useNavigate } from 'react-router-dom';
import { useState } from 'react';


const RegisterVolunteer = () => {

  const { control, handleSubmit, formState: { errors } } = useForm<VolunteerRegisterDto>();
  const navigate = useNavigate();
  const [file, setFile] = useState();
  
  const saveFile = (e: any) => {
    setFile(e.target.files[0]);
  }

  const onSubmit = async (form: VolunteerRegisterDto) => {
    form.photo = file;
    let result = await registerVolunteer(form);
    if (result) {
      navigate("/login");
    }
  };

  return <Box margin='auto'
              justifyContent='center'
              textAlign='center'
              width='450px' >
                <h1>Volunteer registration</h1>
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
              required: 'Username is required',
            }}
            render={({ field, fieldState: { error } }) => (
              <TextField
                {...field}
                error={errors.userName !== undefined}
                helperText={error ? error.message : null}
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
              required: 'Email is required',
            }}
            render={({ field, fieldState: { error } }) => (
              <TextField
                {...field}
                error={errors.email !== undefined}
                helperText={error ? error.message : null}
                variant="outlined"
                margin="normal"
                required
                type="email"
                label="Email"
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
              required: 'Password is required',
            }}
            render={({ field, fieldState: { error } }) => (
              <TextField
                {...field}
                error={errors.password !== undefined}
                helperText={error ? error.message : null}
                variant="outlined"
                margin="normal"
                required
                type="password"
                label="Password"
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
              required: 'Please confirm password',
            }}
            render={({ field, fieldState: { error } }) => (
              <TextField
                {...field}
                error={errors.confirmPassword !== undefined}
                helperText={error ? error.message : null}
                variant="outlined"
                margin="normal"
                required
                type="password"
                label="Confirm password"
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
              required: 'Name is required',
              maxLength: 50
            }}
            render={({ field, fieldState: { error } }) => (
              <TextField
                {...field}
                error={errors.fullName !== undefined}
                helperText={error ? error.message : null}
                variant="outlined"
                margin="normal"
                required
                type="text"
                label="Full Name"
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="birthDate"
            defaultValue={new Date()}
            rules={{
              required: 'Date of Birth is required'
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.birthDate !== undefined}
                variant="outlined"
                margin="normal"
                type="date"
                helperText="Date of Birth (required)"
                required
                label=""
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="personalInformation"
            defaultValue={''}
            rules={{
              required: false,
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.personalInformation !== undefined}
                id="outlined-multiline-flexible"
                multiline
                maxRows={10}
                variant="outlined"
                margin="normal"
                type="text"
                label="Personal information"
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
          <Controller
            control={control}
            name="locality"
            defaultValue={''}
            rules={{
              required: false,
              minLength: 3,
              maxLength: 50
            }}
            render={({ field }) => (
              <TextField
                {...field}
                error={errors.locality !== undefined}
                variant="outlined"
                margin="normal"
                type="text"
                label="Locality"
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
              minLength: 3,
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
              />
            )}
          />
        </Grid>

        <Grid item xs={12}>
        <Controller
          name="photo"
          control={control}
          render={({ field }) => (
            <TextField
                {...field}
                error={errors.photo !== undefined}
                variant="outlined"
                helperText="Upload photo"
                margin="normal"
                type="file"
                onChange={(e) => {
                  saveFile(e);
                }}
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

export default RegisterVolunteer;