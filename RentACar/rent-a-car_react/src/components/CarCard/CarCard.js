import { Link } from "react-router-dom";
import { useAuthContext } from '../../hooks/useAuthContext';

const CarCard = ( {car}) => {
    const { user } = useAuthContext();
    return (
        <div className="info-section">
                <div className="car-header">
                    <img className="car-img" src={car.imageUrl} />
                    <h1>{car.make} {car.model} {car.makeYear}</h1>
                    <p className="type">Category: {car.categoryName}</p>
                </div>
                <div className="text">
                    <p>Registration number: {car.regNumber}</p>
                    <p>Transmission: {car.transmission}</p>
                    <p>Fuel: {car.fuel}</p>
                    <p>Navigation system: {car.navigationSystem ? "Yes" : "No"}</p>
                    <p>A/C: {car.airCondition ? "Yes" : "No"}</p>
                    <p>Doors: {car.doors}</p>
                    <p>Seats: {car.seats}</p>
                    <p>Daily rate: {car.dailyRate}BGN</p>
                </div>
                {user.token
                    ? <Link to={`/booking/${car.id}`} className="btn details-btn">Book</Link>
                    : <p className="alter-text">You need to login first in order to book! 
                    <Link to="/login" className="btn details-btn">Login</Link></p>}
            </div>
    );
};

export default CarCard;