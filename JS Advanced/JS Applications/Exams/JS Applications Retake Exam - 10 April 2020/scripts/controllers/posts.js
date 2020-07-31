import {create, deletePostById, edit, getPostById} from "../data.js";

export async function createPost() {
    Backendless.UserService.getCurrentUser()
        .then(async (user) => {
            const {title, category, content} = this.params;

            if (user && title && category && content) {
                await create(user.objectId, title, category, content)
                    .then(() => {
                        this.redirect("#/")
                    })
            }
        })
}

export async function deleteGet() {
    const postId = this.params.id;

    await deletePostById(postId)
        .then(() => {
            this.redirect("#/");
        })

}

export async function editGet() {
    const postId = this.params.id;
    const context = await getPostById(postId);
    Object.assign(context, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs'),
    };

    this.partial('./templates/edit/editPage.hbs', context)
        .then(() => {
            $("#editForm").submit((e) => {
                e.preventDefault();
            })
        })
    // .then(() => toggleLoading(false));
}

export async function editPost() {
    const {id, title, content, category} = this.params;

    await edit(id, title, category, content)
        .then(() => {
            this.redirect("#/");
        })
}