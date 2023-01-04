import { useState, useEffect } from 'react';

import * as bookingService from '../../services/bookingService';
import { useAuthContext } from '../../hooks/useAuthContext';

import BookingList from '../BookingList/BookingList';

const MyBookings = () => {
    const [bookings, setBookings] = useState([]);
    const { user } = useAuthContext();

    useEffect(() => {
        bookingService.getAllBookigs(user.renterId)
            .then(bookingResult => {
                setBookings(bookingResult);
            });
    }, []);

    return (
        <section id="my-pets-page" className="my-pets">
            <h1>My Bookings</h1>

            <BookingList bookings={bookings} />
        </section>
    );
}

export default MyBookings;