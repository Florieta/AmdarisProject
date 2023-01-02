import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';

const CarDetails = ({
    cars
}) => {
    const { carId } = useParams();

    const car = cars.find(x => x.id == carId);

    return (
        <section id="car-details">
            <h1>Car Details</h1>
            <div className="info-section">
                <div className="car-header">
                    <img className="car-img" src={car.imageUrl} />
                    <h1>{car.make} {car.model} {car.makeYear}</h1>
                    <p className="type">Category: {car.categoryName}</p>
                </div>
                <p className="text">
                    <span className="levels">{car.regNumber}</span>
                    <span className="levels">Doors: {car.doors}</span>
                    <span className="levels">Seats: {car.seats}</span>
                    <span className="levels">Transmission: {car.transmission}</span>
                    <span className="levels">Navigation: {car.navigationSystem ? "Yes" : "No"}</span>
                    <span className="levels">Aircondition: {car.airCondition ? "Yes" : "No"}</span>
                    <span className="levels">Type of fuel: {car.fuel}</span>
                    <span className="levels">Daily rate: {car.dailyRate}BGN</span>
                </p>
                {car.isAvailable
                    ? <Link to={`/booking/${car.id}`} className="btn details-btn">Book</Link>
                    : <p>Car is not available!</p>}
            </div>
        </section>
    );
};

export default CarDetails;