const expect = require("chai").expect;
const assert = require("chai").assert;

const paymentPackage = require("../06. Payment Package").paymentPackage;

describe('payment package', function () {
    const name = "Pesho";
    const value = 911;
    let validPP;

    beforeEach(() => {
        validPP = new paymentPackage(name, value);
    })

    describe('constructor', function () {

        it('should set all the properties according to the input', function () {
            expect(validPP._name).to.equal(name);
            expect(validPP._value).to.equal(value);
        });

        it('should set the correct default values', function () {
            expect(validPP.VAT).to.equal(20);
            expect(validPP.active).to.equal(true);
        });
    });

    describe('name', function () {
        it('should throw an error if the input value in the setter is not of type string', function () {
            expect(() => validPP.name = ["I am a string :)"])
                .throws(Error, /^Name must be a non-empty string$/g)
        });

        it('should should throw an error if the input value in the setter is empty string', function () {
            expect(() => validPP.name = "")
                .throws(Error, /^Name must be a non-empty string$/g)
        });

        it('should set the value to the correct property if the input is alright', function () {
            validPP.name = "Shrek";

            expect(validPP._name).to.equal("Shrek");
        });

        it('should get the proper value', function () {
            expect(validPP.name).to.equal(name);
        });
    });

    describe('value', function () {
        it('should throw an error if the input value in the setter is not of type number', function () {
            expect(() => validPP.value = "I am a number :)")
                .throws(Error, /^Value must be a non-negative number$/g);
        });

        it('should throw an error if the input value in the setter is negative', function () {
            expect(() => validPP.value = -911)
                .throws(Error, /^Value must be a non-negative number$/g);
        });

        it('should set the value to the correct property if the input is alright', function () {
            validPP.value = 4443;

            expect(validPP._value).to.equal(4443);
        });

        it('should get the proper value', function () {
            expect(validPP.value).to.equal(value);
        });
    });

    describe('VAT', function () {
        it('should throw an error if the input value in the setter is not of type number', function () {
            expect(() => validPP.VAT = "I am a number :)")
                .throws(Error, /^VAT must be a non-negative number$/g);
        });

        it('should throw an error if the input value in the setter is negative', function () {
            expect(() => validPP.VAT = -911)
                .throws(Error, /^VAT must be a non-negative number$/g);
        });

        it('should set the value to the correct property if the input is alright', function () {
            validPP.VAT = 33;

            expect(validPP._VAT).to.equal(33);
        });

        it('should get the proper value', function () {
            expect(validPP.VAT).to.equal(20) // the default value
        });
    });

    describe('active', function () {
        it("'should throw an error if the input value in the setter is not of type boolean", function () {
            expect(() => validPP.active = "Yes please")
                .throws(Error, /^Active status must be a boolean$/g);
        });

        it('should set the value if the input is alright', function () {
            validPP.active = false;

            expect(validPP._active).to.equal(false);
        });

        it('should get the proper value', function () {
            validPP._active = false;

            assert.isFalse(validPP.active);
        });
    });

    describe('toString', function () {
        it('should return the correct output', function () {
            const expected = `Package: ${validPP.name}` + (validPP.active === false ? ' (inactive)' : '') + "\n" +
                `- Value (excl. VAT): ${validPP.value}\n` +
                `- Value (VAT ${validPP.VAT}%): ${validPP.value * (1 + validPP.VAT / 100)}`

            const actual = validPP.toString();

            assert.equal(actual, expected);
        });
    });
});