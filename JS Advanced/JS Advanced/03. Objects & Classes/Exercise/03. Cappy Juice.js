function getProducedBottles(inputArray) {
    let juice = {};
    let bottles = {};

    for (let currElement of inputArray) {
        let [name, volume] = currElement.split(" => ");
        volume = +volume;

        !juice.hasOwnProperty(name) ? juice[name] = 0 : ""

        let currVolume = juice[name] + volume;

        if (currVolume >= 1000) {
            let juiceLeft = currVolume % 1000;
            let bottlesCount = (currVolume - juiceLeft) / 1000;

            !bottles.hasOwnProperty(name) ? bottles[name] = bottlesCount : bottles[name] += bottlesCount;

            volume = juiceLeft;
        }

        juice[name] += volume;

    }

    for (let [juiceElement, count] of Object.entries(bottles)) {

        console.log(`${juiceElement} => ${count}`);
    }
}