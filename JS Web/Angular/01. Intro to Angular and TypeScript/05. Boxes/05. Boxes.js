"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Box = void 0;
var Box = /** @class */ (function () {
    function Box() {
        this._elements = [];
    }
    Object.defineProperty(Box.prototype, "count", {
        get: function () {
            return this._elements.length;
        },
        enumerable: false,
        configurable: true
    });
    Box.prototype.add = function (element) {
        this._elements.push(element);
    };
    Box.prototype.remove = function () {
        this._elements.shift();
    };
    return Box;
}());
exports.Box = Box;
