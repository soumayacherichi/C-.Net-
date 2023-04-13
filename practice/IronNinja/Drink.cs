class Drink : IConsumable
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; } = true;

    // Implement a GetInfo Method
    public string GetInfo()
    {
        return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
    // Add a constructor method

    public Drink(string name, int cal, bool sp, bool sw)
    {
        Name = name;
        Calories = cal;
        IsSpicy = sp;
        IsSweet = sw;
    }
}