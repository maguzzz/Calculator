using System;
using System.Collections.Generic;
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

namespace Calculator
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
        //This is a commend

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        string userInput;
        string lastUserInput;

        //Calculator
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the value of the clicked butto
            var clickedButton = sender as Button;

            // Puting the value into a string
            string buttonValue = Convert.ToString(clickedButton.Content);

            //Chcking wich button got pressed
            switch (buttonValue)
            {
                case "del":
                    userInput.Remove(userInput.Length - 1);
                    break;
                case "%":
                    userInput += "%";
                    break;
                case "/":
                    userInput += "/";
                    break;
                case "7":
                    userInput += "7";
                    break;
                case "8":
                    userInput += "8";
                    break;
                case "9":
                    userInput += "9";
                    break;
                case "*":
                    userInput += "*";
                    break;
                case "4":
                    userInput += "4";
                    break;
                case "5":
                    userInput += "5";
                    break;
                case "6":
                    userInput += "6";
                    break;
                case "-":
                    userInput += "-";
                    break;
                case "1":
                    userInput += "1";
                    break;
                case "2":
                    userInput += "2";
                    break;
                case "3":
                    userInput += "3";
                    break;
                case "+":
                    userInput += "+";
                    break;
                case "?":
                    userInput += "?";
                    break;
                case "0":
                    userInput += "0";
                    break;
                case ".":
                    userInput += ".";
                    break;
                case "=":

                    //Adding a plus after the last value so it can be a  calculation
                    if (userInput.EndsWith("+") || userInput.EndsWith("-") || userInput.EndsWith("*") || userInput.EndsWith("/") || userInput.EndsWith("%")) userInput = userInput.Remove(userInput.Length - 1);

                    //Convertin it to a calculation
                    userInput = Convert.ToString(new System.Data.DataTable().Compute(userInput, ""));
                    break;

                default:
                    userInput = "ERROR";
                    break;

            }
            // Displaying the Text on the UI
            OutputText.Text = userInput;
        }
    }
}

