class VeterinaryClinic {

    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = {};
        this.totalProfit = 0;
        this.currentWorkload = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        kind = kind.toLowerCase();
        if (this.currentWorkload + 1 > this.capacity) {
            throw new Error("Sorry, we are not able to accept more patients!");
        }

        const client = this.clients[ownerName];
        let pet;
        if (client) {
            pet = client.find(x => x.petName === petName);
        }

        if (pet && pet.procedures.length > 0) {
            throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${pet.procedures.join(", ")}.`);
        }

        this.currentWorkload++;

        !this.clients[ownerName] ? this.clients[ownerName] = [] : ""

        if (!pet) {
            this.clients[ownerName].push({petName, kind, procedures});
        } else {
            pet.procedures = procedures;
        }
        return `Welcome ${petName}!`
    }

    onLeaving(ownerName, petName) {
        const client = this.clients[ownerName];

        if (!client) {
            throw new Error("Sorry, there is no such client!");
        }

        const clientPet = client.find(x => x.petName === petName)
        const doesPetExist = !!clientPet;

        if (doesPetExist && clientPet.procedures.length > 0) {
            const bill = clientPet.procedures.length * 500;
            this.totalProfit += bill;
            this.currentWorkload -= 1;

            clientPet.procedures = [];

            return `Goodbye ${petName}. Stay safe!`;
        }

        if (!clientPet || clientPet.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`)

        }

    }

    toString() {
        const percentage = (this.currentWorkload / this.capacity) * 100;
        let result = `${this.clinicName} is ${percentage}% busy today!\n`;

        result += `Total profit: ${this.totalProfit.toFixed(2)}$\n`;

        result += Object.entries(this.clients)
            .sort(([owner1, stuff1], [owner2, stuff2]) => owner1.localeCompare(owner2))
            .reduce((acc, [ownerName, pets]) => {

                acc += `${ownerName} with:\n`;
                acc += pets
                    .sort(({petName: petName1}, {petName: petName2}) => petName1.localeCompare(petName2))
                    .reduce((acc, {petName, kind, procedures}) => {
                        return acc += `---${petName} - a ${kind} that needs: ${procedures.join(", ")}\n`
                    }, "")

                return acc;
            }, "")

        return result.trim();
    }
}

