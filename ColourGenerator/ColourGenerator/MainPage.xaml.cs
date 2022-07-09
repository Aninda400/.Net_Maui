namespace ColourGenerator;

public partial class MainPage : ContentPage
{
	bool isRandomValue;
	public MainPage()
	{
		InitializeComponent();
	}
// https://github.com/Aninda400/.Net_Maui.git
	private void setColour(Color colour)
	{
		random_btn.BackgroundColor = colour;
		Container.BackgroundColor = colour;
		Hex_Value.Text = colour.ToHex();
	}
	private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!isRandomValue)
		{
			var red = sliderRed.Value;
			var blue = sliderBlue.Value;
			var green = sliderGreen.Value;

			Color colour = Color.FromRgb(red, green, blue);
			setColour(colour);
		}
	}

	private void random_btn_Clicked(object sender, EventArgs e)
	{
		isRandomValue = true;
		var random = new Random();
		var colour = Color.FromRgb(random.Next(0, 256), random.Next(0,256),random.Next(0,256));

		setColour(colour);
		sliderRed.Value = colour.Red;
		sliderBlue.Value = colour.Blue;
		sliderGreen.Value = colour.Green;
		isRandomValue = false;
	}
}

