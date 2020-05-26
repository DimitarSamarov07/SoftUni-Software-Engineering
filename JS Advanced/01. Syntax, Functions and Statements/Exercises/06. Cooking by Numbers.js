function cookByTheNumbers(inputArray) {
    let number = +inputArray[0];

    for (let i = 1; i < 6; i++) {
        //skip the first object

        let cookingWord = inputArray[i];

        switch (cookingWord) {
            case "chop":
                number = number / 2;
                break;
            case "dice":
                number = Math.sqrt(number)
                break;
            case "spice":
                number+= 1;
                break;
            case "bake":
                number *= 3;
                break;
            case "fillet":
                number -=(number * 0.2)
            default:
                break;
        }
        console.log(number);
    }
}