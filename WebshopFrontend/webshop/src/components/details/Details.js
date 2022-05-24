import rating from '../../img/rating.png';
import cartIcon from '../../img/cart_icon.png';
import './css/details.css'; 

import AmountSelecter from '../shared/AmountSelecter';
import { Navigate } from 'react-router-dom';
import {useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';

function Details() {

    const { category } = useParams()
    const {id} = useParams()

    const [product, setProduct] = useState(null);
    const [quantity, setQuantity] = useState(1);

    const [success, setSuccess] = useState(false);
    const [errorMsg, setErrorMsg] = useState(null);
    const [redirect, setRedirect] = useState(false);

    const productUrl = `https://localhost:44397/shop/${category}/${id}`;

    useEffect(() => {
        const url = productUrl;
        fetch(url)
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

    const onAddToCart = async () => {
        const response = await fetch('https://localhost:44397/cart', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include',
            body: JSON.stringify({
                productId: id,
                amount: quantity
            })
        });
        if (response.ok) {
            setSuccess(true);
        }
        if (response.status === 401)
            setRedirect(true);
        if (response.status === 400) {
            var content = await response.json();
            setErrorMsg(content.message);
        }
    }

    const onQuantityChange = (newQuantity) => {
        setQuantity(newQuantity);
    }

    if (redirect) {
        return <Navigate to="/login" />
    }

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
                    { success &&
                    <div className="row pb-2">
                        <div className="alert-success pt-2 pb-2">
                            Sikeresen hozzáadta a terméket a kosarához!
                        </div>
                    </div>
                    }
                    { errorMsg &&
                    <div className="row pb-2">
                        <div className="alert-danger pt-2 pb-2">
                            {errorMsg}
                        </div>
                    </div>
                    }
                    <div className="row pt-3 ps-3 pb-3 mb-xl-0 mb-2 rounded" id="blueContainer">
                        <div className="d-flex justify-content-between align-items-center col-12">
                            <div className="col-4 text-start">
                                <h3 className="fw-bold"> {product.price} Ft </h3>
                            </div>
                            <div className="col-4">
                                { product.amount > 0 &&
                                <AmountSelecter maxAmount={product.amount} onQuantityChange={onQuantityChange}/>
                                }
                            </div>
                            <div className="col-4 text-center">
                                <button className="cart-btn btn border-dark" onClick={() => onAddToCart()} disabled={product.amount === 0}>
                                    <img src={cartIcon} className="cart-icon m-1 p-1 rounded" id="cartIcon" />
                                </button>
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