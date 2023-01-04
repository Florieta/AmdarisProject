
const BookingCard = ({
    booking
}) => {
    return (
        <li className="otherBooking">
            <p>PickUpDate: {booking.pickUpDate}</p>
            <p>DropOffDate: {booking.dropOffDate}</p>
            <p>TotalAmount: {booking.totalAmount} </p>
        </li>
    );
}

export default BookingCard;