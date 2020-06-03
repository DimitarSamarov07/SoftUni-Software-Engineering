function storeCatalogue(inputArray) {
    let catalogue = {};

    inputArray.forEach(x => {
        catalogue[x.split(' : ')[0]] = Number(x.split(" : ")[1])
    })

    let currSectionLetter = "";

    // Print the results
    Array.from(Object.keys(catalogue))
        .sort((a, b) => {
            return a.localeCompare(b) || catalogue[a] - catalogue[b]
        })
        .forEach(product => {
            if (product[0] !== currSectionLetter) {
                currSectionLetter = product[0];
                console.log(product[0]);
            }

            console.log(`${product}: ${catalogue[product]}`)
        })
}