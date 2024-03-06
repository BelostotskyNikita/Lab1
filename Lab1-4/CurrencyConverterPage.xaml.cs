using Lab1_4.Services;

namespace Lab1_4;

public partial class CurrencyConverterPage : ContentPage
{
	public CurrencyConverterPage()
	{
		InitializeComponent();
        MauiProgram.rateService = MauiProgram.services.BuildServiceProvider().GetService<IRateService>();
    }
    private void picker1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void picker2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void OnEntry1TextChanged(object sender, TextChangedEventArgs e)
    {

    }
    private void OnEntry2TextChanged(object sender, TextChangedEventArgs e)
    {

    }

}