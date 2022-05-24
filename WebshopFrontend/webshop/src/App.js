import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Header from './components/header/Header';
import Footer from './components/footer/Footer';
import Home from './components/home/Home';
import AboutUs from './components/aboutus/AboutUs';
import Login from './components/account/Login';
import Register from './components/account/Register';
import Account from './components/account/Account';
import Shop from './components/shop/Shop';
import Details from './components/details/Details';
import Cart from './components/cart/Cart';

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
                    <Route exact path="/cart" element={<Cart />} />
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