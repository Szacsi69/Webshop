import logo_footer from './img/logo_footer.png';
import './css/footer.css';

function Footer() {
    return (
        <footer className="border-top text-muted">
            <div className="container-fluid">
                <div className="text-center">
                    <div className="row d-flex align-items-center">
                        <div className="col-xl-5 col-12">
                            <img src={logo_footer} />
                        </div>
                        <div className="col-xl-3 col-12">
                            <p className="border-bottom font-weight-bold">Elérhetőségeink</p>
                            <p>
                                Tel.: 06201234567<br />
                                Email: email@email.com<br />
                                Cím: 1234 Belrum Kő utca 11
                            </p>
                        </div>
                        <div className="col-xl-4 col-12">
                            <h5 className="text-nowrap">&copy; 2022 - Webshop - Minden jog fenntartva.</h5>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    );
}

export default Footer;