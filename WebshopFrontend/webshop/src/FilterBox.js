const filterDisplayNames = [
    {
        "name": "price",
        "displayName": "Ár (Ft)"
    },
    {
        "name": "manufacturer",
        "displayName": "Gyártó"
    },
    {
        "name": "energyClass",
        "displayName": "Energiaosztály"
    },
    {
        "name": "cubicCapacity",
        "displayName": "Űrtartalom (l)"
    }
]


function FilterBox({ name, values, interval, handleChange }) {

    var displayName = name;
    for(let i = 0; i < filterDisplayNames.length; i++) {
        if (filterDisplayNames[i].name === name)
            displayName = filterDisplayNames[i].displayName;
    }

    var queryNdisplayValues = [];
    if (interval === true) {
        queryNdisplayValues.push({queryValue:`ls-${values[0]}`, displayValue: `- ${values[0]}`})
        for(let i = 0; i < values.length; i++) {
            if (i + 1 >= values.length)
                queryNdisplayValues.push({queryValue: `gt-${parseInt(values[i]) + 1}`, displayValue: `${parseInt(values[i]) + 1} -`});
            else {
                queryNdisplayValues.push({queryValue: `gt-${parseInt(values[i]) + 1}:ls-${values[i+1]}`, displayValue: `${parseInt(values[i]) + 1} - ${values[i+1]}`});
            }
        }
    }
    else {
        for(let i = 0; i < values.length; i++) {
            queryNdisplayValues.push({queryValue: values[i], displayValue: values[i]})
        }
    }

    return (
        <div className="form-group ps-2 pb-3">
            <h4 className="font-weight-bold"> {displayName} </h4>
            {queryNdisplayValues.map(({displayValue, queryValue}, index) => (
                <div className="m-0 p-0" key={name + index}>
                    <input type="checkbox" id={name + index} onChange={() => 
                        {
                                let id = name + index;
                                handleChange(id, name, queryValue);

                        }
                        } className="form-control-check mb-0 pb-0"></input>
                    <label className="text-muted ps-2 pb-0 mb-0" htmlFor={name + index}> {displayValue} </label>
                </div>
            ))}
        </div>
    );
}

FilterBox.defaultProps = {
    name: 'Filter',
    values: [
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
        'Value3'
    ]
}

export default FilterBox;