import logo from './img/logo.png';
import cartIcon from './img/cart_icon.png';
import userIcon from './img/user_icon.png';
import {Nav, Navbar} from 'react-bootstrap';
import './css/header.css'; 


function Header({ loggedIn }) {

    return (
        <header>
            <div className="container-fluid">
                <div className="row">
                    <Navbar expand="xl" bg="light" className="col-xl-11 col-9">
                        <div className="d-flex align-items-center">
                            <Navbar.Brand href="/"><img src={logo} /></Navbar.Brand>
                            <Navbar.Toggle area-controls="navbarMenu" />
                        </div>
                        <Navbar.Collapse id="navbarMenu">
                            <Nav className="me-auto">
                                <Nav.Link className="border-end" href="/">Főoldal</Nav.Link>
                                <Nav.Link className="border-end" href="/shop/computers">Számítógépek, laptopok</Nav.Link>
                                <Nav.Link className="border-end">Telefonok, tabletek</Nav.Link>
                                <Nav.Link className="border-end" href="/shop/homeappliances">Háztartási gépek</Nav.Link>
                                <Nav.Link className="border-end">Kert- és barkácseszközök</Nav.Link>
                                <Nav.Link href="/aboutus">Rólunk</Nav.Link>
                            </Nav>
                        </Navbar.Collapse>
                    </Navbar>
                    { loggedIn &&
                        <Navbar expand bg="light" className="ps-0 col-xl-1 col-3">
                            <Nav className="ms-auto">
                                <Nav.Link><img src={cartIcon} /></Nav.Link>
                                <Nav.Link href="/account"><img src={userIcon} /></Nav.Link>
                            </Nav>
                        </Navbar>
                    }
                    { !loggedIn &&
                        <Navbar expand bg="light" className="ps-0 col-xl-1 col-3">
                            <Nav className="ms-auto">
                                <Nav.Link><img src={cartIcon} /></Nav.Link>
                                <Nav.Link href="/login"><img src={userIcon} /></Nav.Link>
                            </Nav>
                        </Navbar>
                    }
                </div>
            </div>
        </header>
    );
}

export default Header;
