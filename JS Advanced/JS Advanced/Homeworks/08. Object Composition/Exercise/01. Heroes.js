function solve() {
    const fighterProto = {
        fight() {
            this.stamina -= 1;
            console.log(`${this.name} slashes at the foe!`)
        }
    }

    const mageProto = {
        cast(item){
            this.mana -= 1;
            console.log(`${this.name} cast ${item}`)
        }
    }




    return {
        mage(name){
            const mageObj = Object.create(mageProto);
            mageObj.health = 100;
            mageObj.mana = 100;
            mageObj.name = name;

            return mageObj;
        },

        fighter(name){
            const fighterObj = Object.create(fighterProto);
            fighterObj.health = 100;
            fighterObj.stamina = 100;
            fighterObj.name = name;

            return fighterObj;
        }
    }
}

