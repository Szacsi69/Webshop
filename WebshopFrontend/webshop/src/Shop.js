import ProductSection from './ProductSection';
import FilterSection from './FilterSection';

import {useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';

function Shop() {

    const { category } = useParams()

    const [filters, setFilters] = useState(null);
    const [products, setProducts] = useState(null);

    const [productUrl, setProductUrl] = useState(`https://localhost:44397/Shop/${category}`);
    const productBaseUrl = `https://localhost:44397/Shop/${category}`;

    useEffect(() => {
        const urlFilter = `https://localhost:44397/Shop/filters/${category}`;
        fetch(urlFilter)
            .then((response) => {
                if (!response.ok) {
                    throw new Error(
                        `HTTP-ERROR: The status is ${response.status}`
                    );
                }
                return response.json();
            })
            .then((filters) => {
                setFilters(filters);
            })
            .catch((err) => {
                console.log(err.message);
            });  
    },
        []
    );

    useEffect(() => {
        const urlProduct = productUrl;
            fetch(urlProduct)
                .then((response) => {
                    if (!response.ok) {
                        throw new Error(
                            `HTTP-ERROR: The status is ${response.status}`
                        );
                    }
                    return response.json();
                })
                .then((products) => {
                    setProducts(products);
                })
                .catch((err) => {
                    console.log(err.message);
                });
    },
        [productUrl]
    );   

    function filter(checked) {
        var url = productBaseUrl;
        
        if (checked.length > 0) {
            url = url + '?';
        }
        for(let i = 0; i < checked.length; i++) {
            let value = checked[i].value.toLowerCase().replace(" ", "-");
            url = url + checked[i].queryName + '=' + value;
            if (i + 1 < checked.length)
                url = url + '&';
        }
        setProductUrl(url);
    }

    return (
        <div className="container-fluid">
            <div className="row">
                <div className=" col-2-md col-3">
                   { filters &&
                    <FilterSection filters={filters} filterFunc={filter}/>
                   }
                </div>
                <div className=" col-10-md col-9">
                    { products &&
                    <ProductSection products={products} />
                    }
                </div>
            </div>
        </div>
    );
}

export default Shop;