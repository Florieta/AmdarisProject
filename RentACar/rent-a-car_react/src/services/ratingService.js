const baseUrl = 'https://localhost:7016/api';

export const getAllRatingsByCar = (carId) => {
    return fetch(`${baseUrl}/Rating/${carId}`)
        .then(res => res.json())
};