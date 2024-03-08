using Lab1_4.Services;

namespace Lab1_4;

public partial class DataBasePage : ContentPage
{
    private readonly IDbService dbService;
    public DataBasePage(IDbService dbService)
    {
		InitializeComponent();
        this.dbService = dbService;
        dbService.Init();
        picker.ItemsSource = dbService.GetAllTeams()?.Select(t => t.Name).ToList();
        
    }
    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
            ListView.ItemsSource = dbService.GetMembers(selectedIndex)?.ToList();
    }
}