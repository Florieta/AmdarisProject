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
            {user.userName && <span>{user.userName}</span>}
               <Link to="/catalog">Cars</Link>
                {user
                    ? <div id="user">
                        <Link to="/create">Create Gar</Link>
                        <Link to="/my-bookings">My bookings</Link>
                        <Link to="/logout">Logout</Link>
                    </div>
                    : <div id="guest">
                        <Link to="/login">Login</Link>
                        <Link to="/register">Register</Link>
                    </div>
                }
               
            </nav>
        </header>
    );
};

export default Header;