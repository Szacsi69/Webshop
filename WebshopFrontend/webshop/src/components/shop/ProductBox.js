import productDefaultImg from '../../img/img_placeh.png';
import ratingDefaultImg from '../../img/rating.png';
import { Link } from 'react-router-dom';
import './css/product-box.css';

function ProductBox({ id, name, price, productImg }) {
    return (
        <div className="product-box d-inline-block text-center pt-2 ps-4 pe-4 ms-1 me-1 mb-2 border shadow">
            <img src={productImg} className="product-img border" id="productImg" />
            <Link to={`${id}`} className="mb-0 pb-0" id="productName"><p> { name } </p></Link>
            <img src={ ratingDefaultImg } id="ratingImg"/>
            <h4>{ price } Ft</h4>
        </div>
    );
}

ProductBox.defaultProps = {
    name: 'Termék',
    price: '10 499Ft',
    productImg: productDefaultImg
}

export default ProductBox;