// Not written by me

function systemComponents(input) {
    let systems = {};

    input.map(data => {
        let [systemName, componentName, subComponentName] = data.split(' | ');

        !systems.hasOwnProperty(systemName) ? systems[systemName] = {} : 'pass';
        !systems[systemName].hasOwnProperty(componentName)
            ? systems[systemName][componentName] = [subComponentName]
            : systems[systemName][componentName].push(subComponentName);
    });

    for (let system of Object.keys(systems).sort((a, b) =>
    {return Object.keys(systems[b]).length - Object.keys(systems[a]).length || a.localeCompare(b)})) {
        console.log(system);
        for (let component of Object.keys(systems[system]).sort((a, b) =>
            systems[system][b].length - systems[system][a].length)) {
            console.log(`|||${component}`);
            for (let subComponent of systems[system][component]) {
                console.log(`||||||${subComponent}`);
            }
        }
    }
}

