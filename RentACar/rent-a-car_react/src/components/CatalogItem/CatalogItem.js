import { Link } from 'react-router-dom';

const CatalogItem = ({ car }) => {
    return (
        <div className="allCars">
            <div className="allCars-info">
                <img src={car.imageUrl} />
                <h2>{car.make}  {car.model} {car.makeYear}</h2>
                <h6>Category: {car.categoryName}</h6>
                <Link to={`/catalog/${car.id}`} className="details-button">
                    Details
                </Link>
            </div>
        </div>
    );
};

export default CatalogItem;
