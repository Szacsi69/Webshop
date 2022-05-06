import rating from './img/rating.png';
import cartIcon from './img/cart_icon.png';
import './css/details.css'; 

import AmountSelecter from './AmountSelecter';
import {useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';

function Details() {

    const {id} = useParams()

    const [product, setProduct] = useState(null);

    useEffect(() => {
        const urlFilter = `https://localhost:44397/Shop/homeappliances/${id}`;
        fetch(urlFilter)
            .then((response) => {
                if (!response.ok) {
                    throw new Error(
                        `HTTP-ERROR: The status is ${response.status}`
                    );
                }
                return response.json();
            })
            .then((product) => {
                setProduct(product);
            })
            .catch((err) => {
                console.log(err.message);
            });  
    },
        []
    );

    return (
        <div className="container-fluid">
        { product &&
            <>
            <div className="row">
                <div className="d-flex justify-content-center justify-content-xl-start col-xl-4 col-12 mb-xl-0 mb-2">
                    <img src={product.imagePath} className="border" id="productImg" />
                </div>
                <div className="d-flex flex-column justify-content-between me-1 col-xl-7 col-12">
                    <div className="row">
                        <div className="d-flex flex-column align-items-center align-items-xl-start text-xl-start text-center col pb-2">
                            <h2> {product.name} </h2>
                            <img src={rating} id="ratingImg"/>
                        </div>
                    </div>
                    <div className="row pt-3 ps-3 pb-3 mb-xl-0 mb-2 rounded" id="blueContainer">
                        <div className="d-flex justify-content-between align-items-center col-12">
                            <div className="col-4 text-start">
                                <h3 className="fw-bold"> {product.price} Ft </h3>
                            </div>
                            <div className="col-4">
                                <AmountSelecter amount={product.amount}/>
                            </div>
                            <div className="col-4 text-center">
                                <img src={cartIcon} className="cart-icon m-1 p-1 border rounded" id="cartIcon" />
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="d-flex justify-content-between align-content-center col-12">
                            <div className="col-3">
                                <h5 className="fw-bold">Szín:</h5>
                                <p> {product.color} </p>
                            </div>

                            <div className="d-flex flex-column align-content-center col-5">
                                <h5 className="fw-bold">Méret:</h5>
                                <p> {product.size} </p>
                            </div>

                            <div className="col-3">
                                <h5 className="fw-bold">Státusz:</h5>
                                <p> {product.status} </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="row mt-3 border">
                <h2>Leírás:</h2>
                <p>
                    {product.description}
                </p>
            </div>
            </>
        }
        </div>
    );
}

export default Details;