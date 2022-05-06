import FilterBox from './FilterBox';

import {useState} from 'react';

function FilterSection({filters, filterFunc}) {

    const [checked, setChecked] = useState([])

    function handleChange(_id, _queryName, _value) {
        var queryElement = {id: _id, queryName: _queryName, value: _value};
        const currentIndex = contains(checked, queryElement);
        const newChecked = [...checked];

        if (currentIndex === -1) {
            newChecked.push(queryElement);
        }
        else {
            newChecked.splice(currentIndex, 1);
        }
        setChecked(newChecked);
    }

    function contains(array, object) {
        var result = -1;
        for(let i = 0; i < array.length; i++) {
            if(array[i].id === object.id) {
                result = i;
                break;
            }
        }
        return result;
    }

    return (
        <div className="d-flex flex-column pb-2">
            {
                filters.map(({name, values, interval}) => (
                    <FilterBox key={name} name={name} values={values} interval={interval} handleChange={handleChange} />
                ))
            }
            <button type="submit" className="form-control btn-warning" onClick={() => filterFunc(checked)}>Szűrés</button>
        </div>
    );
}
    
    FilterSection.defaultProps = {
        filterCount: 5
    }
    
    export default FilterSection;