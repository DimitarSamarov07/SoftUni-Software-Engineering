function solution(requirements) {
    const {model, power, color, carriage, wheelsize} = requirements;

    const engineStore = {
        90: {power: 90, volume: 1800},
        120: {power: 120, volume: 2400},
        200: {power: 200, volume: 3500}
    }

    const resultObj = {
        model,
        engine: {},
        carriage: {
            type : carriage,
            color,
        },
        wheels: new Array(4)
            .fill(wheelsize % 2 === 0 ? 2 * Math.floor(wheelsize / 2) - 1 : wheelsize) //round down to the nearest odd integer(if the number isn't an integer)
    };

    if (power <= 90) {
        resultObj.engine = engineStore[90];
    } else if (power > 90 && power <= 120) {
        resultObj.engine = engineStore[120];
    } else if (power > 120) {
        resultObj.engine = engineStore[200]
    }

    return resultObj;
}