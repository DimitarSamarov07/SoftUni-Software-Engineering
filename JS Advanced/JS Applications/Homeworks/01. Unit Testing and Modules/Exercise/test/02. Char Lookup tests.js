const expect = require("chai").expect;

const lookupChar = require("../02. Char Lookup").lookupChar;

describe('lookup char', function () {
    it('should return undefined if the first arg is not a string', function () {
        const actual = lookupChar(123, 1);

        expect(actual).to.be.undefined;
    });

    it('should return undefined if the second arg is not a number', function () {
        const actual = lookupChar("123 that's 4", "I am 1 :)");

        expect(actual).to.be.undefined;
    });

    it('should return undefined if the second arg is not an integer', function () {
        const actual = lookupChar("123 that's 4", 2.1231);

        expect(actual).to.be.undefined;
    });

    it('should return incorrect index when index arg is out of range', function () {
        const actual = lookupChar("123 that's 4", Number.MAX_SAFE_INTEGER);

        expect(actual).to.equal("Incorrect index",
            "The function did not return the correct message!");
    });

    it('should return incorrect index when index arg is negative', function () {
        const actual = lookupChar("123 that's 4", Number.MIN_SAFE_INTEGER);

        expect(actual).to.equal("Incorrect index",
            "The function did not return the correct message!");
    });

    it('should return the char at the given index if the input is alright', function () {
        const string = "123 that's 4"
        const actual = lookupChar(string, 2);
        const expected = string.charAt(2);

        expect(actual).to.equal(expected);
    });
});