using Lab1_4.Services;

namespace Lab1_4;

public partial class DataBasePage : ContentPage
{
    private SQLiteService sqliteserv = new SQLiteService();
    public DataBasePage()
	{
		InitializeComponent();
        sqliteserv.Init();
        var teams = sqliteserv.GetAllTeams();
        this.picker.ItemsSource = teams.Select(item => item.Name).ToList();
    }
    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            var members = sqliteserv.GetMembers(selectedIndex);
            this.ListView.ItemsSource = members.Select(item => item.Name + ' ' + item.Number).ToList();
        }
    }
}