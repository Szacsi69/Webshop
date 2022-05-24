function AmountSelecter({value, maxAmount, onQuantityChange}) {
    var options = []
    for(let i = 1; i <= maxAmount; i++) {
        options.push(
            <option key={i} value={i}>{i} db</option>
        );
    }
    return (
        <>
            <select className="form-control" value={value} onChange={e => onQuantityChange(e.target.value)}>
                {options}
            </select>  
        </>
    );
}

export default AmountSelecter;