import {getAllPosts} from "../data.js";

export default async function home() {

    Backendless.UserService.getCurrentUser()
        .then(async (user) =>{
            const context = {posts: await getAllPosts()};

            if (user){
                context.posts.forEach(post => post.isAuthor = post.authorId === user.objectId)
            }

            Object.assign(context, this.app.userData);

            this.partials = {
                header: await this.load('./templates/common/header.hbs'),
                createForm: await this.load('./templates/create/createForm.hbs'),
                anonymousHome: await this.load("./templates/home/anonymousHome.hbs"),
                loggedInHome: await this.load("./templates/home/loggedInHome.hbs")
            };

            this.partial('./templates/home/homePage.hbs', context)
                .then(() =>{
                    $("#createForm").submit((e) =>{
                        e.preventDefault();
                    })
                })
            // .then(() => toggleLoading(false));
        })

}