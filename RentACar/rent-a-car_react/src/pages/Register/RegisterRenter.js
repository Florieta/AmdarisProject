import { Link } from "react-router-dom";
import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../context/AuthContext";
import * as authService from "../../services/authService";


const RegisterRenter = () => {
    const { userRegister } = useContext(AuthContext);
    const navigate = useNavigate();

    const onSubmit = (e) => {
        e.preventDefault();

        const {
            userName,
            password,
            email,
            firstName,
            lastName,
            phoneNumber,
            age,
            drivingLicenceNumber,
            expiredDate,
            address
        } = Object.fromEntries(new FormData(e.target));

        authService.register(userName, password, email, firstName, lastName, phoneNumber, address, age, drivingLicenceNumber, expiredDate)
            .then(authData => {
                console.log(authData)
                userRegister(authData);
                navigate('/');
            })
    };

    return (
        <section id="register-page" className="content auth">
            <form id="register" onSubmit={onSubmit}>
                <div className="container">
                    <div className="brand-logo" />
                    <h1>Register as renter</h1>

                    <label htmlFor="userName">Username:</label>
                    <input
                        type="text"
                        id="userName"
                        name="userName"
                        placeholder="Your username..."
                    />

                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        placeholder="email@gmail.com"
                    />

                    <label htmlFor="pass">Password:</label>
                    <input
                        type="password"
                        name="password"
                        id="register-password"
                    />

                    <label htmlFor="firstName">First name:</label>
                    <input
                        type="text"
                        name="firstName"
                        id="firstName"
                    />

                    <label htmlFor="lastName">Last name:</label>
                    <input
                        type="text"
                        name="lastName"
                        id="lastName"
                    />

                    <label htmlFor="phoneNumber">Phone number:</label>
                    <input
                        type="text"
                        name="phoneNumber"
                        id="phoneNumber"
                    />

                    <label htmlFor="age">Age:</label>
                    <input
                        type="number"
                        name="age"
                        id="age"
                    />

                    <label htmlFor="address">Address:</label>
                    <input
                        type="text"
                        name="address"
                        id="address"
                    />

                    <label htmlFor="drivingLicenceNumber">Driving license number:</label>
                    <input
                        type="text"
                        name="drivingLicenceNumber"
                        id="drivingLicenceNumber"
                    />

                    <label htmlFor="expiredDate">Expired date:</label>
                    <input
                        type="date"
                        name="expiredDate"
                        id="expiredDate"
                    />

                    <input className="btn submit" type="submit" defaultValue="Register" />
                    <p className="field">
                        <span>
                            If you already have profile click <Link to="/login">here</Link>
                        </span>
                    </p>
                </div>
            </form>
        </section>
    );
};

export default RegisterRenter;
