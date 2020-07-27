import home from "./controllers/home.js"
import about from "./controllers/about.js"
import {loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";
import {toggleError, toggleInfo} from "./notifications.js";
import {catalogGet, catalogGetAll, createCatalogGet, createCatalogPost} from "./controllers/catalog.js";
import {getUserTeam} from "./data.js";
import {editTeamGet, editTeamPost, joinTeamGet, leaveTeamGet} from "./controllers/team.js";

let userData = {
    loggedIn: false,
    hasTeam: false,
    username: undefined,
    userId: undefined,
    teamId: undefined,
};
Backendless.initApp("6390246F-C3EF-3BAA-FFB6-9DEC1FE25300", "EE4FB9A0-CCCC-4C95-AB37-E4D3BE00FA34");

Backendless.UserService.getCurrentUser()
    .then(async (currUser) => {
        let copyUser = currUser;

        if (!currUser){
            copyUser = {};
        }
        getUserTeam(copyUser.objectId)
            .then((teamArr) => {
                if (currUser){
                    let team;
                    if (teamArr.length > 0) {
                        team = teamArr[0];
                        userData.hasTeam = true
                        userData.teamId = team.objectId;
                    }
                    userData.loggedIn = true;
                    userData.username = currUser.username;
                }

            })
            .then(() => {

                const app = Sammy("#main", async function () {
                    this.use('Handlebars', 'hbs');


                    this.before({}, async function () {
                        toggleError(false, null)
                        toggleInfo(false, null);
                    });

                    this.userData = userData;

                    this.get('/', home);
                    this.get('#/home', home);

                    this.get('#/about', about);

                    this.get("#/login", loginGet);
                    this.post("#/login", ctx => loginPost.call(ctx));

                    this.get("#/register", registerGet);
                    this.post("#/register", ctx => registerPost.call(ctx));

                    this.get("#/logout", logout);

                    this.get("#/leave", leaveTeamGet);

                    this.get("#/catalog/:id", catalogGet);

                    this.get("#/catalog", catalogGetAll);
                    this.post("#/create", ctx => createCatalogPost.call(ctx));

                    this.get("#/create", createCatalogGet);

                    this.get("#/join/:id", joinTeamGet);
                    this.get("#/edit/:id", editTeamGet);
                    this.post("#/edit/:id", editTeamPost);


                })

                app.run("#/")
            })
            .catch() // if the user is trying to provide fake token data
                     // the app won't work :)))


    })
