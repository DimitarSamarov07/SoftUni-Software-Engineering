let expect = require('chai').expect;

const sum = require("../01. Sum of Numbers").sum

describe("sum", function () {
    it('should return NaN if arg is a string', function () {
        const result = sum("ninja");
        expect(result).to.be.NaN;
    });

    it('should return the sum of array of nums', function () {
        const result = sum([1, 2, 3]);
        expect(result).to.equal(6, "the result should be 6")
    });

    it('should return the sum of array of strings', function () {
        const result = sum(["1", "2", "3"]);
        expect(result).to.equal(6, "the result should be 6");
    });

})