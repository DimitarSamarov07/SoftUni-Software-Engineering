import {allTeams, getTeam} from "../data.js";

export async function catalogGetAll() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        team: await this.load('./templates/catalog/team.hbs')
    };

    const context = {teams: (await allTeams())};

    Object.assign(context, this.app.userData);
    this.partial("./templates/catalog/teamCatalog.hbs", context)

}

export async function createCatalogGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        createForm: await this.load('./templates/create/createForm.hbs')
    };

    this.partial('./templates/create/createPage.hbs');
}

export async function createCatalogPost() {
    Backendless.UserService.getCurrentUser()
        .then(currUser => {
            const teamName = this.params.name;
            const comment = this.params.comment;

            Backendless.Data.of("Teams")
                .save({
                    name: teamName,
                    description: comment,
                    authorId: currUser.objectId,
                })
                .then(() =>{
                    this.redirect("#/");
                })
                .catch(x => {
                    console.log(x);
                })

        })

}

export async function catalogGet() {
    const id = this.params.id;
    const team = await getTeam(id);

    Object.assign(team, this.app.userData);

    Backendless.UserService.getCurrentUser()
        .then(user =>{
            team.isOnTeam = !!team.members.find(x => x.objectId === user.objectId );
            team.isAuthor = team.authorId === user.objectId;
            team.teamId = team.objectId;
        })

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        teamMember: await this.load("./templates/catalog/teamMember.hbs"),
        teamControls: await this.load("./templates/catalog/teamControls.hbs")
    }

    this.partial("./templates/catalog/details.hbs", team)


}