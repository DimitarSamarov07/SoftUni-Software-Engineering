function solution(string, criteria) {
    const data = JSON.parse(string);
    let propName, propValue;

    if (criteria !== "all") {
        [propName, propValue] = criteria.split("-")
    }

    return data.filter((i) => {
        return propName ? i[propName] === propValue : true;
    }).reduce((acc, curr, index) => {

        acc += `${index}. ${curr.first_name} ${curr.last_name} - ${curr.email}\n`;

        return acc;
    }, "").trimEnd()
}