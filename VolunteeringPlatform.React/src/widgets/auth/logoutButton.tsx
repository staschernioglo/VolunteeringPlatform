import { AuthContext } from "app/App";
import { useContext } from "react";
import { Link } from "react-router-dom";
import authService from 'features/auth/authService';

const LogoutButton = () => {

    const { setLoggedStatus } = useContext(AuthContext);

    const handleLogout = () => {
        authService.logout();
        setLoggedStatus(false);
        let smt = authService.getCurrentUser();
        console.log("Logout-----");
        console.log(smt);
    }

    return (
        <Link onClick = {handleLogout} className = "account-btn" to = "/">
            LOGOUT
        </Link>
    )
}

export {LogoutButton}