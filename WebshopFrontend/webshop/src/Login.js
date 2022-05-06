import './css/account.css';
import { Link } from 'react-router-dom';

function Login() {
    return (
        <div className="container-fluid background-div">
            <div className="container form-container text-center">
                <h1 className="pb-3">Bejelentkezés</h1>
                <form action="" className="text-start pb-3">
                    <div className="mb-1">
                        <label for="username">Felhasználónév</label>
                        <input type="text" name="username" id="username" className="form-control" />
                    </div>
                    <div className="mb-4">
                        <label for="password">Jelszó</label>
                        <input type="text" name="password" id="password" className="form-control" />
                    </div>
                    <button type="submit" className="form-control custom-btn">Bejelentkezés</button>
                </form>
                <small className="text-muted">Nincs még fiókod? </small><Link to="/register">Regisztrálj!</Link><span> </span><Link to="/account">(Fiók)</Link>
            </div>
        </div>
    );
}

export default Login;