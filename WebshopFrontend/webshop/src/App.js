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

function App() {
    return (
        <Router>
            <Header />
            <div className="content">
                <Routes>
                    <Route exact path="/" element={<Home />} />
                    <Route exact path="/shop/:category" element={<Shop />} />
                    <Route exact path="/aboutus" element={<AboutUs />} />
                    <Route exact path="/login" element={<Login />} />
                    <Route exact path="/register" element={<Register />} />
                    <Route exact path="/account" element={<Account />} />

                    <Route exact path="/shop/:category/:id" element={<Details />} />
                </Routes>
            </div>
            <Footer />
        </Router>
    );
}

export default App;