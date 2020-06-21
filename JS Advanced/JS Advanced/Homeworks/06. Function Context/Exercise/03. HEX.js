class Hex {
    constructor(value = 0) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        let result = "0x"

        result = result.concat(this.value.toString(16).toUpperCase())

        return result;
    }

    plus(number) {
        let result;

        if (typeof number === "object") {
            result = this.value + number.value;
            return new Hex(result);
        }

        result = this.value + number;

        return new Hex(result);
    }

    minus(number) {
        let result;
        if (typeof number == "object") {
            result = this.value - number.value;
            return new Hex(result);
        }

        result = this.value - number.value;

        return new Hex(result);
    }

    parse(string) {
        return parseInt(string, 16);
    }

}