const expect = require("chai").expect;

const isOddOrEven = require("../01. Even or Odd").isOddOrEven;

describe('even or odd', function () {
    it('should return undefined if the input is not a string', function () {
        const result = isOddOrEven([123, "I am string :))"])

        expect(result).to.be.undefined;
    });

    it('should return odd if the string length is odd', function () {
        const result = isOddOrEven("123");

        expect(result).to.equal("odd");
    });

    it('should return even if the string length is even', function () {
        const result = isOddOrEven("1234");

        expect(result).to.equal("even");
    });
});