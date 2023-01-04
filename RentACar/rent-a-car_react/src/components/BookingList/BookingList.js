import BookingCard from "./BookingCard/BookingCard";

const BookingList = ({
    bookings
}) => {
    return (
        <>
            {bookings.length > 0
                ? (
                    <ul className="other-bookings-list">
                        {bookings.map(x => <BookingCard key={x.id} booking={x} />)}
                    </ul>
                ) 
                : <p className="no-bookings">You do not have any bookings!</p>
            }
        </>
    );
}

export default BookingList;