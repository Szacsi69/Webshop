import './css/account.css';
import { Link } from 'react-router-dom';

function Register() {
    return (
        <div className="container-fluid background-div">
            <div className="container form-container text-center">
                <h1 className="pb-3">Regisztráció</h1>
                <form action="" className="text-start pb-3">
                    <div className="mb-2">
                        <label for="username">Felhasználónév</label>
                        <input type="text" name="username" id="username" className="form-control" />
                    </div>
                    <div className="mb-2">
                        <label for="password">Jelszó</label>
                        <input type="text" name="password" id="password" className="form-control" />
                        <label for="password-again">Jelszó újra</label>
                        <input type="text" name="password-again" id="password-again" className="form-control" />
                    </div>
                    <div className="mb-4">
                        <label for="email">Email cím</label>
                        <input type="text" name="email" id="email" className="form-control" />
                    </div>
                    <button type="submit" className="form-control custom-btn">Regisztráció</button>
                </form>
                <small className="text-muted">Van már fiókod? </small><Link to="/login">Jelentkezz be!</Link>
            </div>
        </div>
    );
}

export default Register;