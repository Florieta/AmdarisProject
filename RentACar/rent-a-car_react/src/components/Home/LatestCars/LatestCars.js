import { Link } from "react-router-dom";
import React from 'react';
import ratingCalculator from "../../../utils/ratingCalculator";

const LatestCars = ({
    car
}) => {
    return (
        <div className="game">
        <div className="image-wrap">
            <img src={car.imageUrl} alt="car"/>
        </div> 
        <h3>{car.make} {car.model}</h3>
        <h4>Category: {car.categoryName}</h4>
        <div className="rating">
        <p>Rating: {ratingCalculator()}</p>
            <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
        </div>
        <div className="data-buttons">
            <Link to={`/catalog/${car.id}`} className="btn details-btn">Details</Link>
        </div>
    </div>
    );
};

export default LatestCars;