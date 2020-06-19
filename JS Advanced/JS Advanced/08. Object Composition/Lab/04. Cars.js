function solution(inputArr) {

    let cars = {}

    const carsProcessor = {
        create: (name, _, parentName) => {
            if (!parentName) {
                cars[name] = {}
                return;
            }

            const parent = cars[parentName];
            cars[name] = Object.create(parent);
        },
        set: (name, key, value) => {
            cars[name][key] = value;
        },
        print: (name) => {

            let res = '';
            for (const prop in cars[name]) {
                res += `${prop}:${cars[name][prop]}, `
            }

            console.log(res.substring(res.length - 2, 0));
        }
    }

    inputArr.forEach(x => {
        const [command, name, firstParam, secondParam] = x.split(" ");

        carsProcessor[command](name, firstParam, secondParam)

    })
}