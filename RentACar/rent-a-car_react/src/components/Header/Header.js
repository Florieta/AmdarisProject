import { Link } from "react-router-dom";
import { useAuthContext } from "../../hooks/useAuthContext.js"

const Header = () => {
    const { user } = useAuthContext();

    return (
        <header>
            <h1>
                <Link className="home" to="/">Rent a Car
                </Link>
            </h1>
            <nav>
                {user.token && <span>Welcome, {user.user.userName}!</span>}
                <Link to="/catalog">Cars</Link>
                {user.token
                    ? <div id="user">
                        {!user.user.renterId
                            ? <div id="dealer">
                                <Link to="/create">Add Car</Link>
                                <Link to="/my-cars">My cars</Link>
                                <Link to="/logout">Logout</Link>
                            </div>
                            : <div id="renter">
                                <Link to="/my-bookings">My bookings</Link>
                                <Link to="/logout">Logout</Link>
                            </div>}

                    </div>
                    : <div id="guest">
                        <Link to="/login">Login</Link>
                        <Link to="/register-renter">Register as renter</Link>
                        <Link to="/register-dealer">Register as dealer</Link>
                    </div>
                }

            </nav>
        </header>
    );
};

export default Header;