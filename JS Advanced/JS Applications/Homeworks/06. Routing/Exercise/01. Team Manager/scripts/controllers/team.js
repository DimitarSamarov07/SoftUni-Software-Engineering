import {editTeam, getTeam, joinTeam, leaveTeam} from "../data.js";
import {toggleInfo} from "../notifications.js";


export async function joinTeamGet() {
    const teamId = this.params.id;
    const hasTeam = this.app.userData.hasTeam;
    Backendless.UserService.getCurrentUser()
        .then(async (user) => {
            await joinTeam(user.objectId, teamId, hasTeam)
                .then(() => {
                    this.app.userData.hasTeam = true;
                    this.app.userData.teamId = teamId;

                    toggleInfo(true, "You have joined the team!");

                    setTimeout(function () {
                        this.redirect("#/")
                    }.bind(this), 1000)
                })
        })
}

export async function leaveTeamGet() {
    Backendless.UserService.getCurrentUser()
        .then(async (user) => {
            leaveTeam(user.objectId)
                .then(() => {
                    this.app.userData.hasTeam = false;
                    this.app.userData.teamId = null;

                    toggleInfo(true, "You have left the team!");

                    setTimeout(function () {
                        this.redirect("#/")
                    }.bind(this), 1000)
                });


        })
}

export async function editTeamGet() {
    const teamId = this.params.id;

    const {name, description} = await getTeam(teamId);

    const context = {teamId, name, description};

    Object.assign(context, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs')
    };

    this.partial("./templates/edit/editPage.hbs", context)
        .then(() =>{
            $("#editForm").submit(function(e) {
                e.preventDefault();
            });
        });


}

export async function editTeamPost() {
    Backendless.UserService.getCurrentUser()
        .then(user => {
            const teamId = this.params.id;
            const newName = this.params.name;
            const newDescription = this.params.description;

            editTeam(user.objectId, teamId, newName, newDescription)
                .then(() => {
                    toggleInfo(true, "Team edited successfully!!")

                    setTimeout(function () {
                        this.redirect("#/catalog/" + teamId);
                    }.bind(this))
                })
                .catch();
        })
}