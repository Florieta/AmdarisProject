import { Link } from "react-router-dom";

const Header = () => {
    return (
        <header>
            <h1>
                <Link className="home" to="/">Rent a Car
                </Link>
                </h1>
            <nav>
                <Link to="/catalog">Cars</Link>
                <div id="user">
                    <Link to="/create">Create Car</Link>
                    <Link to="/logout">Logout</Link>
                </div>
                <div id="guest">
                    <Link to="/login">Login</Link>
                    <Link to="/register">Register</Link>
                </div>
            </nav>
        </header>
    );
};

export default Header;