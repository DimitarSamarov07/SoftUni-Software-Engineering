async function attachEvents() {
    const postsSelect = document.getElementById("posts");
    const postTitleH1 = document.getElementById("post-title");
    const postBodyUl = document.getElementById("post-body");
    const postCommentsUl = document.getElementById("post-comments");

    const loadPostsBtn = document.getElementById("btnLoadPosts");
    const viewPostBtn = document.getElementById("btnViewPost");

    loadPostsBtn.addEventListener("click", onLoadBtnClick)
    viewPostBtn.addEventListener("click", onViewBtnClick)

    async function onLoadBtnClick() {
        const url = "https://blog-apps-c12bf.firebaseio.com/posts.json"

        const response = await fetch(url);

        const posts = await response.json();

        for (const [key, {title}] of Object.entries(posts)) {
            const option = document.createElement("option");
            option.value = key;
            option.textContent = title;

            postsSelect.appendChild(option)
        }
    }

    async function onViewBtnClick() {
        clearOutput();

        let postId = postsSelect.options[postsSelect.selectedIndex].value;

        const baseUrl = `https://blog-apps-c12bf.firebaseio.com/posts/${postId}.json`;

        const response = await fetch(baseUrl);

        const {body, comments, title} = await response.json();

        postTitleH1.textContent = title;
        postBodyUl.textContent = body;

        for (const [, {text}] of Object.entries(comments)) {
            const li = document.createElement("li");
            li.textContent = text;

            postCommentsUl.appendChild(li);
        }
    }

    function clearOutput() {
        postTitleH1.textContent = "";
        postBodyUl.textContent = "";
        postCommentsUl.innerHTML = "";
    }

}

attachEvents();