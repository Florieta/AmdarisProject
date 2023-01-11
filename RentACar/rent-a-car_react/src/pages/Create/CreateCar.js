import React from 'react'
import { useForm } from 'react-hook-form'
import Grid from '@mui/material/Grid'
import TextField from '@mui/material/TextField'
import Box from '@mui/material/Box'
import Button from '@mui/material/Button'
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
import axios from 'axios'
import { useAuthContext } from '../../hooks/useAuthContext';


const CreateCar = () => {
    const { user } = useAuthContext();

    const {
        register,
        handleSubmit,
        reset,
        formState: { errors },
    } = useForm();

    const submitData = async (data) => {
        // data = { ...data, dealerId: {user.token.id} };
         data.dealerId = user.user.id;
         console.log(data);
         await axios.post('https://localhost:7016/api/Car', data)
         
    }

    return (
        <div>
            <form noValidate autoComplete="off" onSubmit={handleSubmit(submitData)}>
                <Grid container spacing={2}>
                    <Grid item xs={5} md={5}>
                        <TextField
                            fullWidth
                            required
                            label="Make"
                            variant="outlined"
                            error={!!errors.make}
                            helperText={errors.make?.message}
                            {...register('make', {
                                required: { value: true, message: 'Make is required' },
                                minLength: { value: 2, message: 'Must be minimum 2 characters' },
                            })}
                        />
                    </Grid>

                    <Grid item xs={5} md={5}>
                        <TextField
                            fullWidth
                            required
                            label="Model"
                            variant="outlined"
                            error={!!errors.model}
                            helperText={errors.model?.message}
                            {...register('model', {
                                required: { value: true, message: 'Model is required' },
                                minLength: { value: 2, message: 'Must be minimum 2 characters' },
                            })}
                        />
                    </Grid>

                    <Grid item xs={5} md={5}>
                        <TextField
                            fullWidth
                            required
                            label="RegNumber"
                            variant="outlined"
                            error={!!errors.number}
                            helperText={errors.number?.message}
                            {...register('number', {
                                required: { value: true, message: 'Registration number is required' },
                                minLength: { value: 5, message: 'Must be minimum 5 characters' },
                            })}
                        />
                    </Grid>

                    <Grid item xs={5} md={5}>
                        <TextField
                            fullWidth
                            required
                            label="Year"
                            type="number"
                            variant="outlined"
                            error={!!errors.makeYear}
                            helperText={errors.makeYear?.message}
                            {...register('makeYear', {
                                valueAsNumber: { value: true },
                                required: { value: true, message: 'Year of make is required' },
                                minLength: { value: 4, message: 'Must be minimum 4 characters' },
                            })}
                        />
                    </Grid>
                    <Grid item xs={5} md={5}>
                        <InputLabel id="demo-simple-select-label">Category</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            type= "number"
                            value={1}
                            label="categoryName"
                            {...register('categoryName', { valueAsNumber: true })}
                        >
                            <MenuItem value={1}>Economy</MenuItem>
                            <MenuItem value={2}>Compact</MenuItem>
                            <MenuItem value={3}>Luxury</MenuItem>
                        </Select>
                    </Grid>

                    <Grid item xs={5} md={5}>
                        <TextField
                            fullWidth
                            type="number"
                            label="Daily rate"
                            variant="outlined"
                            error={!!errors.dailyRate}
                            helperText={errors.dailyRate?.message}
                            {...register('dailyRate', { valueAsNumber: true })}
                        />
                    </Grid>
                    <Grid item xs={5} md={5}>
                        <InputLabel id="demo-simple-select-label">A/C</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            value={1}
                            label="airCondition"
                            {...register('AirCondition', { valueAsNumber: true })}
                        >
                            <MenuItem value={1}>Yes</MenuItem>
                            <MenuItem value={2}>No</MenuItem>
                        </Select>
                    </Grid>
                    <Grid item xs={5} md={5}>
                        <InputLabel id="demo-simple-select-label">Navigation system</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            value={1}
                            label="navigationSystem"
                            {...register('navigationSystem', { valueAsNumber: true })}
                        >
                            <MenuItem value={1}>Yes</MenuItem>
                            <MenuItem value={2}>No</MenuItem>
                        </Select>
                    </Grid>
                    <Grid item xs={5} md={5}>
                        <TextField
                            fullWidth
                            type="number"
                            label="Seats"
                            variant="outlined"
                            error={!!errors.seats}
                            helperText={errors.seats?.message}
                            {...register('seats', { valueAsNumber: true })}
                        />
                    </Grid>
                    <Grid item xs={5} md={5}>
                        <TextField
                            fullWidth
                            type="number"
                            label="Doors"
                            variant="outlined"
                            error={!!errors.doors}
                            helperText={errors.doors?.message}
                            {...register('doors', { valueAsNumber: true })}
                        />
                    </Grid>
                    <Grid item xs={5} md={5}>
                        <InputLabel id="demo-simple-select-label">Fuel</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            value={1}
                            label="fuel"
                            {...register('fuel', { valueAsNumber: true })}
                        >
                            <MenuItem value={1}>Petrol</MenuItem>
                            <MenuItem value={2}>Diesel</MenuItem>
                            <MenuItem value={3}>Gas</MenuItem>
                        </Select>
                    </Grid>
                    <Grid item xs={5} md={5}>
                        <InputLabel id="demo-simple-select-label">Transmission</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            value={1}
                            label="transmission"
                            {...register('transmission', { valueAsNumber: true })}
                        >
                            <MenuItem value={1}>Automatic</MenuItem>
                            <MenuItem value={2}>Manual</MenuItem>
                        </Select>
                    </Grid>

                    <Grid item xs={5} md={5}>
                        <TextField
                            fullWidth
                            required
                            label="Image"
                            variant="outlined"
                            error={!!errors.imageUrl}
                            helperText={errors.imageUrl?.message}
                            {...register('imageUrl', {
                                required: { value: true, message: 'Make is required' },
                                minLength: { value: 2, message: 'Must be minimum 2 characters' },
                            })}
                        />
                    </Grid>
                </Grid>
                <Box display="flex" justifyContent="flex-end" mt={2}>
                    <Button onClick={() => reset()}>Reset</Button>
                    <Button type="submit" sx={{ margin: '0 8px' }} variant="contained" disableRipple>
                        Submit
                    </Button>
                </Box>
            </form>
        </div>
    )
}

export default CreateCar;