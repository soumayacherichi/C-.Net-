class Ninja : Human
{
    public Ninja(string name, int str, int intel, int dex) : base(name, str, intel, dex, 100)
    {
        Dexterity = dex;
    }

    public override int Attack(Human target)
    {
        int dmg = Dexterity;
        if (new Random().Next(0, 100) < 20)
        {
            dmg += 10;
        }
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }

    public void Steal(Human target)
    {
        target.Health -= 5;
        Health += 5;
        Console.WriteLine($"{Name} stole 5 health from {target.Name} and gained 5 health!");
    }
}