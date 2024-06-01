import { Link } from "react-router-dom";
//import { useNavigate } from "react-router-dom";

export default function Navigation() {
    return (
        <header>
            <nav className="nav">
                <ul className="nav-list">
                    <li>
                        <Link to="/Register">
                            Register
                        </Link>
                    </li>
                    <li>
                        <Link to="/Login">
                            Login
                        </Link>
                    </li>
                </ul>
            </nav>
        </header>
    )
}