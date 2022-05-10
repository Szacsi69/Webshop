import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Header from './Header';
import Footer from './Footer';
import Home from './Home';
import AboutUs from './AboutUs';
import Login from './Login';
import Register from './Register';
import Account from './Account';
import Shop from './Shop';
import Details from './Details';

import { useState, useEffect } from 'react';

function App() {

    const [customer, setCustomer] = useState(null);
    const [loggedIn, setLoggedIn] = useState(false);
    useEffect( () => {
        (
            async () => {
                const response = await fetch('https://localhost:44397/Auth/customer', {
                    headers: {'Content-Type': 'application/json'},
                    credentials: 'include'
                });
                if (response.ok) {
                    const content = await response.json();
                    setCustomer(content);
                    setLoggedIn(true);
                }
                else {
                    setLoggedIn(false);
                }
            }
        )();
    },
        []
    );

    return (
        <Router>
            <Header loggedIn = {loggedIn}/>
            <div className="content">
                <Routes>
                    <Route exact path="/" element={<Home />} />
                    <Route exact path="/shop/:category" element={<Shop />} />
                    <Route exact path="/aboutus" element={<AboutUs />} />
                    <Route exact path="/register" element={<Register />} />
                    <Route exact path="/login" element={<Login setLoggedIn={setLoggedIn} />} />
                    <Route exact path="/account" element={<Account customer={customer} setLoggedIn={setLoggedIn} />} />

                    <Route exact path="/shop/:category/:id" element={<Details />} />
                </Routes>
            </div>
            <Footer />
        </Router>
    );
}

export default App;