using Lab1_4.Services;

namespace Lab1_4;

public partial class DataBasePage : ContentPage
{
    public DataBasePage()
    {
		InitializeComponent();
        MauiProgram.sqliteService = MauiProgram.services.BuildServiceProvider().GetService<IDbService>();
        MauiProgram.sqliteService?.Init();
        this.picker.ItemsSource = MauiProgram.sqliteService?.GetAllTeams()?.Select(t => t.Name).ToList();
    }
    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
            this.ListView.ItemsSource = MauiProgram.sqliteService?.GetMembers(selectedIndex)?.ToList();
    }
}