// the speed is in km/h
// the foootprint length is in meteres
function calculateTimeToWalk(steps, footprintLength, speed) {

    let distanceInMeteres = steps * footprintLength;
    let distanceInKm = distanceInMeteres / 1000;

    let restTime = (Math.floor(distanceInMeteres / 500)) * 60; //in seconds

    let seconds = Math.round((distanceInKm / speed) * 3600 + restTime);

    let time = new Date(seconds * 1000).toISOString().substr(11, 8);

    console.log(time)
}