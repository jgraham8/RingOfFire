namespace RingOfFire.Models;
public class Card(string name, string description, CardSuit suit)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public CardSuit Suit { get; set; } = suit;
    public string ImageURL => $"{Name}_of_{Suit}";
    public string BackURL => $"card_back";


}

public enum CardSuit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}
