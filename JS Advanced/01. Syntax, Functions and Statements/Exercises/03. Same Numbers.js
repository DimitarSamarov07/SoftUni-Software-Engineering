function sameNumbers(input) {
    let stringInput = input.toString();
    let re = /^(.)\1*$/
    let areAllNumbersIdentical = re.test(stringInput)
    console.log(areAllNumbersIdentical);

    let sum = 0;

    for (let i = 0; i < stringInput.length; i++) {
        sum += +stringInput[i];
    }
    console.log(sum)
}
