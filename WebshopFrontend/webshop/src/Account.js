import userProfileImg from './img/user_icon.png';
import './css/account.css';

import { Navigate } from 'react-router-dom';
import { useState, useEffect } from 'react';

function Account({customer, setLoggedIn}) {

    const [fullName, setFullName] = useState('');
    const [gender, setGender] = useState('');
    const [email, setEmail] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [country, setCountry] = useState('');
    const [county, setCounty] = useState('');
    const [city, setCity] = useState('');
    const [address, setAddress] = useState('');

    const [redirect, setRedirect] = useState(false);

    useEffect( () => {
        if (customer) {
            setFullName(customer.fullName);
            setGender(customer.gender);
            setEmail(customer.emailAddress);
            setPhoneNumber(customer.phoneNumber);
            setCountry(customer.country);
            setCounty(customer.county);
            setCity(customer.town_City);
            setAddress(customer.addressLine);
        }
    },
        [customer]
    );
    
    const logout = async () => {
        await fetch('https://localhost:44397/Auth/logout', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include'
        });
        setLoggedIn(false);
        setRedirect(true);
    }

    const saveCustomerData = async (e) => {
        e.preventDefault();
        await fetch('https://localhost:44397/Auth/save', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include',
            body: JSON.stringify({
                fullName,
                gender,
                email,
                phoneNumber,
                country,
                county,
                city,
                address
            })
        });
        window.location.reload(false);
    }

    if (redirect) {
        return <Navigate to="/login" />
    }
    else {
        return (
            
            <div className="container-fluid background-div">
                { customer &&
                <div className="container form-container text-center mb-2">
                    <h1 className="pb-3">Fiókom</h1>
                    <div className="row">
                        <div className="col-xl-8">
                            <form action="" className="text-start pb-3">
                                <div className="mb-2">
                                    <label htmlFor="name">Név</label>
                                    <input type="text" name="name" id="name" className="form-control"
                                        placeholder={fullName} onChange={e => setFullName(e.target.value)} />
                                </div>
                                <div className="mb-2">
                                    <label htmlFor="gender">Nem</label>
                                    <select name="gender" id="gender" className="form-control" value={gender} onChange={e => setGender(e.target.value)}>
                                        <option value="male">Férfi</option>
                                        <option value="female">Nő</option>
                                    </select>
                                </div>
                                <div className="mb-2">
                                    <label htmlFor="email">Email cím</label>
                                    <input type="text" name="email" id="email" className="form-control"
                                        placeholder={email} onChange={e => setEmail(e.target.value)} />
                                </div>
                                <div className="mb-2">
                                    <label htmlFor="telephone">Telefonszám</label>
                                    <input type="text" name="telephone" id="telephone" className="form-control"
                                        placeholder={phoneNumber} onChange={e => setPhoneNumber(e.target.value)}/>
                                </div>
                                <div className="mb-2">
                                    <label htmlFor="country">Ország</label>
                                    <input type="text" name="country" id="country" className="form-control"
                                        placeholder={country} onChange={e => setCountry(e.target.value)} />
                                </div>
                                <div className="mb-2">
                                    <label htmlFor="region">Régió</label>
                                    <input type="text" name="region" id="region" className="form-control"
                                        placeholder={county} onChange={e => setCounty(e.target.value)}/>
                                </div>
                                <div className="mb-2">
                                    <label htmlFor="city">Város/Település</label>
                                    <input type="text" name="city" id="city" className="form-control"
                                        placeholder={city} onChange={e => setCity(e.target.value)}/>
                                </div>
                                <div className="mb-4">
                                    <label htmlFor="address">Utca, házszám</label>
                                    <input type="text" name="address" id="address" className="form-control"
                                        placeholder={address} onChange={e => setAddress(e.target.value)}/>
                                </div>
                                <button type="submit" className="form-control custom-btn" onClick={saveCustomerData}>Mentés</button>
                            </form>
                        </div>
                        <div className="col-xl-4">
                            <img src={userProfileImg} className="user-profile-pic" />
                            <small className="d-block">{customer.loginName}</small>
                            <button className="form-control btn-danger" onClick={logout}>Kijelentkezés</button>
                        </div>
                    </div>
                </div>
                }
            </div>
        );
    }
}

export default Account;