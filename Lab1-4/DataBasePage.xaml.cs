using Lab1_4.Services;
using Lab1_4.Entities;

namespace Lab1_4;

public partial class DataBasePage : ContentPage
{
    private SQLiteService sqliteserv = new SQLiteService();
    public DataBasePage()
	{
		InitializeComponent();
        sqliteserv.Init();
        this.picker.ItemsSource = sqliteserv.GetAllTeams().Select(item => item.Name).ToList();
    }
    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            var members = sqliteserv.GetMembers(selectedIndex).ToList();
            this.ListView.ItemsSource = members;
        }
    }
}