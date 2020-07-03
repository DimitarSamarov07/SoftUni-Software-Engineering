function loadRepos() {
    const usernameInput = document.getElementById("username");
    const reposUl = document.getElementById("repos");

    const url = `https://api.github.com/users/${usernameInput.value}/repos`;

    fetch(url)
        .then(res => res.json())
        .then(data => {
            reposUl.innerHTML = "";

            data.forEach(item => {

                const li = document.createElement("li");
                const a = document.createElement("a");

                a.href = item.html_url;
                a.innerText = item.full_name;
                li.appendChild(a);

                reposUl.appendChild(li);
            })
        })

}