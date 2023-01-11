const baseUrl = 'https://localhost:7016/api';

export const getAllRatingsByCar = async (carId) => {
    try {
        const response = await fetch(`${baseUrl}/Rating/${carId}`);
        if (response.ok) {
            const result = await response.json();

            return result;
        }
        else {
            throw new Error('No ratings at the moments');
        }
    }
    catch (err) {
        return null;
    }


};