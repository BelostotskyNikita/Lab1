namespace Lab1_4
{
    public partial class CalculatorPage : ContentPage
    {
        bool operatorMath = false, firstNum = false, secondNum = false, mem = false, commaL = false;
        char op;
        public CalculatorPage()
        {
            InitializeComponent();
        }
        private void OnDigit(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "0") 
            {
                if ((!commaL && !firstNum) || (!commaL && (!secondNum && operatorMath)))
                {
                    this.result.Text += button.Text + ',';
                    commaL = true;
                    
                }
                else this.result.Text += button.Text;
            }
            else
            {
                if (!firstNum) firstNum = true;
                if (!secondNum && operatorMath) secondNum = true;
                this.result.Text += button.Text;
            }
        }
        private void OnDiv(object sender, EventArgs e)
        {
            if (!firstNum || operatorMath) return;
            Button button = (Button)sender;
            this.result.Text += button.Text;
            operatorMath = true;
            commaL = false;
            op = '÷';
        }
        private void OnMul(object sender, EventArgs e)
        {
            if (!firstNum || operatorMath) return;
            Button button = (Button)sender;
            this.result.Text += button.Text;
            operatorMath = true;
            commaL = false;
            op = '×';
        }
        private void OnAdd(object sender, EventArgs e)
        {
            if (!firstNum || operatorMath) return;
            Button button = (Button)sender;
            this.result.Text += button.Text;
            operatorMath = true;
            commaL = false;
            op = '+';
        }
        private void OnSub(object sender, EventArgs e)
        {
            if (!firstNum || operatorMath) return;
            Button button = (Button)sender;
            this.result.Text += button.Text;
            operatorMath = true;
            commaL = false;
            op = '-';
        }
        private void OnEqu(object sender, EventArgs e)
        {
            if (!firstNum || !secondNum) return;
            string firstN = "", secondN = "";
            int i;
            double temp;
            if (this.result.Text[0] == '-')
            {
                i = 1;
                firstN += '-';
            }
            else i = 0;
            for (; this.result.Text[i] >= '0' && this.result.Text[i] <= '9' || this.result.Text[i] == ','; i++) firstN += this.result.Text[i];
            i++;
            for (; i < this.result.Text.Length; i++) secondN += this.result.Text[i];
            this.mem4.Text = this.mem3.Text;
            this.mem3.Text = this.mem2.Text;
            this.mem2.Text = this.mem1.Text;
            this.mem1.Text = this.result.Text;
            this.result.Text = "";
            if (op == '+') temp = double.Parse(firstN) + double.Parse(secondN);
            else if (op == '-') temp = double.Parse(firstN) - double.Parse(secondN);
            else if (op == '×') temp = double.Parse(firstN) * double.Parse(secondN);
            else if (op == '%') temp = double.Parse(firstN) / 100 * double.Parse(secondN);
            else if (op == '^') temp = Math.Pow(double.Parse(firstN), double.Parse(secondN));
            else temp = double.Parse(firstN) / double.Parse(secondN);
            if (temp.ToString().Length > 10) this.mem1.Text += '=' + temp.ToString().Remove(10);
            else this.mem1.Text += '=' + temp.ToString();
            mem = true;
            firstNum = secondNum = operatorMath = false;
            commaL = false;
        }
        private void OnPercent(object sender, EventArgs e)
        {
            if (!firstNum || operatorMath) return;
            Button button = (Button)sender;
            this.result.Text += button.Text;
            operatorMath = true;
            commaL = false;
            op = '%';
        }
        private void OnClear(object sender, EventArgs e)
        {
            this.result.Text = this.mem1.Text = this.mem2.Text = this.mem3.Text = this.mem4.Text = "";
            op = ' ';
            firstNum = secondNum = operatorMath = mem = commaL = false;
        }
        private void OnCustom(object sender, EventArgs e)
        {
            if (!firstNum || operatorMath) return;
            Button button = (Button)sender;
            this.result.Text += '^';
            operatorMath = true;
            commaL = false;
            op = '^';
        }
        private void OnDel(object sender, EventArgs e)
        {
            if (this.result.Text.Length == 0) return;
            else if (this.result.Text.Length == 1) firstNum = false;
            else if (this.result.Text[this.result.Text.Length-1] == '+' ||
                     this.result.Text[this.result.Text.Length-1] == '-' ||
                     this.result.Text[this.result.Text.Length-1] == '×' ||
                     this.result.Text[this.result.Text.Length-1] == '÷' ||
                     this.result.Text[this.result.Text.Length-1] == '^') operatorMath = false;
            else if (this.result.Text[this.result.Text.Length-2] == '+' ||
                     this.result.Text[this.result.Text.Length-2] == '-' ||
                     this.result.Text[this.result.Text.Length-2] == '×' ||
                     this.result.Text[this.result.Text.Length-2] == '÷' ||
                     this.result.Text[this.result.Text.Length-2] == '^') secondNum = false;
            this.result.Text = this.result.Text.Remove(this.result.Text.Length-1);
        }
        private void OnSqu(object sender, EventArgs e)
        {
            if (operatorMath || !firstNum) return;
            double temp = double.Parse(this.result.Text);
            double tempsqu = temp * temp;
            this.mem4.Text = this.mem3.Text;
            this.mem3.Text = this.mem2.Text;
            this.mem2.Text = this.mem1.Text;
            if (temp.ToString().Length > 10) this.mem1.Text = temp.ToString() + "^2=" + tempsqu.ToString().Remove(10);
            else this.mem1.Text = temp.ToString() + "^2=" + tempsqu.ToString();
            this.result.Text = "";
            firstNum = false;
            commaL = false;
            mem = true;
        }
        private void OnSquRoot(object sender, EventArgs e)
        {
            if (operatorMath || !firstNum) return;
            if (this.result.Text[0] == '-') return;
            double temp = double.Parse(this.result.Text);
            double tempsqu = Math.Sqrt(temp);
            this.mem4.Text = this.mem3.Text;
            this.mem3.Text = this.mem2.Text;
            this.mem2.Text = this.mem1.Text;
            if (temp.ToString().Length > 10) this.mem1.Text = '√' + temp.ToString() + '=' + tempsqu.ToString().Remove(10);
            else this.mem1.Text = '√' + temp.ToString() + '=' + tempsqu.ToString();
            this.result.Text = "";
            firstNum = false;
            commaL = false;
            mem = true;
        }
        private void OnInvert(object sender, EventArgs e)
        {
            if (operatorMath || !firstNum) return;
            double temp = double.Parse(this.result.Text);
            if (temp == 0) return;
            double tempInvert = 1.0 / temp;
            this.mem4.Text = this.mem3.Text;
            this.mem3.Text = this.mem2.Text;
            this.mem2.Text = this.mem1.Text;
            if (tempInvert.ToString().Length > 15) this.mem1.Text = "1/" + temp.ToString() + '=' + tempInvert.ToString().Remove(10, tempInvert.ToString().Length - 14);
            else this.mem1.Text = "1/" + temp.ToString() + '=' + tempInvert.ToString();
            this.result.Text = "";
            firstNum = false;
            commaL = false;
            mem = true;
        }
        private void OnNeg(object sender, EventArgs e)
        {
            if (operatorMath || (!firstNum && !mem)) return;
            if (!firstNum)
            {
                string temp = "";
                int i = 1;
                for (; this.mem1.Text[i]  >= '0' && this.mem1.Text[i] <= '9'; i++) { }
                i++;
                for (; this.mem1.Text[i]  >= '0' && this.mem1.Text[i] <= '9'; i++) { }
                i++;
                if (this.mem1.Text[i] == '-')
                {
                    i++;
                    for (; i < this.mem1.Text.Length; i++) temp += this.mem1.Text[i];
                    this.result.Text = temp;
                }
                else
                {
                    for (; i < this.mem1.Text.Length; i++) temp += this.mem1.Text[i];
                    this.result.Text = '-' + temp;
                }
            }
            else
            {
                if (this.result.Text[0]  == '-')
                {
                    string tmp = this.result.Text.Remove(0, 1);
                    this.result.Text = tmp;
                }
                else this.result.Text = '-' + this.result.Text;
            }
            firstNum = true;
        }
        private void OnComma(object sender, EventArgs e)
        {
            if (commaL) return;
            if (!firstNum) return;
            if (!operatorMath) this.result.Text += ',';
            else if (operatorMath && !secondNum) return;
            else this.result.Text += ',';
            commaL = true;
        }
        private void OnPres(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != "=")
            {
                if (Application.Current.RequestedTheme == AppTheme.Dark) button.Background = Colors.DimGray;
                else button.Background = Colors.LightGray;
            }
            Vibration.Default.Vibrate(TimeSpan.FromSeconds(1));
        }
        private void OnRel(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != "=") button.Background = Colors.Transparent;
            Vibration.Default.Cancel();
        }

    }
}