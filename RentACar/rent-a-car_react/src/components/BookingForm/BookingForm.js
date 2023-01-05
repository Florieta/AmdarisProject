const BookingForm = () => {
    return (
        <section id="create-page" className="auth">
            <form id="create">
                <div className="container">
                <label htmlFor="pick-up-date">PickUpDate:</label>
                    <input type="datetime-local" id="pickup" name="pickup" />

                    <label htmlFor="drop-off-date">DropOffDate:</label>
                    <input type="datetime-local" id="dropoff" name="dropoff" />

                    <label htmlFor="duration">Duration:</label>
                    <input type="number" id="title" name="title"/>

                    <label htmlFor="pick-up-location">Pick-up location:</label>
                    <input type="text" id="pickUpLocation" name="locationpick" />

                    <label htmlFor="drop-off-location">Drop off location:</label>
                    <input type="text" id="dropOffLocation" name="locationdrop" />

                    <label htmlFor="payment-type">Payment type:</label>
                    <input type="text" id="paymentType" name="payment" />

                    <label htmlFor="total-amount">Total amount:</label>
                    <input type="number" id="total" name="total" />
                    <input className="btn submit" type="submit" value="Submit" />
                </div>
            </form>
        </section>
    );
}

export default BookingForm;