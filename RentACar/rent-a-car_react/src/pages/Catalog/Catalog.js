import CatalogItem from "../../components/CatalogItem/CatalogItem";
import { CircularProgress, Alert } from '@mui/material'
import { useQuery } from '@tanstack/react-query'
import { toast } from 'react-toastify'

const Catalog = () => {
    const getCars = () => {
        return fetch('https://localhost:7016/api/Car')
            .then(res => res.json())
    }

    const {
        data: cars,
        isError,
        isLoading,
        isFetching
      } = useQuery(['getCarsKey'], getCars, {
        retry: false,
        onError: () => toast.error('Something went wrong!'),
        refetchOnWindowFocus: false,
      })

    return (
        <section id="catalog-page">
            <h1>All Cars</h1>
{(isLoading || isFetching) && <CircularProgress />}
      {isError && <Alert severity="error">This is an error alert — check it out!</Alert>}
      {!isLoading && !isFetching && !isError && cars && cars.length > 0
                ? cars.map(x => <CatalogItem key={x.id} car={x} />)
                : <h3 className="no-articles">No cars yet</h3>
            }
        </section>
    );
};

export default Catalog;