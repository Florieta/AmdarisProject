import { useQuery } from "@tanstack/react-query";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import * as carService from "../../services/carService.js"
import { useAuthContext } from '../../hooks/useAuthContext';


const initialValues = {
    model: "",
    make: "",
    regNumber: "",
    makeYear: "",
    dailyRate: "",
    doors: "",
    seats: "",
    fuel: "",
    transmission: "",
    navigationSystem: true,
    imageUrl: "",
    categoryId: "",
    airCondition: true,
    dealerId: "",
};
const Create = () => {
    const [formValues, setFormValues] = useState(initialValues);
    const { user } = useAuthContext();
    const navigate = useNavigate();

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
    formValues.dealerId = user.user.dealerId;

    const handleInputChange = (e) => {
        const { name, value } = e.target;

        setFormValues({
            ...formValues,
            [name]: value,
        });
    };
    console.log(formValues)

    const boolInputChange = (e) => {
        const { name, value } = e.target;
        if (value === false) {
            setFormValues({
                ...formValues,
                [name]: false,
            });
        } else {
            setFormValues({
                ...formValues,
                [name]: true,
            });
        }
    };
    const handleSubmit = (event) => {
        event.preventDefault();
        carService.create({ ...formValues })
            .then(() => {
                navigate(`/catalog`);
            });
    };



    return (
        <section id="create-page" className="auth">
            <form id="create" onSubmit={handleSubmit}>
                <div className="container">
                    <label htmlFor="categoryId"> Category: </label>
                    <select
                        id="categoryId"
                        name="categoryId"
                        type="number"
                        value={formValues.categoryId}
                        onChange={handleInputChange}
                    >
                        {data.map((x) => (
                            <option key={x.id} value={x.id}>
                                {x.categoryName}
                            </option>
                        ))}
                    </select>

                    <label htmlFor="make">Make:</label>
                    <input type="text" id="make" name="make" value={formValues.make} onChange={handleInputChange}
                        placeholder="Enter make make..." />

                    <label htmlFor="model">Model:</label>
                    <input type="text" id="model" name="model" value={formValues.model} onChange={handleInputChange}
                        placeholder="Enter make model..." />

                    <label htmlFor="reg-number">Registration number:</label>
                    <input type="text" id="reg" name="regNumber" value={formValues.regNumber} onChange={handleInputChange}
                        placeholder="Enter make registration number..." />

                    <label htmlFor="make-year">Year:</label>
                    <input type="number" id="year" name="makeYear" value={formValues.makeYear} onChange={handleInputChange} />

                    <label htmlFor="car-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" value={formValues.imageUrl} onChange={handleInputChange}
                        placeholder="Upload a photo..." />

                    <label htmlFor="type-fuel">Type of fuel:</label>
                    <select
                        id="fuel"
                        name="fuel"
                        type = "number"
                        value={formValues.fuel}
                        onChange={handleInputChange}
                    >
                        <option value={"Diesel"}>
                            Diesel
                        </option>
                        <option value={"Petrol"}>
                            Petrol
                        </option>
                        <option value={"LPG"}>
                            LPG
                        </option>
                        <option value={"Hybrid"}>
                            Hybrid
                        </option>
                        <option value={"Electric"}>
                            Electric
                        </option>
                    </select>

                    <label htmlFor="transmission">Transmission:</label>
                    <select
                        id="transmission"
                        name="transmission"
                        type = "number"
                        value={formValues.transmission}
                        onChange={handleInputChange}
                    >
                        <option value={"Automatic"}>
                            Automatic
                        </option>
                        <option value={"Manual"}>
                            Manual
                        </option>
                        <option value={"SemiAutomatic"}>
                            SemiAutomatic
                        </option>
                        <option value={"CVT"}>
                            CVT
                        </option>
                    </select>

                    <label htmlFor="rate">Daily rate:</label>
                    <input type="number" id="rate" name="dailyRate" value={formValues.dailyRate} onChange={handleInputChange} />

                    <label htmlFor="seat">Number of seats:</label>
                    <input type="number" id="seats" name="seats" vvalue={formValues.seats} onChange={handleInputChange} />

                    <label htmlFor="door">Number of doors:</label>
                    <input type="number" id="doors" name="doors" value={formValues.doors} onChange={handleInputChange} />

                    <label htmlFor="navigation">Navigation system</label>
                    <select
                        id="navigationSystem"
                        name="navigationSystem"
                        value={formValues.navigationSystem}
                        onChange={boolInputChange}
                    >
                        <option value={true}>
                            Yes
                        </option>
                        <option value={false}>
                            No
                        </option>
                    </select>
                    <label htmlFor="airCondition">Air condition</label>
                    <select
                        id="airCondition"
                        name="airCondition"
                        value={formValues.airCondition}
                        onChange={boolInputChange}
                    >
                        <option value={true}>
                            Yes
                        </option>
                        <option value={false}>
                            No
                        </option>
                    </select>

                    <input className="btn submit" type="submit" value="Add" />
                </div>
            </form>
        </section>
    );
}

export default Create;