function AmountSelecter({amount}) {
    var options = []
    for(let i = 1; i < amount; i++) {
        options.push(
            <option>{i} db</option>
        );
    }
    return (
        <>
            <select className="form-control">
                {options}
            </select>  
        </>
    );
}

export default AmountSelecter;