function solution(workerObj) {
    if (workerObj["dizziness"]){
        const weight = workerObj["weight"];
        const experience = workerObj["experience"];

        workerObj["levelOfHydrated"] += 0.1 * weight * experience;
        workerObj["dizziness"] = false;
    }

    return workerObj;
}