import "./Error.Module.css";
import { useRouteError } from "react-router-dom";

const ErrorPage = ({
    children
}) => {
    const error = useRouteError();
    return (

        <section id="catalog-page" className="error-page">
            <h1>Oops!</h1>
            <p>Sorry, an error has occurred.</p>
            {error && error.status && <h4>{error.status}</h4>}
            <p>
                {error && <i>{error.statusText || error.message}</i>}
            </p>
            {children && <p className="no-articles">{children}</p>}
        </section>
    );
}

export default ErrorPage;