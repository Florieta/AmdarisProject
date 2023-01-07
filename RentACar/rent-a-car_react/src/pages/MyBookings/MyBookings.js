import { useState, useEffect } from 'react';
import * as bookingService from '../../services/bookingService';
import BookingList from '../../components/BookingList/BookingList';

const MyBookings = () => {
    const [bookings, setBookings] = useState([]);

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