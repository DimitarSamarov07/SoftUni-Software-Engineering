function solution(data) {

    const recProto = {
        area() {
            return this.height * this.width;
        },

        compareTo(other) {
            let currArea = this.area();
            let otherArea = other.area();

            return otherArea - currArea || other.width - this.width;
        }
    }

    function createRect(width, height) {
        const result = Object.create(recProto);
        result.width = width;
        result.height = height;
        return result;
    }

    return data.reduce((acc, curr) => {
        const [width, height] = curr;

        return acc.concat(createRect(width, height))
    }, [])
        .sort(((a, b) => {
            return a.compareTo(b);
        }));
}

let sizes = solution([[10, 5], [3, 20], [5, 12]]);
