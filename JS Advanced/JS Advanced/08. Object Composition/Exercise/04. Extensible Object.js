function solve() {
    return {
        extend(template) {
            for (const property in template) {

                if (typeof template[property] === 'function') {
                    const proto = Object.getPrototypeOf(this);
                    proto[property] = template[property];
                } else {

                    this[property] = template[property];
                }
            }
        }
    };
}