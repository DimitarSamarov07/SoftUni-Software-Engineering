let expect = require('chai').expect;

const rgbToHexColor = require("../03. RGB to Hex").rgbToHexColor;

describe('rgb to hex color', function () {
    it('should return undefined if red is out of range', function () {
        const belowRange = rgbToHexColor(-1, 2, 2);
        const aboveRange = rgbToHexColor(22222, 2, 2);

        expect(belowRange).to.be.undefined;
        expect(aboveRange).to.be.undefined;
    });

    it('should return undefined if green is out of range', function () {
        const belowRange = rgbToHexColor(2, -2, 2);
        const aboveRange = rgbToHexColor(2, 22222, 2);

        expect(belowRange).to.be.undefined;
        expect(aboveRange).to.be.undefined;
    });

    it('should return undefined if blue is out of range', function () {
        const belowRange = rgbToHexColor(2, 2, -2);
        const aboveRange = rgbToHexColor(2, 2, 222222);

        expect(belowRange).to.be.undefined;
        expect(aboveRange).to.be.undefined;
    });

    it('should return hex inn the correct format if the input is alright', function () {
        const red = 22;
        const green = 22;
        const blue = 32;

        const expected = "#" +
            ("0" + red.toString(16).toUpperCase()).slice(-2) +
            ("0" + green.toString(16).toUpperCase()).slice(-2) +
            ("0" + blue.toString(16).toUpperCase()).slice(-2);

        const result = rgbToHexColor(red, green, blue);

        expect(expected).to.equal(result);
    });

    it('should have ranges for every color between 0 and 255', function () {
        const result1 = rgbToHexColor(0, 0, 0);
        const result2 = rgbToHexColor(255, 255, 255);

        expect(result1).to.not.be.undefined;
        expect(result2).to.not.be.undefined;
    });
});