import { Link } from "react-router-dom";
import React from 'react';
import { useState, useEffect } from "react";
import * as ratingService from "../../../services/ratingService";
import ratingCalculator from "../../../utils/ratingCalculator";

const LatestCars = ({
    car
}) => {
    const [ratings, setRatings] = useState([]);

    useEffect(() => {
        ratingService.getAllRatingsByCar(car.id)
            .then(ratingResult => {
                console.log(ratingResult)
                setRatings(ratingResult);
            });
    }, []);

    const averageRating = ratingCalculator(ratings.map(x => x.rate, [] ));

    return (
        <div className="game">
        <div className="image-wrap">
            <img src={car.imageUrl} alt="car"/>
        </div> 
        <h3>{car.make} {car.model}</h3>
        <h4>Category: {car.categoryName}</h4>
        <div className="rating">
        <p>Rating: {averageRating}</p>
        <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span> 
        </div>
        <div className="data-buttons">
            <Link to={`/catalog/${car.id}`} className="btn details-btn">Details</Link>
        </div>
    </div>
    );
};

export default LatestCars;