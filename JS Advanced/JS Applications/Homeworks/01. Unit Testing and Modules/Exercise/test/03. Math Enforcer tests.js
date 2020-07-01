const expect = require("chai").expect;

const mathEnforcer = require("../03. Math Enforcer").mathEnforcer;

describe('math enforcer', function () {
    describe('add five', function () {
        it('should return undefined if the arg is not of type number', function () {
            const actual = mathEnforcer.addFive("Protein Bars");

            expect(actual).to.be.undefined;
        });

        it('should return the arg plus five if the input is alright', function () {
            const positiveActual = mathEnforcer.addFive(1);
            const decimalActual = mathEnforcer.addFive(1.1);
            const negativeActual = mathEnforcer.addFive(-1);

            expect(positiveActual).to.equal(6);
            expect(decimalActual).to.equal(6.1);
            expect(negativeActual).to.equal(4);
        });
    });

    describe('subtract ten', function () {
        it('should return undefined if the arg is not of type number', function () {
            const actual = mathEnforcer.subtractTen("Protein Shakes");

            expect(actual).to.be.undefined;
        });

        it('should return the arg minus ten if the input is alright', function () {
            const positiveActual = mathEnforcer.subtractTen(90);
            const decimalActual = mathEnforcer.subtractTen(1.2)
            const negativeActual = mathEnforcer.subtractTen(-90);

            expect(positiveActual).to.equal(80);
            expect(decimalActual).to.equal(-8.8);
            expect(negativeActual).to.equal(-100);
        });
    });

    describe('sum', function () {
        it('should return undefined if the first arg is not of type number', function () {
            const actual = mathEnforcer.sum("2 plus is", 4);

            expect(actual).to.be.undefined;
        });

        it('should return undefined if the second arg is not of type number', function () {
            const actual = mathEnforcer.sum(1, "kebab");

            expect(actual).to.be.undefined;
        });

        it('should return the sum of the first and the second arg if the input is alright', function () {
            const positiveActual = mathEnforcer.sum(2, 2);
            const decimalActual = mathEnforcer.sum(-2.1, 2);
            const decimalActual1 = mathEnforcer.sum(2, -2.1);
            const negativeActual = mathEnforcer.sum(-2, -2);

            expect(positiveActual).to.equal(4);
            expect(negativeActual).to.equal(-4);
            expect(Number(decimalActual.toFixed(1))).to.equal(-0.1);
            expect(Number(decimalActual1.toFixed(1))).to.equal(-0.1);
        });
    });
});