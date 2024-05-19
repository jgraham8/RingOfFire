using Mopups.Services;

namespace RingOfFire.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private Card? topCard;

    [ObservableProperty]
    private Card? lastPlayedCard;

    [ObservableProperty]
    private List<Card> deck = [];

    [ObservableProperty]
    private int deckCount = 52;

    [ObservableProperty]
    private List<Card> playedDeck = [];

    [ObservableProperty]
    private int playedDeckCount = 0;

    public MainViewModel()
    {
        ResetCards();
    }

    [RelayCommand]
    public void PlayCard()
    {
        if (DeckCount == 0)
        {
            ResetCards();
            return;
        }

        MopupService.Instance.PushAsync(new PopupCard() { Card = Deck[0] });

        PlayedDeck.Add(Deck[0]);
        LastPlayedCard = Deck[0];
        Deck.RemoveAt(0);

        DeckCount--;
        PlayedDeckCount++;

        if (DeckCount == 0)
        {
            return;
        }

        TopCard = Deck[0];
    }

    [RelayCommand]
    public void ResetCards()
    {
        string[,] data =
        {
            {"ace", "WATERFALL: Everyone Drink Until The Current Player Finishes"},
            {"two", "NOMINATE: Pick Someone To Drink"},
            {"three", "DRINK UP: You Drink"},
            {"four", "GIRLS: Girls Drink"},
            {"five", "THUMBS: Last To Put Their Thumb On Table Drinks"},
            {"six", "GUYS: Guys Drink"},
            {"seven", "HEAVEN: Last To Point To The Sky Drinks"},
            {"eight", "MATE: Pick A Mate Who Has To Drink When You Do"},
            {"nine", "RHYME: Pick A Word To Rhyme"},
            {"ten", "CATEGORIES: Pick A Category"},
            {"jack", "RULE: Make A Rule, Rule Breakers Have To Drink"},
            {"queen", "QUESTION MASTER: Anyone Who Answers Your Questions Have To Drink"},
            {"king", "POUR: Pour Some Of Your Drink Into The Middle Cup, Last King Drinks"},
        };

        for (CardSuit suit = CardSuit.Clubs; suit <= CardSuit.Spades; suit++)
        {
            for (int i = 0; i < 13; i++)
            {
                Deck.Add(new Card(name: data[i, 0], description: data[i, 1], suit: suit));
            }
        }

        Deck.Shuffle();

        PlayedDeck.Clear();

        TopCard = Deck[0];

        LastPlayedCard = null;

        DeckCount = 52;

        PlayedDeckCount = 0;
    }
}
