﻿namespace Bill_Payment;

public partial class MainPage : ContentPage
{
	decimal Total_bill;
	int tip;
	int numberOfPeople = 1;
	public MainPage()
	{
		InitializeComponent();
	}

	private void Bill_text_Completed(object sender, EventArgs e)
	{
		Total_bill = decimal.Parse(Bill_text.Text);
		calculateTotal();
	}

	private void calculateTotal()
	{
		
	}

	private void sliderTiplbl_ValueChanged(object sender, ValueChangedEventArgs e)
	{
        tip = (int)sliderTip.Value;
		custom_tip_lbl.Text = $"Tip: {tip}%";
		calculateTotal();
    }


	private void Button_Clicked(object sender, EventArgs e)
	{
		if(sender is Button)
		{
			var button = (Button)sender;
			var percentage = int.Parse(button.Text.Replace("%", ""));
			sliderTip.Value = percentage;
		}
	}
}

