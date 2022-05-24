import './css/account.css';
import { Link, Navigate } from 'react-router-dom';
import {useState, useEffect} from 'react';

function Login({ setLoggedIn }) {
    const initValues = { username: '', password: ''};
    const [formValues, setFormValues] = useState(initValues);
    const [formErrors, setFormErrors] = useState({});
    const [isSubmit, setIsSubmit] = useState(false);

    const [redirect, setRedirect] = useState(false);


    const submit = async (e) => {
        e.preventDefault();
        setIsSubmit(true);
        if (Object.keys(formErrors).length === 0) {
                    
            const response = await fetch('https://localhost:44397/auth/login', {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                credentials: 'include',
                body: JSON.stringify({
                    username: formValues.username,
                    password: formValues.password
                })
            });
            
            if (response.ok) {
                setLoggedIn(true);
                setRedirect(true);
            }
            else {
                const content = await response.json();
                
                const errors = {...formErrors};
                errors.loginFailure = content.message;
                setFormErrors(errors);
            }
        }
    }

    useEffect( () => {
        const errors = {};
        if (!formValues.username) {
            errors.username = 'A felhasználónév megadása kötelező!';
        }
        if (!formValues.password) {
            errors.password = 'A jelszó megadása kötelező!';
        }
        setFormErrors(errors);
    },
        [formValues]
    );

    const handleChange = (e) => {
        const { name, value} = e.target;
        setFormValues({...formValues, [name]: value});
        setIsSubmit(false);
    }

    if (redirect) {
        return <Navigate to="/" />
    }

    return (
        <div className="container-fluid background-div">
            <div className="container form-container text-center">
                <h1 className="pb-3">Bejelentkezés</h1>
                <form action="" className="text-start pb-3" onSubmit={submit}>
                    { isSubmit && formErrors.loginFailure &&
                    <div className="alert-danger p-2 mb-1">{formErrors.loginFailure}</div>
                    }
                    <div className="mb-1">
                        <label htmlFor="username">Felhasználónév</label>
                        <input type="text" name="username" id="username" className="form-control"
                            onChange={e => handleChange(e)} />
                        { isSubmit &&
                        <p className="text-danger"> {formErrors.username} </p>
                        }
                    </div>
                    <div className="mb-4">
                        <label htmlFor="password">Jelszó</label>
                        <input type="password" name="password" id="password" className="form-control"
                        onChange={e => handleChange(e)} />
                        { isSubmit &&
                        <p className="text-danger"> {formErrors.password} </p>
                        }
                    </div>
                    <button type="submit" className="form-control custom-btn" onClick={e => e.blur()}>Bejelentkezés</button>
                </form>
                <small className="text-muted">Nincs még fiókod? </small><Link to="/register">Regisztrálj!</Link>
            </div>
        </div>
    );
}

export default Login;