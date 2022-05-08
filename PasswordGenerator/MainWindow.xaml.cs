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

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Random character = new Random();
        
        int passwordLength;

        String letters = "abcdefghijklmnopqrstuvwxyzæøå";
        String numbers = "123467890";
        String symboles = "#¤%&@£$";

        private string generatePassword(int pwlength)
        {
            int length = pwlength;
            int randomNum;
            
            String password = "";

            char[] arrry =  password.ToCharArray();

            for (int i = 0; i < length; i++)
            {
              
                if (uppercase_checkBox.IsChecked == true)
                {
                    warning_label.Content = "";
                    letters = letters.ToUpper();
                    randomNum = character.Next(0, letters.Length);
                    password += letters[randomNum];

                    if(password.Length == pwlength)
                    {
                        break;
                    }
                }
                if (lowercase_checkBox.IsChecked == true)                    
                {
                    warning_label.Content = "";
                    letters = letters.ToLower();
                    randomNum = character.Next(0, letters.Length);
                    password += letters[randomNum];

                    if (password.Length == pwlength)
                    {
                        break;
                    }
                }
                if (symbols_checkBox.IsChecked == true)
                {
                    warning_label.Content = "";
                    randomNum = character.Next(0, symboles.Length);
                    password += symboles[randomNum];

                    if (password.Length == pwlength)
                    {
                        break;
                    }
                }
                if (numbers_checkBox.IsChecked == true)
                {
                    warning_label.Content = "";
                    randomNum = character.Next(0, numbers.Length);
                    password += numbers[randomNum];

                    if (password.Length == pwlength)
                    {
                        break;
                    }
                }
                else
                {
                    warning_label.Content = "ATLEAST ONE OPTIONS MUST BE CHECKED !";
                }
                
            }

            return password;
            
        }

        private string scramble (Random ran, String word)
        {
            Random random = ran;
            char[] a = word.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                int j = random.Next(a.Length);
                // Swap letters
                char temp = a[i]; a[i] = a[j]; a[j] = temp;
            }



            return new string(a);
        }

        public MainWindow()
        {
            InitializeComponent();
            passwordLength_slider.Minimum = 6;
            passwordLength_slider.Maximum = 24;
        }

        private void passwordLength_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            passwordLength_label.Content = "Password length: " + passwordLength_slider.Value.ToString();
            passwordLength = (int)passwordLength_slider.Value;

            output_label.Content = scramble(character, generatePassword(passwordLength)); ;
            
        }

        private void clipboard_button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(output_label.Content.ToString());
        }
    }
}
