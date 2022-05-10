import './css/account.css';
import { Link, Navigate } from 'react-router-dom';
import {useState, useEffect} from 'react';

function Register() {
    const initValues = { username: '', password: '', passwordAgain: '', email: ''};
    const [formValues, setFormValues] = useState(initValues);
    const [formErrors, setFormErrors] = useState({});
    const [isSubmit, setIsSubmit] = useState(false);

    const [redirect, setRedirect] = useState(false);

    const submit = async (e) => {
        e.preventDefault();
        setIsSubmit(true);
        if (Object.keys(formErrors).length === 0) {
            var response = await fetch('https://localhost:44397/Auth/register', {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify({
                    username: formValues.username,
                    password: formValues.password,
                    email: formValues.email
                })
            });

            if (response.ok) {
                setRedirect(true);
            }
            else {
                const content = await response.json();
                const errors = {...formErrors};
                errors.registerFailure = content.message;
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
        if (!formValues.passwordAgain) {
            errors.passwordAgain = 'A jelszó megadása kötelező!';
        }
        else if (formValues.password !== formValues.passwordAgain) {
            errors.passwordAgain = 'A megadott jelszavak nem egyeznek!';
        }
        if (!formValues.email) {
            errors.email = 'Az email megadása kötelező!';
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
        return <Navigate to="/login" />
    }

    return (
        <div className="container-fluid background-div">
            <div className="container form-container text-center">
                <h1 className="pb-3">Regisztráció</h1>
                <form action="" className="text-start pb-3" onSubmit = {submit}>
                    { isSubmit && formErrors.registerFailure &&
                    <div className="alert-danger p-2 mb-1">{formErrors.registerFailure}</div>
                    }
                    <div className="mb-2">
                        <label for="username">Felhasználónév</label>
                        <input type="text" name="username" id="username" className="form-control"
                            onChange={e => handleChange(e)} />
                        { isSubmit &&
                        <p className="text-danger"> {formErrors.username} </p>
                        }
                    </div>
                    <div className="mb-2">
                        <label for="password">Jelszó</label>
                        <input type="password" name="password" id="password" className="form-control"
                             onChange={e => handleChange(e)} />
                        { isSubmit &&
                        <p className="text-danger"> {formErrors.password} </p>
                        }
                        <label for="passwordAgain">Jelszó újra</label>
                        <input type="password" name="passwordAgain" id="passwordAgain" className="form-control"
                            onChange={e => handleChange(e)} />
                        { isSubmit &&
                        <p className="text-danger"> {formErrors.passwordAgain} </p>
                        }
                    </div>
                    <div className="mb-4">
                        <label for="email">Email cím</label>
                        <input type="text" name="email" id="email" className="form-control" 
                             onChange={e => handleChange(e)}/>
                        { isSubmit &&
                        <p className="text-danger"> {formErrors.email} </p>
                        }
                    </div>
                    <button type="submit" className="form-control custom-btn">Regisztráció</button>
                </form>
                <small className="text-muted">Van már fiókod? </small><Link to="/login">Jelentkezz be!</Link>
            </div>
        </div>
    );
}

export default Register;