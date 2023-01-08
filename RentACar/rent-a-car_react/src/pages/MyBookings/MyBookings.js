import { CircularProgress, Alert } from '@mui/material'
import { useQuery } from '@tanstack/react-query'
import { toast } from 'react-toastify'
import BookingList from '../../components/BookingList/BookingList';
import { useAuthContext } from '../../hooks/useAuthContext';

const MyBookings = () => {
    const { user } = useAuthContext();
    const getMyBookings = () => {
        return fetch(`https://localhost:7016/api/Order/Renter/${user.user.renterId}`)
            .then(res => res.json())
    }

    const {
        data : bookings,
        isError,
        isLoading,
        isFetching
      } = useQuery(['getMyBookingsKey'], getMyBookings, {
        retry: false,
        onError: () => toast.error('Something went wrong!'),
        refetchOnWindowFocus: false,
      })
      
    return (
        <section id="my-booking-page" className="my-booking">
            {(isLoading || isFetching) && <CircularProgress />}
      {isError && <Alert severity="error">This is an error alert — check it out!</Alert>}
      {!isLoading && !isFetching && !isError && bookings && bookings.length > 0 &&
            <BookingList bookings={bookings} />}
        </section>
    );
}

export default MyBookings;