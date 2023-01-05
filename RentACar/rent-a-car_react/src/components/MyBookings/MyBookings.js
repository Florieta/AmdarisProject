import { useState, useEffect } from 'react';

import * as bookingService from '../../services/bookingService';
import { useAuthContext } from '../../hooks/useAuthContext';

import BookingList from '../BookingList/BookingList';

const MyBookings = () => {
    const [bookings, setBookings] = useState([]);
    const { user } = useAuthContext();

    useEffect(() => {
        bookingService.getAllBookigs(1)
            .then(bookingResult => {
                setBookings(bookingResult);
            });
    }, []);

    return (
        <section id="my-booking-page" className="my-booking">
            <h1>My Bookings</h1>

            <BookingList bookings={bookings} />
        </section>
    );
}

export default MyBookings;