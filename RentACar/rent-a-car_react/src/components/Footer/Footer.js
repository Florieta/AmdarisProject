import { Link } from "react-router-dom";
import './Footer.Module.css';

const Footer = () => {
    const year = new Date().getFullYear();

    return (
        <footer className="main-footer">
            <strong>Copyright &copy; {year} <Link to="/">Rental A Car</Link></strong> All rights reserved!
        </footer>
    )
};

export default Footer;