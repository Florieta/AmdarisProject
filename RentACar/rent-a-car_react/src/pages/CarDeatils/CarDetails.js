
import { useQuery } from '@tanstack/react-query'
import { toast } from 'react-toastify'
import { useParams } from 'react-router-dom';
import { CircularProgress, Alert } from '@mui/material'
import CarCard from '../../components/CarCard/CarCard';
const CarDetails = () => {
   
    const { carId } = useParams();
    const getCarById = () => {
        return fetch(`https://localhost:7016/api/Car/${carId}`)
            .then(res => res.json())
    }

    const {
        data: car,
        isError,
        isLoading,
        isFetching
      } = useQuery(['getCarKey'], getCarById, {
        retry: false,
        onError: () => toast.error('Something went wrong!'),
        refetchOnWindowFocus: false,
      })
      console.log(car)
       
    return (
        <section id="car-details">
            <h1>Car Details</h1>
            {(isLoading || isFetching) && <CircularProgress />}
      {isError && <Alert severity="error">This is an error alert — check it out!</Alert>}
      {!isLoading && !isFetching && !isError && car &&
               (<div><CarCard key={car.id} car = {car}/> </div>)}
        </section>
    );
};

export default CarDetails;