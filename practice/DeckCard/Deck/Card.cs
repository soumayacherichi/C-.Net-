public class Card
{
    public string Name;
    public string Suit;
    public int Value;

    public Card(string s, int val)
    {
        switch (val)
        {
            case 11:
                Name = "Jack";
                break;
            case 12:
                Name = "Queen";
                break;
            case 13:
                Name = "King";
                break;
            case 1:
                Name = "Ace";
                break;
            default:
                Name = val.ToString();
                break;
        }
        Suit = s;
        Value = val;
    }

    public override string ToString()
    {
        return $@"
        Name: {Name}
        Suit: {Suit}
        Value: {Value}";
    }
}