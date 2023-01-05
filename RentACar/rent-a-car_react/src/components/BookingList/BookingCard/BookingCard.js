
const BookingCard = ({
    booking
}) => {
    return (
        <li className="otherBooking">
            <p>PickUpDate: {booking.pickUpDateAndTime}</p>
            <p>DropOffDate: {booking.dropOffDateAndTime}</p>
            <p>Car Info: {booking.make} {booking.model} {booking.regNumber}</p>
            <p>TotalAmount: {booking.totalAmount} </p>
            <p>Duration: {booking.duration}</p>
            <p>Payment type: {booking.paymentType}</p>
            <p>Pick-up location: {booking.pickUpLocation}</p>
            <p>Drop-off location: {booking.dropOffLocation}</p>
            <p>Insurance: {booking.insurance ? "Included" : "Not included"}</p>
        </li>
    );
}

export default BookingCard;