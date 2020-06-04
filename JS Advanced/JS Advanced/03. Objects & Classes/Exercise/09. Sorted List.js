class List {
    constructor(arr = []) {
        this.arr = arr;
        this.size = arr.length;
    }

    add(element) {
        this.arr.push(element);
        this.arr.sort(((a, b) => a - b))
        this.size += 1
    }

    remove(index) {
        if (index < 0 || index >= this.arr.length) {
            throw new Error("Index doesn't exist.")
        }
        this.arr.splice(index, 1)
        this.size -= 1;
    }

    get(index) {
        if (index < 0 || index >= this.arr.length) {
            throw new Error("Index doesn't exist.")
        }

        return this.arr[index];

    }

}