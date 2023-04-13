class Wizard : Human
{
    public Wizard(string name, int str, int intel, int dex) : base(name, str, intel, dex, 50)
    {
        Intelligence = intel;
    }

    public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage and healed {Name} for {dmg} health!");
        return target.Health;
    }

    public void Heal(Human target)
    {
        int amount = Intelligence * 3;
        target.Health += amount;
        Console.WriteLine($"{Name} healed {target.Name} for {amount} health!");
    }
}
