function Spy(obj, method)
{
    const spy = {count: 0}
    let originFunc = obj[method]

    obj[method] = function (...args) {
        this.count++;
        return originFunc.apply(obj, args)
    }.bind(spy);

    return spy;
}
