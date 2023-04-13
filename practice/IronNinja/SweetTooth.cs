class SweetTooth : Ninja
{
    public override bool IsFull
    {
        get
        {
            if (calorieIntake >= 1500)
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

            if (item.IsSweet == true)
            {
                calorieIntake += 10;
            }
            Console.WriteLine(item.GetInfo());
        }
    }
}