import ProductSection from './ProductSection';
import FilterSection from './FilterSection';

import {useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';

function Shop() {

    const { category } = useParams()

    const [filters, setFilters] = useState(null);
    const [products, setProducts] = useState(null);

    const productUrl = `https://localhost:44397/shop/${category}`;
    
    useEffect(() => {
        const urlStart = productUrl;
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

    async function filter(checked) {
        var properties = [];
        var filterObj = {};
        for(let i = 0; i < checked.length; i++) {
            if (!properties.includes(checked[i].queryName)) {
                properties.push(checked[i].queryName);
                filterObj[checked[i].queryName] = [];
            }
        }
        for(let i = 0; i < checked.length; i++) {
            filterObj[checked[i].queryName].push(checked[i].value)
        }

        const response = await fetch(productUrl, {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify(filterObj)
        });
        if (response.ok) {
            setProducts(await response.json());
        }
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