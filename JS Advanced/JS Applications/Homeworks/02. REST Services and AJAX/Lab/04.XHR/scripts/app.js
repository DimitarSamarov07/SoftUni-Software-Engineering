function loadRepos() {
    const url = "https://api.github.com/users/testnakov/repos"

    fetch(url)
        .then(res => {
            if (res.status === 200) {
                return res.json();
            }
        })
        .then(data => {
            if (!data) {
                return;
            }

            const outputItem = document.getElementById("res");
            outputItem.textContent = JSON.stringify(data);
        })
}