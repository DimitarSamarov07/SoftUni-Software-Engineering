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


let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);

