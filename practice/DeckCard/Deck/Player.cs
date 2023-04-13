class Player
{
    private string name;
    private List<Card> hand;
    public Player(string name)
    {
        this.name = name;
        hand = new List<Card>();
    }

    public string Name
    {
        get { return name; }
    }

    public Card Draw(Deck d)
    {
        Card theCard = d.Deal();
        hand.Add(theCard);
        return theCard;
    }

    public Card Discard(int idx)
    {
        Card theCard;
        if (idx < hand.Count)
        {
            theCard = hand[idx];
            hand.RemoveAt(idx);
            return theCard;
        }
        else { return null!; }
    }

}