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
	
}