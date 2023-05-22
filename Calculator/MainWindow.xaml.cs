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

        //Drags the whole Window from any place
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //Minimizes the Window
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Closes the Window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        string userInput = "";
        string lastUserInput;
        bool nextClickClear = false;

        //Calculator
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Turning the typ Convertion to Englisch so there are no bugs
            CultureInfo englishCulture = new CultureInfo("en-US");

            //Clearing the Error message if its displayed
            if (nextClickClear == true)
            {
                userInput = "";
                nextClickClear = false;

            }

            // Get the value of the clicked butto
            var clickedButton = sender as Button;

            // Puting the value into a string
            string buttonValue = Convert.ToString(clickedButton.Content);

            //Chcking wich button got pressed
            switch (buttonValue)
            {
                case "DL":
                    //Removeing the last char of the User input
                    if (userInput.Length >= 1) userInput = userInput.Remove(userInput.Length - 1);
                    break;
                case "AC":
                    userInput = "";
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
                    if (userInput.Length > 0 && (userInput.EndsWith("+") || userInput.EndsWith("-") || userInput.EndsWith("*") || userInput.EndsWith("/") || userInput.EndsWith("%"))) userInput = userInput.Remove(userInput.Length - 1);

                    //Saveing Last user input
                    lastUserInput = userInput;

                    try
                    {
                        //Convertin it to a Double roudning it and Conveting it to a calculation
                        userInput = Convert.ToString(Math.Round( Convert.ToDouble(new System.Data.DataTable().Compute(userInput, "")),5), englishCulture);
                        if (userInput.Length > 0) LastUseInput.Text = lastUserInput + " = " + userInput;
                    }
                    catch (Exception)
                    {
                        //If the Conversion fails it will output an Error Message
                        userInput = "ERROR";
                        nextClickClear = true;
                    }

                    break;
                default:
                    userInput = "ERROR";
                    break;

            }
            // Displaying the Text on the UI
            OutputText.Text = userInput;
        }

        //Theme Switch
        private int currentThemeIndex = 0;

        //List with all themese
        List<Uri> themes = new List<Uri>
        {
            new Uri("Themes/LightTheme.xaml", UriKind.Relative),
            new Uri("Themes/DarkTheme.xaml", UriKind.Relative),
            new Uri("Themes/BleachTheme.xaml", UriKind.Relative),
        };

        private void ButtonTheme(object sender, RoutedEventArgs e)
        {
            currentThemeIndex = (currentThemeIndex + 1) % themes.Count;
            AppTheme.ChangeTheme(themes[currentThemeIndex]);
        }

        private void Time_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}

