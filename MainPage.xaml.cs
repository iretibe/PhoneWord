namespace PhoneWord;

public partial class MainPage : ContentPage
{
	string translatedNumber;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnTranslate(object sender, EventArgs e)
    {
        var enteredNumber = PhoneNumberText.Text;

        //translatedNumber = Core.PhoneWordTranslator.ToNumber(enteredNumber);
        translatedNumber = enteredNumber;

        if (!string.IsNullOrEmpty(translatedNumber))
        {
            CallButton.IsEnabled = true;
            CallButton.Text = "Call " + translatedNumber;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }
    }

    async void OnCall(object sender, System.EventArgs e)
    {
        if (await this.DisplayAlert(
            "Dial a Number",
            "Would you like to call " + translatedNumber + "?",
            "Yes",
            "No"))
        {
            try
            {
                PhoneDialer.Open(translatedNumber);
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
            }
            catch (Exception)
            {
                // Other error has occurred.
                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }
        }
    }


    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count += 10;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
}

