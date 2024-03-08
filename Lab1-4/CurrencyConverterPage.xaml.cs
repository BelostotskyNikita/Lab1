using Lab1_4.Services;
using Lab1_4.Entities;

namespace Lab1_4;

public partial class CurrencyConverterPage : ContentPage
{
    private readonly IRateService _rateService;
    private IEnumerable<Rate>? rates;
    public CurrencyConverterPage(IRateService rateService)
	{
		InitializeComponent();
        _rateService = rateService;
        DateChanged(DateTime.Today);
        picker1.SelectedIndex = 0;
    }
    private void picker2_SelectedIndexChanged(object sender, EventArgs e)
        => convert(true);
    private void entry1_TextChanged(object sender, TextChangedEventArgs e)
        => convert(true);
    private void entry2_TextChanged(object sender, TextChangedEventArgs e)
        => convert(false);
    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (datePicker.Date > DateTime.Today.Date)
        {
            datePicker.Date = DateTime.Today.Date;
            return;
        }
        DateChanged(datePicker.Date);
        convert(true);
    }
    private async void DateChanged(DateTime date)
    {
        rates = await _rateService.GetRates(date);
        if (picker2.ItemsSource.Count == 0)
            picker2.ItemsSource = rates?.Select(t => t.Cur_Abbreviation).ToList();
    }
    private void convert(bool entry1changed)
    {
        if (picker2.SelectedIndex == -1) return;
        decimal num;
        var currRate = rates?.FirstOrDefault(curr => curr.Cur_Abbreviation == picker2.SelectedItem.ToString());
        if (entry1changed)
        {
            if (!decimal.TryParse(entry1.Text, out num)) return;
            entry2.Text = ((decimal)(num / currRate?.Cur_OfficialRate * currRate?.Cur_Scale)).ToString("0.#####");
        }
        else
        {
            if (!decimal.TryParse(entry2.Text, out num)) return;
            entry1.Text = ((decimal)(num / currRate?.Cur_Scale * currRate?.Cur_OfficialRate)).ToString("0.#####");
        }
    }
}