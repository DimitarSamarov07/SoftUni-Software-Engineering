const expect = require("chai").expect;
const assert = require("chai").assert;


const stringBuilder = require("../05. String Builder").stringBuilder;

describe('string builder', function () {
    const validInput = "123 that's four";
    let validSb;

    beforeEach(() => {
        validSb = new stringBuilder(validInput);
    })

    describe('constructor', function () {
        it('should set the string array to empty if the input is not valid', function () {
            const sb = new stringBuilder(undefined);

            expect(sb._stringArray).to.be.empty;
        });

        it('should verify the input', function () {
            assert.throws(() => new stringBuilder(["I am a string I swear :v"]));
        });

        it('should set the array to the array created from the input string if the input is alright', function () {

            expect(validSb._stringArray.length).to.be.equal(validInput.length);
        });
    });

    describe('append', function () {
        it('should verify the input first', function () {
            assert.throws(() => validSb.append(["I am a string I promise :D"]))
        });

        it("should add the input string's chars at the end of string array", function () {
            const input = "1234";
            validSb.append(input);
            const newString = validSb._stringArray.join("");

            expect(newString.length).to.be
                .equal(validInput.length + input.length);

            assert.isTrue(newString.endsWith(input));
        });

    });

    describe('prepend', function () {
        it('should verify the input first', function () {
            assert.throws(() => validSb.prepend(["Believer"]))
        });

        it("should add the input string's chars at the beginning of the array", function () {
            const input = "1234";
            validSb.prepend(input);
            const newString = validSb._stringArray.join("");

            expect(newString.length).to.be
                .equal(validInput.length + input.length);

            assert.isTrue(newString.startsWith(input));
        });
    });

    describe('insertAt', function () {
        it('should verify the input first', function () {
            assert.throws(() => validSb.insertAt(["SuperSpiro"], 8))
        });

        it('should insert properly if the input is alright', function () {
            const inputString = "Minesweeper";
            const index = 2;

            validSb.insertAt(inputString, index);
            const newString = validSb._stringArray.join("");

            assert.isTrue(newString.includes(inputString));
            expect(newString.indexOf(inputString)).to.be.equal(2);
            assert.isTrue(newString
                .slice(index, (newString.length - 1) - inputString.length)
                .includes(inputString));
        });
    });

    describe('remove', function () {
        it('should splice properly', function () {
            const stringToRemove = validSb._stringArray.join("").slice(0, 4);
            validSb.remove(0, 4);
            1
            const newStr = validSb._stringArray.join("");

            assert.isTrue(!newStr.includes(stringToRemove));
        });
    });

    describe('toString', function () {
        it('should return the char array ,,casted" to string', function () {
            expect(validSb.toString()).to.be.equal(validInput);
        });
    });

    describe('_vrfyParam', function () {
        it('should throw an error with the correct type and message', function () {
            expect(() => stringBuilder._vrfyParam(["StackOverShrek"]))
                .throws(TypeError, /^Argument must be string$/) //the second parameter is regex
        });
    });
});