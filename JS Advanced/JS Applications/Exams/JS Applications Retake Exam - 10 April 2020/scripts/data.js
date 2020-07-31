const appKey = "36850755-1086-A166-FF48-0D75CB216500";
const restKey = "2A6DDE1E-C00C-415C-8A77-63BEA82C7FAD";


function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    POSTS: 'data/Posts',
    USERS: 'data/Users',
};

export async function create(authorId, title, category, content) {
    await fetch(host(api.POSTS), {
        method: "POST",
        body: JSON.stringify({authorId, title, category, content}),
        headers: {
            'Content-type': 'application/json'
        }
    })
}

export async function getPostById(postID) {
    return await (await fetch(host(api.POSTS + "/" + postID))).json();
}
export async function getAllPosts() {
    return await (await fetch(host(api.POSTS))).json()
}

export async function deletePostById(postId) {
    await fetch(host(api.POSTS + "/" + postId), {
        method: "DELETE"
    })
}

export async function edit(postId, title, category, content) {
    const post = await getPostById(postId);

    post.title = title;
    post.category = category;
    post.content = content;

    await fetch(host(api.POSTS + "/" + postId), {
        method: "PUT",
        body: JSON.stringify(post),
        headers: {
            'Content-type': 'application/json'
        }
    })
}
