using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HandleOperator(e);
        }
        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            string ClalcName = "Rechner";
            meintext.Text = ClalcName;
            result.Text = "Ergebnis";
            numb1.Text = "";
            numb2.Text = "";

        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) 
            {
                HandleEnter(e);
            }
            else if (e.Key == Key.Escape) 
            {
                Button_Clear(sender, e);
            }
            else if (e.Key == Key.Add || e.Key == Key.Subtract || e.Key == Key.Multiply || e.Key == Key.Divide) 
            {
                HandleOperator(e);
            }
        }
        private void HandleEnter(KeyEventArgs e)
        {
            if (numb1.Text.Length == 0)
            {
                numb1.Focus();
            }
            else if (numb2.Text.Length == 0)
            {
                numb2.Focus();
            }
            else if (numb1.Text.Length > 0 && numb2.Text.Length > 0)
            {
                HandleOperator(e);
            }
        }
        private void HandleOperator(KeyEventArgs e)
        {
            int number1;
            int number2;
            if (int.TryParse(numb1.Text, out number1) && int.TryParse(numb2.Text, out number2))
            {
                if (operatorBox.SelectedItem == null)
                {   
                    meintext.Text = "Bitte einen Operator auswählen";
                    return;
                }
                ComboBoxItem selectedItem = (ComboBoxItem)operatorBox.SelectedItem;
                string op = selectedItem.Content.ToString();

                int ergebnis = 0;

                if (e.Key == Key.Add || op == "+")
                {
                    ergebnis = number1 + number2 ;
                }
                else if (e.Key == Key.Subtract || op == "-")
                {
                    ergebnis = number1 - number2;
                }
                else if (e.Key == Key.Multiply || op == "*")
                {
                    ergebnis = number1 * number2;
                }
                else if (e.Key == Key.Divide || op == "/")
                {
                    ergebnis = number1 / number2;
                }
                result.Text = ergebnis.ToString();
            }
        }

    }
}