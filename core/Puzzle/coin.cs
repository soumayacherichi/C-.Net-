static string TossCoin()
{
    Console.WriteLine("Tossing a Coin!");
    Random random = new Random();
    int result = random.Next(2);
    if (result == 0)
    {
        Console.WriteLine("Heads");
        return "Heads";
    }
    else
    {
        Console.WriteLine("Tails");
        return "Tails";
    }
}
