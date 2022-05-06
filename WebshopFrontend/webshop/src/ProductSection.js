import ProductBox from './ProductBox';

import {useState, useEffect} from 'react';

function ProductSection({products}) {
     
     return (
         <div className="d-flex flex-wrap align-content-start justify-content-center">
            {
                products.map(({id, name, price, imagePath}) => (
                    <ProductBox key={name} id={id} name={name} price={price} productImg={imagePath} />
                ))
            }
         </div>
     );
 }
 
 ProductSection.defaultProps = {
     productCount: 40
 }
 

export default ProductSection;