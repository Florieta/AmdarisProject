import { useQuery } from "@tanstack/react-query";

const Create = () => {
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
                    <label htmlFor="make">Make:</label>
                    <input type="text" id="make" name="make" placeholder="Enter make make..." />

                    <label htmlFor="selectedCategory"> Category: </label>
                    <select
                        id="selectedCategory"
                    >
                        <option />
                        {data.map((x) => (
                            <option key={x.id} value={x.categoryName}>
                                {x.categoryName}
                            </option>
                        ))}
                    </select>

                    <label htmlFor="model">Model:</label>
                    <input type="text" id="model" name="model" placeholder="Enter make model..." />

                    <label htmlFor="reg-number">Registration number:</label>
                    <input type="text" id="reg" name="regNumber" placeholder="Enter make registration number..." />

                    <label htmlFor="make-year">Year:</label>
                    <input type="text" id="year" name="year" placeholder="Enter make year..." />

                    <label htmlFor="car-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo..." />

                    <label htmlFor="type-fuel">Type of fuel:</label>
                    <input type="text" id="fuel" name="fuel" />

                    <label htmlFor="transmission">Transmission:</label>
                    <input type="text" id="transmission" name="transmission" />

                    <label htmlFor="rate">Daily rate:</label>
                    <input type="number" id="rate" name="rate" />

                    <label htmlFor="seat">Number of seats:</label>
                    <input type="number" id="seats" name="seats" />

                    <label htmlFor="door">Number of doors:</label>
                    <input type="number" id="doors" name="doors" />

                    <label htmlFor="navigation">Navigation system</label>
                    <input type="number" id="nav" name="navigation" />

                    <label htmlFor="airCondition">Air condition</label>
                    <input type="number" id="airCondition" name="airConidtion" />

                    <input className="btn submit" type="submit" value="Add" />
                </div>
            </form>
        </section>
    );
}

export default Create;