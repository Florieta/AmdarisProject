import { CircularProgress, Alert } from '@mui/material'
import { useQuery } from '@tanstack/react-query'
import { toast } from 'react-toastify'
import LatestCars from "../../components/LatestCars/LatestCars.js"


const Home = () => {
    const getCars = () => {
        return fetch('https://localhost:7016/api/Car')
            .then(res => res.json())
    }

    const {
        data,
        isError,
        isLoading,
        isFetching
      } = useQuery(['getCarsKey'], getCars, {
        retry: false,
        onError: () => toast.error('Something went wrong!'),
        refetchOnWindowFocus: false,
      })

    return (
       
        <section id="welcome-world">
            <div className="welcome-message">
                <h2>ALL new cars are here</h2>
            </div>

            <div id="home-page">
                <h1>Latest Cars</h1>
                {(isLoading || isFetching) && <CircularProgress />}
      {isError && <Alert severity="error">This is an error alert — check it out!</Alert>}
      {!isLoading && !isFetching && !isError && data && data.length > 0
                    ? data.map(x => <LatestCars key={x.id} car={x} />)
                    : <p className="no-articles">No cars yet</p>
                }
            </div>
        </section>
    );
};

export default Home;