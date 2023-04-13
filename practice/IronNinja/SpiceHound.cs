class SpiceHound : Ninja
{
    // provide override for IsFull (Full at 1200 Calories)
    public override bool IsFull
    {
        get
        {
            if (calorieIntake >= 1200)
            {
                return true;
            }
            return false;
        }
    }

    public override void Consume(IConsumable item)
    {
        if (IsFull == true)
        {
            Console.WriteLine("The ninja is too full to eat any more.");
        }
        else
        {
            ConsumptionHistory.Add(item);
            calorieIntake += item.Calories;

            if (item.IsSpicy == true)
            {
                calorieIntake -= 5;
            }
            Console.WriteLine(item.GetInfo());
        }
    }
}