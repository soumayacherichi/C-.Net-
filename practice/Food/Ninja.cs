class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;

    // add a constructor
    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }

    // add a public "getter" property called "IsFull"
    bool IsFull
    {
        get
        {
            return calorieIntake > 1200;
        }
    }

    // build out the Eat method
    public void Eat(Food item)
    {
        // If the ninja is not full...
        if (IsFull == false)
        {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine($"The ninja just ate {item.Name}!");
            if (item.IsSpicy)
                Console.WriteLine($"OUCH! That {item.Name} was spicy!!!");
            if (item.IsSweet)
                Console.WriteLine($"MMMMMmmmmm {item.Name} is so sweet.");
        }
        else
        {
            Console.WriteLine("Warning! This ninja is already full!");
        }
    }
}