namespace RingOfFire.ViewElements;

public partial class LabelCardCounter : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(LabelCardCounter),
    propertyChanged: (bindable, oldvalue, newvalue) =>
    {
        var control = (LabelCardCounter)bindable;
        control.TextLabel.Text = newvalue as string;
    });

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty RotationProperty = BindableProperty.Create(nameof(Text), typeof(int), typeof(LabelCardCounter),
    propertyChanged: (bindable, oldvalue, newvalue) =>
    {
        var control = (LabelCardCounter)bindable;
        control.TextLabel.Rotation = (int)newvalue;
    });

    public int Rotation
    {
        get => (int)GetValue(RotationProperty);
        set => SetValue(RotationProperty, value);
    }

    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(Size), typeof(int), typeof(LabelCardCounter),
    propertyChanged: (bindable, oldvalue, newvalue) =>
    {
        var control = (LabelCardCounter)bindable;
        control.TextLabel.FontSize = (int)newvalue;
    });

    public int FontSize
    {
        get { return FontSize; }
        set => SetValue(FontSizeProperty, value);
    }

    public LabelCardCounter()
	{
		InitializeComponent();
	}   
}