import slideImg from './img/slide_img.png';
import {Carousel} from 'react-bootstrap';
import './css/home.css';

function Home() {
    return (
    <div id="slides" className="carousel slide" data-ride="carousel">
        <Carousel>
            <Carousel.Item><img src={slideImg} /></Carousel.Item>
            <Carousel.Item><img src={slideImg} /></Carousel.Item>
            <Carousel.Item><img src={slideImg} /></Carousel.Item>
        </Carousel>
    </div>
    );
}

export default Home;