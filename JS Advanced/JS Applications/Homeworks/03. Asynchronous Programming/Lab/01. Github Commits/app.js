async function loadCommits() {
    const usernameValue = document.getElementById("username").value;
    const repoValue = document.getElementById("repo").value;
    const commitsUl = document.getElementById("commits");

    const baseUrl = `https://api.github.com/repos/${usernameValue}/${repoValue}/commits`;

    commitsUl.innerHTML = "";

    const response = await fetch(baseUrl);
    if (response.status < 400) {
        const commits = await response.json();
        for (const {commit: {author: {name}, message}} of commits) {
            const li = document.createElement("li")
            li.textContent = `${name}: ${message}`
            commitsUl.appendChild(li);
        }

    } else {
        const li = document.createElement("li")
        li.textContent = `Error: ${response.status} (${response.statusText})`;
        commitsUl.appendChild(li);
    }
}