export class Box<T> {
    private _elements = [];

    get count(): number {
        return this._elements.length;
    }

    public add(element: T): void {
        this._elements.push(element);
    }

    public remove(): void {
        this._elements.shift();
    }
}