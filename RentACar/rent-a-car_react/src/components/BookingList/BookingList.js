
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import CancelButton from '../Button/CancelBooking';

const BookingList = ({bookings}) => {
    return (
<TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Make & Model</TableCell>
            <TableCell align="right">Reg number</TableCell>
            <TableCell align="right">Pick up date&time</TableCell>
            <TableCell align="right">Drop off date&time</TableCell>
            <TableCell align="right">Duration</TableCell>
            <TableCell align="right">Pick up location</TableCell>
            <TableCell align="right">Drop off location</TableCell>
            <TableCell align="right">Insurance</TableCell>
            <TableCell align="right">Payment type</TableCell>
            <TableCell align="right">Total amount</TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {bookings.map((booking) => (
            <TableRow
              key={booking.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {booking.carMake} {booking.carModel} 
              </TableCell>
              <TableCell align="right">{booking.regNumber}</TableCell>
              <TableCell align="right">{booking.pickUpDateAndTime}</TableCell>
              <TableCell align="right">{booking.dropOffDateAndTime}</TableCell>
              <TableCell align="right">{booking.duration}</TableCell>
              <TableCell align="right">{booking.pickUpLocation}</TableCell>
              <TableCell align="right">{booking.dropOffLocation}</TableCell>
              <TableCell align="right">{booking.insurance ? 'Yes' : 'No'}</TableCell>
              <TableCell align="right">{booking.paymentType}</TableCell>
              <TableCell align="right">{booking.totalAmount}</TableCell>
              <CancelButton></CancelButton>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
);
};

export default BookingList;