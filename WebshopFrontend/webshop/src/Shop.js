import ProductSection from './ProductSection';
import FilterSection from './FilterSection';

import {useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';

function Shop() {

    const { category } = useParams()

    const [filters, setFilters] = useState(null);
    const [products, setProducts] = useState(null);

    const productBaseUrl = `https://localhost:44397/Shop/${category}`;
    const [productUrl, setProductUrl] = useState(productBaseUrl);
    

    useEffect(() => {
        const urlStart = `https://localhost:44397/Shop/${category}/all`;
        fetch(urlStart)
            .then((response) => {
                if (!response.ok) {
                    throw new Error(
                        `HTTP-ERROR: The status is ${response.status}`
                    );
                }
                return response.json();
            })
            .then((response) => {
                setFilters(response.filters);
                setProducts(response.products);
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
                   { !filters && <div className="text-center">Loading filters...</div>}
                   { filters &&
                    <FilterSection filters={filters} filterFunc={filter}/>
                   }
                </div>
                <div className=" col-10-md col-9">
                    { !products && <div className="text-center">Loading products...</div>}
                    { products &&
                    <ProductSection products={products} />
                    }
                </div>
            </div>
        </div>
    );
}

export default Shop;