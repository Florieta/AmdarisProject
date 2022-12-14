import { Alert, CircularProgress } from '@mui/material'
import { useQuery } from '@tanstack/react-query'
import { toast } from 'react-toastify'
import { useAuthContext } from '../../hooks/useAuthContext';
import axios from "axios";
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from "@mui/material/Button";
import { useMutation } from "@tanstack/react-query";

const MyCars = () => {
    const { user } = useAuthContext();
    const getMyCars = () => {
        return fetch(`https://localhost:7016/api/Car/Dealer/${user.user.dealerId}`)
            .then(res => res.json())
    }

    const {
        data : cars,
        isError,
        isLoading,
        isFetching,
        refetch
      } = useQuery(['getMyCarsKey'], getMyCars, {
        retry: false,
        onError: () => toast.error('Something went wrong!'),
        refetchOnWindowFocus: false,
      })

      const carDelete = useMutation((id) => axios.delete(`https://localhost:7016/api/Car/${id}`), {
    onSuccess: () => refetch() && toast.success('The car was successfully deleted!'),
    onError: () => toast.error('Something went wrong!')
  }
);

    return (
<TableContainer component={Paper}>
{(isLoading || isFetching) && <CircularProgress />}
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Make & Model</TableCell>
            <TableCell align="right">Year</TableCell>
            <TableCell align="right">Category</TableCell>
            <TableCell align="right">Number</TableCell>
            <TableCell align="right">Daily Rate(BGN)</TableCell>
            <TableCell align="right">Fuel</TableCell>
            <TableCell align="right">Transmission</TableCell>
            <TableCell align="right">A/C</TableCell>
            <TableCell align="right">Navigation system</TableCell>
            <TableCell align="right">Seats</TableCell>
            <TableCell align="right">Doors</TableCell>
            <TableCell align="right"></TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
      {isError && <Alert severity="error">This is an error alert ??? check it out!</Alert>}
      {!isLoading && !isFetching && !isError && cars &&
          cars.map((car) => (
            <TableRow
              key={car.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {car.make} {car.model}
              </TableCell>
              <TableCell align="right">{car.makeYear}</TableCell>
              <TableCell align="right">{car.categoryName}</TableCell>
              <TableCell align="right">{car.regNumber}</TableCell>
              <TableCell align="right">{car.dailyRate}</TableCell>
              <TableCell align="right">{car.fuel}</TableCell>
              <TableCell align="right">{car.transmission}</TableCell>
              <TableCell align="right">{car.airCondition ? 'Yes' : 'No'}</TableCell>
              <TableCell align="right">{car.navigationSystem ? 'Yes' : 'No'}</TableCell>
              <TableCell align="right">{car.seats}</TableCell>
              <TableCell align="right">{car.doors}</TableCell>
              <TableCell><Button variant="outlined" color="warning">Edit</Button></TableCell>
              <TableCell><Button variant="outlined" color="error" onClick={() => carDelete.mutate(car.id)}>Delete</Button></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
);
};

export default MyCars;