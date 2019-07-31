using Skeleton.Contracts;

public class Hero
{
    private string name;
    private int experience;
    private IWeapon weapon;

    public Hero(string name,IWeapon weapon)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = new Axe(10, 10);
        this.Weapon = weapon;
    }

    public string Name
    {
        get { return this.name; }
    }

    public int Experience
    {
        get { return this.experience; }
        set { experience = value; }
    }

    public IWeapon Weapon
    {
        get { return this.weapon; }
        set{weapon=value;}
    }

    public void Attack(ITarget target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.Experience += target.GiveExperience();
        }
    }
}
