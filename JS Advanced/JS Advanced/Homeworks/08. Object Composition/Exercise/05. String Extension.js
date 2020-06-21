(function () {
    String.prototype.ensureStart = function (str) {
        let thisStr = this.toString();

        if (thisStr.startsWith(str)) {
            return thisStr;
        }

        return str + thisStr;
    }

    String.prototype.ensureEnd = function (str) {
        let thisStr = this.toString();

        if (thisStr.endsWith(str)) {
            return thisStr;
        }

        return thisStr + str;
    }

    String.prototype.isEmpty = function () {
        return !!!this.toString();  // parse value to boolean(!!) and return the opposite(one more !)
    }

    String.prototype.truncate = function (n) {

        const ellipsis = ".".repeat(3);
        const thisStr = this.toString();

        if (n < 3) {
            return ellipsis;
        }

        if (this.length <= n) {
            return thisStr;
        } else { //the code in ,,else" isn't written by me
            let lastIndex = this.toString().substring(0, n - 2).lastIndexOf(" ");

            if (lastIndex !== -1) {
                return this.toString().substring(0, lastIndex) + ellipsis;
            } else {
                return this.toString().substring(0, n - 3) + ellipsis;
            }
        }
    }

    String.format = function (string, ...params) {
        let args = [...params];

        return string.replace(/{(\d+)}/g,
            (match, number) => args[number] ? args[number] : match);
    }
})();