using Mopups.Services;

namespace RingOfFire.ViewElements;

public partial class PopupCard : Mopups.Pages.PopupPage
{
    public static readonly BindableProperty CardProperty = BindableProperty.Create(nameof(Card), typeof(Card), typeof(PopupCard),
    propertyChanged: (bindable, oldvalue, newvalue) =>
    {
        var control = (PopupCard)bindable;
        control.CardDescription.Text = ((Card)newvalue).Description;
        control.CardDescription2.Text = ((Card)newvalue).Description;
        control.CardImage.Source = ((Card)newvalue).ImageURL;
    });

    public Card Card
    {
        get => (Card)GetValue(CardProperty);
        set => SetValue(CardProperty, value);
    }

    private async void CloseMopup(object sender, TappedEventArgs e)
    {
        await MopupService.Instance.RemovePageAsync(this);
    }

    public PopupCard()
	{
		InitializeComponent();
	}
}