using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ev1_Interfaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private float op1 = 0;
        private float op2;
        private String op = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b.Content.ToString() == "1" || b.Content.ToString() == "2" || b.Content.ToString() == "3" ||
                b.Content.ToString() == "4" || b.Content.ToString() == "5" || b.Content.ToString() == "6" ||
                b.Content.ToString() == "7" || b.Content.ToString() == "8" || b.Content.ToString() == "9" ||
                b.Content.ToString() == "0") {
                if (tb.Text == "0")
                {
                    tb.Text = b.Content.ToString();
                } else
                {
                    tb.Text += b.Content.ToString();
                }
            } else if (b.Content.ToString() == "/" || b.Content.ToString() == "*" || b.Content.ToString() == "+" ||
                b.Content.ToString() == "-") {
                Arit_Click(b.Content.ToString());
            } else if (b.Content.ToString() == ".") {
                Dot_Click();
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if(op != null) {
                float ph;
                op2 = float.Parse(tb.Text, CultureInfo.InvariantCulture.NumberFormat);
                switch (op) {
                    case "/":
                        tb.Text = (op1 / op2).ToString();
                        tb.Text = tb.Text.Replace(",", ".");
                        ph = op1 / op2;
                        op1 = ph;
                        break;
                    case "*":
                        tb.Text = (op1 * op2).ToString();
                        tb.Text = tb.Text.Replace(",", ".");
                        ph = op1 * op2;
                        op1 = ph;
                        break;
                    case "+":
                        tb.Text = (op1 + op2).ToString();
                        tb.Text = tb.Text.Replace(",", ".");
                        ph = op1 + op2;
                        op1 = ph;
                        break;
                    case "-":
                        tb.Text = (op1 - op2).ToString();
                        tb.Text = tb.Text.Replace(",", ".");
                        ph = op1 - op2;
                        op1 = ph;
                        break;
                    default:
                        return;
                        break;
                }
            } else {
                return;
            }
        }

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "0";
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0)
            {
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
                if(tb.Text.Length == 0)
                {
                    tb.Text = "0";
                }
            }
        }

        private void Dot_Click()
        {
            tb.Text += ".";
        }

        private void Arit_Click(String op)
        {
            this.op = op;
            op1 = float.Parse(tb.Text, CultureInfo.InvariantCulture.NumberFormat);
            tb.Text = "0";
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
