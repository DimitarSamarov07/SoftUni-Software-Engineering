function townsToJson(inputArray) {

    let townArr = [];

    for (let i = 1; i < inputArray.length; i++) {
        let [town, latitude, longitude] = inputArray[i].split(" |");

        let townObj = {};

        town = town.split("| ")[1];
        latitude = Number(Number(latitude.trim()).toFixed(2));
        longitude = Number(Number(longitude.trim()).toFixed(2));

        townObj = {Town: town, Latitude: latitude, Longitude: longitude};

        townArr.push(townObj);
    }

    console.log(JSON.stringify(townArr))
}