function solution(inputArr) {
    let data = [];

    const processor = {
        add: (str) => data.push(str),
        remove: (str) => data = data.filter(i => i !== str),
        print: () => console.log(data.join(","))
    }

    inputArr.forEach(curr => {
        const [command, argument] = curr.split(" ");
        processor[command](argument);
    })
}

solution(['add pesho', 'add george', 'add peter', 'remove peter','print'])