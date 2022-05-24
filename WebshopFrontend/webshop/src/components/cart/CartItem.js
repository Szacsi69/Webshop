import deleteIcon from '../../img/deleteIcon.png'
import './css/cart.css';

import AmountSelecter from '../shared/AmountSelecter';

function CartItem({ orderItem, onItemChange, onItemDelete, state }) {

    const onQuantityChange = (newQuantity) => {
        var oItem = {productId: orderItem.product.id, amount: newQuantity};
        onItemChange(oItem);
    }

    return (
        <div className="row mb-3">
            <div className="d-inline-block col-2 pb-2">
                <img src={orderItem.product.imagePath} className="item-icon border" />
            </div>
            <div className="d-inline-block col-4">
                <p>{orderItem.product.name}</p>
            </div>
            { state === "" &&
            <>
            <div className="d-inline-block col-3">
                <AmountSelecter value={orderItem.quantity} maxAmount={orderItem.product.amount} onQuantityChange={onQuantityChange} />
            </div>
            <div className="d-inline-block col-3">
                <button className="delete-btn btn border-dark" onClick={() => onItemDelete(orderItem.id)}>
                    <img src={deleteIcon} className="delete-icon" />
                </button>
            </div>
            </>
            }

            {state === 'success' &&
             <div className="alert-success border-bottom border-dark">
                 Sikeres vásárlás!
            </div>
            }
            {state === 'failed' &&
             <div className="alert-danger border-bottom border-dark">
                 Sikertelen vásárlás! A kért mennyiség már elkelt.
            </div>
            }
        </div>
    );
}

export default CartItem;