import { useQuery } from "@tanstack/react-query";
import TextField from "@mui/material/TextField";
import MenuItem from "@mui/material/MenuItem";
import { toast } from 'react-toastify'

const BookingForm = () => {
    const getCategories = () => {
        return fetch('https://localhost:7016/api/Category')
            .then(res => res.json())
    }

    const { isLoading, isError, data, error } = useQuery({
        queryKey: ['categories'],
        queryFn: getCategories,
    })

    if (isLoading) {
        return <span>Loading...</span>
    }

    if (isError) {
        return <span>Error: {error.message}</span>
    }




    return (
        <section id="create-page" className="auth">
            <form id="create">
                <div className="container">

                    <label
                        htmlFor="selectedCategory"
                        style={{ display: 'flex', gap: '10px', alignItems: 'center', fontSize: '24px' }}
                    >
                        Category
                        <select
                            style={{ fontSize: '24px' }}
                            id="selectedCategory"

                        >
                            <option />
                            {data.map((x) => (
                                <option key={x.id} value={x.categoryName}>
                                    {x.categoryName}
                                </option>
                            ))}
                        </select>
                    </label>
                    <label htmlFor="pick-up-date">PickUpDate:</label>
                    <input type="datetime-local" id="pickup" name="pickup" />

                    <label htmlFor="drop-off-date">DropOffDate:</label>
                    <input type="datetime-local" id="dropoff" name="dropoff" />

                    <label htmlFor="duration">Duration:</label>
                    <input type="number" id="title" name="title" />

                    <label htmlFor="pick-up-location">Pick-up location:</label>
                    <input type="text" id="pickUpLocation" name="locationpick" />

                    <label htmlFor="drop-off-location">Drop off location:</label>
                    <input type="text" id="dropOffLocation" name="locationdrop" />

                    <TextField
                        id="select"
                        label="Payment"
                        name="payment"
                        select
                    >
                        <MenuItem value={"card"}>Card</MenuItem>
                        <MenuItem value={"cash"}>Cash</MenuItem>
                        <MenuItem value={"bank transfer"}>Crypto</MenuItem>
                    </TextField>

                    <label htmlFor="total-amount">Total amount:</label>
                    <input type="number" id="total" name="total" />
                    <input className="btn submit" type="submit" value="Submit" />
                </div>
            </form>
        </section>
    );
}

export default BookingForm;