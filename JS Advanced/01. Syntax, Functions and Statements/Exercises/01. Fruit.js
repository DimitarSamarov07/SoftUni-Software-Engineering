function calculatePrice(fruit, weight, pricePerKg) {

    var weightInKilograms = weight / 1000;
    var price = pricePerKg * weightInKilograms;
    console.log(`I need $${price.toFixed(2)} to buy ${weightInKilograms.toFixed(2)} kilograms ${fruit}.`)
}