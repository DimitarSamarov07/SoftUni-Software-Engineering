function solution() {

    const arr = [];

    let size = 0;

    function add(element) {
        arr.push(element);
        this.size++;
        return sortList();
    }

    function remove(index) {
        throwOutOfRange(index);
        arr.splice(index, 1);
        this.size--;
        return sortList();
    }

    function get(index) {
        throwOutOfRange(index);
        return arr[index];
    }

    function sortList() {
        return arr.sort(((a, b) => a - b));
    }

    function throwOutOfRange(index) {
        if (index < 0 || index >= arr.length){
            throw new Error("Out of range!")
        }
    }

    return {add, remove, get, size}
}