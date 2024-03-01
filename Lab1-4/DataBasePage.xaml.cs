using Lab1_4.Services;

namespace Lab1_4;

public partial class DataBasePage : ContentPage
{
    private SQLiteService sqliteserv = new SQLiteService();
    public DataBasePage()
	{
		InitializeComponent();
        sqliteserv.Init();
	}
	private void one_Clicked(object sender, EventArgs e)
    {
        var teams = sqliteserv.GetAllTeams().ToList();
        this.picker.ItemsSource = teams;
    }
}