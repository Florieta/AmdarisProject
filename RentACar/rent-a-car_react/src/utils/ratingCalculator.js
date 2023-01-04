export default function ratingCalculator()  {
    const ratings = [4, 5, 3, 5]
    let sum = 0;
    ratings.map(element => {
        sum += element
    });
const averageRating = sum / ratings.length;
    return averageRating;
}

