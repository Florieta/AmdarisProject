const BookingForm = () => {
    return (
        <section id="create-page" className="auth">
            <form id="create">
                <div className="container">
                    <h1>Booking</h1>
                    <label htmlFor="leg-title">Pick up date:</label>
                    <input
                        type="date"
                        id="title"
                    />
                  </div>
            </form>
        </section>
    );
};

export default BookingForm;