using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly List<string> Tags = new List<string>
        {
          "корни",
          "днд",
          "киберпанк",
          "зов ктулху",
          "5 редакция",
          "малкавиане",
          "правила"
        };

        public MainWindow()
        {
            InitializeComponent();
            webbrowser1.Address = "https://drive.google.com/file/d/1WW0wrTkOW63l2t16m9pMxvKGlWwoRxle/view?usp=sharing";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listbox1.Items.Clear();


            foreach (string tag in Tags)
            {
                if (textbox1.Text.Trim() != "")
                {
                    string regexPattern = (textbox1.Text.ToString()) + "\\w*";
                    regexPattern = regexPattern.ToLower();

                    Match match = Regex.Match(tag, regexPattern);
                    while (match.Success && match.Value != "")
                    {
                        listbox1.Items.Add(tag);
                        listbox1.Visibility = Visibility.Visible;

                        match = match.NextMatch();
                    }
                }
            }

            if (listbox1.Items.IsEmpty || listbox1.Items.Count == 119)
            {
                listbox1.Visibility = Visibility.Collapsed;
                if (listbox1.Items.Count == 7) listbox1.Items.Clear();
            }
            if (textbox1.Text == "5 редакция")
            {
                radiobutton1.IsChecked = true;
                radiobutton1.Visibility = Visibility.Visible;
                textbox1.Text = "";
            }
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //listbox1.Items.Cast<String>().ToList()
              //.ForEach(x => textbox1.Text = x + " ");
              if (listbox1.SelectedItem != null)
            {
                string x = listbox1.SelectedItem.ToString().Trim();
                textbox1.Text = x;
            }
        }
    }
}
