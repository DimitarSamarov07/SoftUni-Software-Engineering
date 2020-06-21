function hierarchy() {
    class Figure {
        constructor(unit = "cm") {
            this.unit = unit
            this.converterFromCm = {
                m: (number) => number / 100,
                cm: (number) => number,
                mm: (number) => number * 10
            }
        }

        changeUnits(unit) {
            this.unit = unit;
        }
    }

    class Circle extends Figure {
        constructor(radius, unit = "cm") {
            super(unit);
            this.radius = radius;
        }

        get area() {
            const convert = (number) => this.converterFromCm[this.unit](number);
            return Math.PI * convert(this.radius) * convert(this.radius);
        }

        toString() {
            const convert = (number) => this.converterFromCm[this.unit](number);
            return `Figures units: ${this.unit} Area: ${this.area} - radius: ${convert(this.radius)}`
        }

    }

    class Rectangle extends Figure {
        constructor(width, height, unit = "cm") {
            super(unit);
            this.width = width;
            this.height = height;
        }

        get area() {
            const convert = (number) => this.converterFromCm[this.unit](number);
            return convert(this.width) * convert(this.height);
        }

        toString() {
            const convert = (number) => this.converterFromCm[this.unit](number);
            return `Figures units: ${this.unit} Area: ${this.area} - width: ${convert(this.width)}, height: ${convert(this.height)}`
        }

    }

    return {
        Figure,
        Rectangle,
        Circle
    }
}
