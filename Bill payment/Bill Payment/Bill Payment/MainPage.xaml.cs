namespace Bill_Payment;

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
		//total tip
		var total_tip = (Total_bill * tip) / 100;
		//tip by person
		var tip_by_person = total_tip / numberOfPeople;
		//assign to label 
		Tip_change.Text = $"{tip_by_person:C}";

		//subtotal 
		var subtotal = Total_bill / numberOfPeople;
		Sub_total_change.Text = $"{subtotal:C}";

		//Total amount 
		var total_by_person = (Total_bill + total_tip) / numberOfPeople;
		Total_payment.Text = $"{total_by_person:C}";
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

	private void minus_btn_Clicked(object sender, EventArgs e)
	{
		if(numberOfPeople > 1)
		{
			numberOfPeople--;
		}
        text_person_split_lbl.Text = numberOfPeople.ToString();
		calculateTotal();
    }

	private void addition_btn_Clicked(object sender, EventArgs e)
	{
        
        numberOfPeople++;
        
        text_person_split_lbl.Text = numberOfPeople.ToString();
		calculateTotal();
    }
}

