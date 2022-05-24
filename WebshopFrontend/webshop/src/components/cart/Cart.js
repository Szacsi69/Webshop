import './css/cart.css';

import CartItem from './CartItem';
import { Navigate } from 'react-router-dom';
import {useState, useEffect} from 'react';

function Cart() {

    const [order, setOrder] = useState(null);

    const [loaded, setLoaded] = useState(false);
    const [redirect, setRedirect] = useState(false);

    const [items, setItems] = useState([]);
    const [itemPrices, setItemPrices] = useState([]);
    const [priceSum, setPriceSum] = useState(0);

    const [buyState, setBuyState] = useState([]);

    useEffect( () => {
        (
            async () => {
                await loadOrder();
            }
        )();
        
    },
        []
    );

    useEffect(() => {
        if (order) {
            var _items = [];
            var _itemPrices = [];
            var _priceSum = 0;
            for (let i = 0; i < order.items.length; i++) {
                var state = buyState.find(s => s.id == order.items[i].id)?.state;
                state = state ? state : "";
                _items.push(
                    <CartItem key={order.items[i].Id} orderItem={order.items[i]} onItemChange={onItemChange} onItemDelete={onItemDelete} state={state}/>
                )
                _itemPrices.push(
                    <table key={order.items[i].Id} className="table blue-table text-center border">
                        <tr>
                            <td>
                                {order.items[i].product.name}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                {order.items[i].quantity} db
                            </td>
                        </tr>
                        <tr>
                            <td>
                                {order.items[i].price} Ft
                            </td>
                        </tr>
                    </table>
                )
                _priceSum += order.items[i].price;
            }
            setItems(_items);
            setItemPrices(_itemPrices)
            setPriceSum(_priceSum);
        }
    },
        [buyState]
    );

    const loadOrder = async () => {
        const response = await fetch('https://localhost:44397/cart', {
                    headers: {'Content-Type': 'application/json'},
                    credentials: 'include'
                });
                if (response.ok) {
                    const content = await response.json();
                    setOrder(content);
                }
                if (response.status === 404)
                    setOrder(null);
                if (response.status === 401)
                    setRedirect(true);
                setLoaded(true);
                setBuyState([]);
    }

    const onItemChange = async (newOrderItem) => {
        const response = await fetch('https://localhost:44397/cart', {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                credentials: 'include',
                body: JSON.stringify(newOrderItem)
        });
        if (response.ok) {
            await loadOrder()
        }
        else if (response.status === 401)
            setRedirect(true);
        else if (response.status === 400) {
            var content = await response.json();
            alert(content.message);
        }
    }

    const onItemDelete = async (itemId) => {
        const response = await fetch(`https://localhost:44397/cart/${itemId}`, {
            method: 'DELETE',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include',
        });
        if (response.status === 204) {
            await loadOrder();
        }
        else if (response.status === 401)
            setRedirect(true);
    }

    const Buy = async () => {
        const response = await fetch('https://localhost:44397/cart/buy', {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                credentials: 'include',
        });
        if (response.ok) {
            var content = await response.json();
            var buyStates = [];
            for(let i = 0; i < content.success.length; i++) {
                buyStates.push({id: content.success[i], state: 'success'});
            }
            for(let i = 0; i < content.failed.length; i++) {
                buyStates.push({id: content.failed[i], state: 'failed'});
            }
            setBuyState(buyStates);
        }
        else if (response.status === 401)
            setRedirect(true);
    }

    if (redirect) {
        return <Navigate to="/login" />
    }

    if (!order && !loaded) {
        return (
            <div className="d-flex justify-content-center">
                <p>Loading...</p>
            </div>
        );
    }

    if (!order && loaded) {
        return (
            <div className="d-flex justify-content-center">
                <div className="alert-warning pt-2 pb-2 ps-5 pe-5 mt-2 border">Az Ön kosara jelenleg üres!</div>
            </div>
        );
    }

    return (
        <div className="d-flex flex-wrap justify-content-between mt-4 me-lg-2 ms-lg-0 me-1 ms-1">
            <div className="container-fluid d-inline-block col-12 col-xl-6">
            <div className="d-flex flex-column ">
                {items}
            </div>
            </div>
            <div className="container-fluid d-inline-block col-12 col-xl-5">
                <div className="blue-container d-flex flex-column p-2 rounded shadow">
                    <div className="border-bottom">
                        <h4>Rendelés:</h4>
                    </div>
                    <div className="border-bottom">
                        <h6>Részösszegek:</h6>
                        <div className="d-flex flex-column">
                            {itemPrices}
                        </div>
                    </div>
                    <div className="d-flex justify-content-between">
                        <h3>Végösszeg:</h3>
                        <h3 className="fw-bold">{priceSum} Ft</h3>
                    </div>
                    <div className="d-grid pt-2 pb-2 ms-5 me-5">
                        <button type="button" className="btn btn-primary btn-lg border-dark" onClick={() => Buy()}>
                            <strong>Vétel</strong>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Cart;