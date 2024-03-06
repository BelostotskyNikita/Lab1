namespace Lab1_4;

public partial class IntegralPage : ContentPage
{
    CancellationTokenSource? source = null;
    bool isCancelled = false, isStarted = false;
    Color color = Color.Parse("LightGray");
    public IntegralPage() => InitializeComponent();
    private async void OnStart(object sender, EventArgs e)
    {
        if (isStarted) return;
        isCancelled = false;
        isStarted = true;
        source = new CancellationTokenSource();
        var token = source.Token;
        Calculation();
        try
        {
            await Task.Run(() => Integrate(token));
            isCancelled = true;
            isStarted = false;
            this.progressLabel.Text = "100%";
        }
        catch (OperationCanceledException)
        {
            isStarted = false;
            this.statusLabel.Text = "Cancelled";
        }
        finally
        {
            source.Dispose();
        }
    }
    private void OnCancel(object sender, EventArgs e)
    {
        if (isCancelled) return;
        source?.Cancel();
        isCancelled = true;
    }
    private void OnPres(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.Background = Colors.Gray;
        Vibration.Default.Vibrate(TimeSpan.FromSeconds(1));
    }
    private void OnRel(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.Background = color;
        Vibration.Default.Cancel();
    }
    void Integrate(CancellationToken token)
    {

        double sum = 0;
        int persent = 0;
        for (double x = 0; x <= 1; x += 0.00001)
        {
            sum += Math.Sin(x) * 0.00001;
            this.prbar.Progress = x;
            persent = (int)(x * 100);
            MainThread.InvokeOnMainThreadAsync(() => { this.progressLabel.Text = persent.ToString() + '%'; });
            if (token.IsCancellationRequested) token.ThrowIfCancellationRequested();
        }
        MainThread.InvokeOnMainThreadAsync(() => { this.statusLabel.Text = "∫sin(x) = " + sum.ToString(); });
    }
    async void Calculation()
    {
        while (isStarted)
        {
            this.statusLabel.Text = "Calculation   ";
            await Task.Delay(200);
            if (!isStarted) break;
            this.statusLabel.Text = "Calculation.  ";
            await Task.Delay(200);
            if (!isStarted) break;
            this.statusLabel.Text = "Calculation.. ";
            await Task.Delay(200);
            if (!isStarted) break;
            this.statusLabel.Text = "Calculation...";
            await Task.Delay(200);
            if (!isStarted) break;
        }
    }
}