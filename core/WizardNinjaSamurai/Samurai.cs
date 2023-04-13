class Samurai : Human
{
    public Samurai(string name, int str, int intel, int dex) : base(name, str, intel, dex, 200)
    {
    }

    public override int Attack(Human target)
    {
        int remainingHealth = target.Health - (Strength * 3);
        if (remainingHealth < 50)
        {
            target.Health = 0;
            Console.WriteLine($"{Name} attacked {target.Name} and dealt {remainingHealth} damage, reducing {target.Name}'s health to 0!");
            return 0;
        }
        else
        {
            target.Health = remainingHealth;
            Console.WriteLine($"{Name} attacked {target.Name} for {Strength * 3} damage!");
            return target.Health;
        }
    }

    public void Meditate()
    {
        Health = 200;
        Console.WriteLine($"{Name} meditated and restored their health to full!");
    }
}