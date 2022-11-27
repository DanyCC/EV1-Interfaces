using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
        //Parametros encargados de almacenar el primer y segundo operando y el tipo de operacion respectivamente
        private float op1;
        private float op2;
        private String op = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        //Metodo que se llama cuando se pulsa cualquier boton
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            //Si el boton es un numero, que este se escriba en la calculadora
            if (b.Content.ToString() == "1" || b.Content.ToString() == "2" || b.Content.ToString() == "3" ||
                b.Content.ToString() == "4" || b.Content.ToString() == "5" || b.Content.ToString() == "6" ||
                b.Content.ToString() == "7" || b.Content.ToString() == "8" || b.Content.ToString() == "9" ||
                b.Content.ToString() == "0" || b.Content.ToString() == ".")
            {
                //Si el texto esta "vacio" (0) que el numero se sobreescriba, si se ha indicado que el numero sea negativo, 
                //se le añade un 0 delante, si no se suma a lo que haya escrito en la calculadora
                if (tb.Text.Equals("0"))
                {
                    tb.Text = b.Content.ToString();
                }
                else if (tb.Text.Equals("-0"))
                {
                    tb.Text = "-" + b.Content.ToString();
                }
                else
                {
                    tb.Text += b.Content.ToString();
                }
                //Si el boton es una operacion, se llama al metodo Arit_click, menos si es un menos y la calculadora esta vacia,
                //En cual caso se indicara que el siguiente numero que se escriba es negativo
            }
            else if (b.Content.ToString() == "/" || b.Content.ToString() == "*" || b.Content.ToString() == "+")
            {
                Arit_Click(b.Content.ToString());
            }
            else if (b.Content.ToString() == "-")
            {
                if (tb.Text.Equals("0"))
                {
                    tb.Text = "-0";
                }
                else
                {
                    Arit_Click(b.Content.ToString());
                }
            }
        }

        //Metodo encargado de manejar el boton igual
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            //Si la operacion no es nula, se evalua que operacion se ha escogido, si no el boton es inservible
            if(op != null) {
                // se crea un placeholder para la operacion y se almacena que numero es el segundo operando
                float ph;
                op2 = float.Parse(tb.Text, CultureInfo.InvariantCulture.NumberFormat);
                //Se evalua la operacion con un switch
                switch (op) {
                    case "/":
                        // se cambia el texto de la calculadora al resultado de la operacion y el operando 1 se convierte en el resultado,
                        // por si se quiere reoperar, las variables luego de esto se reinicializan, menos op1
                        tb.Text = (op1 / op2).ToString();
                        tb.Text = tb.Text.Replace(",", ".");
                        ph = op1 / op2;
                        op1 = ph;
                        op = null;
                        op2 = 0;
                        break;
                    case "*":
                        tb.Text = (op1 * op2).ToString();
                        tb.Text = tb.Text.Replace(",", ".");
                        ph = op1 * op2;
                        op1 = ph;
                        op = null;
                        op2 = 0;
                        break;
                    case "+":
                        tb.Text = (op1 + op2).ToString();
                        tb.Text = tb.Text.Replace(",", ".");
                        ph = op1 + op2;
                        op1 = ph;
                        op = null;
                        op2 = 0;
                        break;
                    case "-":
                        tb.Text = (op1 - op2).ToString();
                        tb.Text = tb.Text.Replace(",", ".");
                        ph = op1 - op2;
                        op1 = ph;
                        op = null;
                        op2 = 0;
                        break;
                    default:
                        return;
                        break;
                }
            } else {
                return;
            }
        }

        // Metodo que maneja el boton "Off"
        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            //Esta linea cierra la aplicacion
            Application.Current.Shutdown();
        }

        // Metodo que maneja el boton "Del"
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            //Vacia la calculadora y la devuelve a 0
            tb.Text = "0";
        }

        // Metodo que maneja el boton "R"
        private void R_Click(object sender, RoutedEventArgs e)
        {
            //Si la longitud del texto es menor o igual a cero no hace nada
            if (tb.Text.Length > 0)
            {
                //Elimina el ultimo caracter escrito en la calculadora
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
                //Si la longitud es 0, el texto sera igual a "0"
                if(tb.Text.Length == 0)
                {
                    tb.Text = "0";
                }
            }
        }

        // Metodo que maneja los botones de operacion
        private void Arit_Click(String op)
        {
            // pone la operacion del boton indicado y convierte el primer operando en el texto que habia en la calculadora 
            // antes de pulsar el boton. Despues de esto reinicializa el texto de la calculadora
            this.op = op;
            op1 = float.Parse(tb.Text, CultureInfo.InvariantCulture.NumberFormat);
            tb.Text = "0";
        }

        // Metodo encargado de manejar los botones del menu
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            // if encargado de identificar que boton se ha pulsado
            if (mi.Header.ToString().Equals("Negrita"))
            {
                // Si el boton de negrita se checkea, normal se deja de chequear y cambia el formato a negrita
                if (mi.IsChecked)
                {
                    Normal.IsChecked = false;
                    tb.FontWeight = FontWeights.Bold;
                    One.FontWeight = FontWeights.Bold;
                    Two.FontWeight = FontWeights.Bold;
                    Three.FontWeight = FontWeights.Bold;
                    Four.FontWeight = FontWeights.Bold;
                    Five.FontWeight = FontWeights.Bold;
                    Six.FontWeight = FontWeights.Bold;
                    Seven.FontWeight = FontWeights.Bold;
                    Eight.FontWeight = FontWeights.Bold;
                    Nine.FontWeight = FontWeights.Bold;
                    Zero.FontWeight = FontWeights.Bold;
                    Del.FontWeight = FontWeights.Bold;
                    R.FontWeight = FontWeights.Bold;
                    Off.FontWeight = FontWeights.Bold;
                    Divide.FontWeight = FontWeights.Bold;
                    Multiply.FontWeight = FontWeights.Bold;
                    Add.FontWeight = FontWeights.Bold;
                    Substract.FontWeight = FontWeights.Bold;
                    Equals.FontWeight = FontWeights.Bold;
                    Dot.FontWeight = FontWeights.Bold;
                } else //Si no esta checkeado, se quita la negrita, si cursiva tampoco esta checkeado, normal se checkea
                {
                    if (!Italic.IsChecked)
                    {
                        Normal.IsChecked = true;
                    }
                    tb.FontWeight = FontWeights.Normal;
                    One.FontWeight = FontWeights.Normal;
                    Two.FontWeight = FontWeights.Normal;
                    Three.FontWeight = FontWeights.Normal;
                    Four.FontWeight = FontWeights.Normal;
                    Five.FontWeight = FontWeights.Normal;
                    Six.FontWeight = FontWeights.Normal;
                    Seven.FontWeight = FontWeights.Normal;
                    Eight.FontWeight = FontWeights.Normal;
                    Nine.FontWeight = FontWeights.Normal;
                    Zero.FontWeight = FontWeights.Normal;
                    Del.FontWeight = FontWeights.Normal;
                    R.FontWeight = FontWeights.Normal;
                    Off.FontWeight = FontWeights.Normal;
                    Divide.FontWeight = FontWeights.Normal;
                    Multiply.FontWeight = FontWeights.Normal;
                    Add.FontWeight = FontWeights.Normal;
                    Substract.FontWeight = FontWeights.Normal;
                    Equals.FontWeight = FontWeights.Normal;
                    Dot.FontWeight = FontWeights.Normal;
                }
                // Con la cursiva la logica es exactamente la misma solo que se invierten los papeles de italic y bold
            } else if (mi.Header.ToString().Equals("Cursiva"))
            {
                if (mi.IsChecked)
                {
                    Normal.IsChecked= false;
                    tb.FontStyle = FontStyles.Italic;
                    One.FontStyle = FontStyles.Italic;
                    Two.FontStyle = FontStyles.Italic;
                    Three.FontStyle = FontStyles.Italic;
                    Four.FontStyle = FontStyles.Italic;
                    Five.FontStyle = FontStyles.Italic;
                    Six.FontStyle = FontStyles.Italic;
                    Seven.FontStyle = FontStyles.Italic;
                    Eight.FontStyle = FontStyles.Italic;
                    Nine.FontStyle = FontStyles.Italic;
                    Zero.FontStyle = FontStyles.Italic;
                    Del.FontStyle = FontStyles.Italic;
                    R.FontStyle = FontStyles.Italic;
                    Off.FontStyle = FontStyles.Italic;
                    Divide.FontStyle = FontStyles.Italic;
                    Multiply.FontStyle = FontStyles.Italic;
                    Add.FontStyle = FontStyles.Italic;
                    Substract.FontStyle = FontStyles.Italic;
                    Equals.FontStyle = FontStyles.Italic;
                    Dot.FontStyle = FontStyles.Italic;
                } else
                {
                    if(!Bold.IsChecked)
                    {
                        Normal.IsChecked= true;
                    }
                    tb.FontStyle = FontStyles.Normal;
                    One.FontStyle = FontStyles.Normal;
                    Two.FontStyle = FontStyles.Normal;
                    Three.FontStyle = FontStyles.Normal;
                    Four.FontStyle = FontStyles.Normal;
                    Five.FontStyle = FontStyles.Normal;
                    Six.FontStyle = FontStyles.Normal;
                    Seven.FontStyle = FontStyles.Normal;
                    Eight.FontStyle = FontStyles.Normal;
                    Nine.FontStyle = FontStyles.Normal;
                    Zero.FontStyle = FontStyles.Normal;
                    Del.FontStyle = FontStyles.Normal;
                    R.FontStyle = FontStyles.Normal;
                    Off.FontStyle = FontStyles.Normal;
                    Divide.FontStyle = FontStyles.Normal;
                    Multiply.FontStyle = FontStyles.Normal;
                    Add.FontStyle = FontStyles.Normal;
                    Substract.FontStyle = FontStyles.Normal;
                    Equals.FontStyle = FontStyles.Normal;
                    Dot.FontStyle = FontStyles.Normal;
                }
            } else // Si el que se ha pulsado es normal, negrita y cusriva se deschequean y se desformatean de los numeros
            {
                Bold.IsChecked = false;
                Italic.IsChecked = false;
                Normal.IsChecked = true;
                tb.FontWeight= FontWeights.Normal; tb.FontStyle= FontStyles.Normal;
                One.FontWeight = FontWeights.Normal; One.FontStyle = FontStyles.Normal;
                Two.FontWeight = FontWeights.Normal; Two.FontStyle = FontStyles.Normal;
                Three.FontWeight = FontWeights.Normal; Three.FontStyle = FontStyles.Normal;
                Four.FontWeight = FontWeights.Normal; Four.FontStyle = FontStyles.Normal;
                Five.FontWeight = FontWeights.Normal; Five.FontStyle = FontStyles.Normal;
                Six.FontWeight = FontWeights.Normal; Six.FontStyle = FontStyles.Normal;
                Seven.FontWeight = FontWeights.Normal; Seven.FontStyle = FontStyles.Normal;
                Eight.FontWeight = FontWeights.Normal; Eight.FontStyle = FontStyles.Normal;
                Nine.FontWeight = FontWeights.Normal; Nine.FontStyle = FontStyles.Normal;
                Zero.FontWeight = FontWeights.Normal; Zero.FontStyle = FontStyles.Normal;
                Del.FontWeight = FontWeights.Normal; Del.FontStyle = FontStyles.Normal;
                R.FontWeight = FontWeights.Normal; R.FontStyle = FontStyles.Normal;
                Off.FontWeight = FontWeights.Normal; Off.FontStyle = FontStyles.Normal;
                Divide.FontWeight = FontWeights.Normal; Divide.FontStyle = FontStyles.Normal;
                Multiply.FontWeight = FontWeights.Normal; Multiply.FontStyle = FontStyles.Normal;
                Add.FontWeight = FontWeights.Normal; Add.FontStyle = FontStyles.Normal;
                Substract.FontWeight = FontWeights.Normal; Substract.FontStyle = FontStyles.Normal;
                Equals.FontWeight = FontWeights.Normal; Equals.FontStyle = FontStyles.Normal;
                Dot.FontWeight = FontWeights.Normal; Dot.FontStyle = FontStyles.Normal;
            }
        }
    }
}
