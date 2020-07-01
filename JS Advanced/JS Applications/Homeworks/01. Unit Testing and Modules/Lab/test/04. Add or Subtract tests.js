let expect = require('chai').expect;

let createCalculator = require("../04. Add or Subtract").createCalculator;

describe('add or subtract', function () {
    it('should return 0 when get is called for the first time', function () {
        const result = createCalculator().get();
        expect(result).to.be.equal(0);
    });

    it('should add the number to the value, given to add as string', function () {
        const calculator = createCalculator();
        calculator.add("222");
        const result = calculator.get();

        expect(result).to.be.equal(222);
    });

    it('should add the number to the value, given to add as number', function () {
        const calculator = createCalculator();
        calculator.add(222);
        const result = calculator.get();

        expect(result).to.be.equal(222);
    });

    it('should subtract the number from the value given to subtract as string', function () {
        const calculator = createCalculator();
        calculator.subtract("222");
        const result = calculator.get();

        expect(result).to.be.equal(-222);
    });

    it('should subtract the number from the value given to subtract as number', function () {
        const calculator = createCalculator();
        calculator.subtract(222);
        const result = calculator.get();

        expect(result).to.be.equal(-222);
    });
});