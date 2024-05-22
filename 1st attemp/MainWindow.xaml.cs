using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
using System.Data;
using System.Xml.Linq;
using System.Text.RegularExpressions;



namespace _1st_attemp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private static readonly List<string> Tags = new List<string>
        //{
        //  "корни",
        //  "днд",
        //  "киберпанк",
        //  "зов-ктулху",
        //  "5-редакция",
        //  "малкавиане",
        //  "правила"
        //};
        private static readonly Dictionary<string, List<string>> tabletopDatas = new Dictionary<string, List<string>>
        {
            { "корни", new List<string> 
                { 
                    "корневой-тег1", 
                    "корневой-тег2", 
                } 
            },
            { "мышиная стража", new List<string>
                {
                    "мышиная-стража-тег1",
                    "мышиная-стража-тег2",
                }
            },
            { "днд", new List<string>
                {
                    "днд-тег1",
                    "днд-тег2",
                }
            },
            { "зов-ктулху", new List<string>
                {
                    "быстрый-старт",
                    "зов-ктулху",
                    "рулбук",
                    "рулбук",
                    "книга-правил",
                    "что-необходимо",
                    "боевка",
                    "ход-игры",
                    "игровой-процесс",
                    "геймплей",
                    "боевая-система",
                    "идол-тота",
                    "приключение",
                    "сценарий",
                    "безымянный-туман",
                    "леденящий-ужас",
                    "лютня-ламфеля",
                    "недетские-игры",
                    "санаториум",
                    "ужас-на-халдон-хилл",
                    "шоу",
                    "эликсир-жизни",
                }
            },
            { "mouse-guard", new List<string>
                {
                    "mouse-guard-тег1",
                    "mouse-guard-тег2",
                }
            },
        };

        public MainWindow()
        {
            InitializeComponent();
            //textBox1.GotFocus += textBox1_GotFocus;
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        // Событие смены инпута
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Чистим список предложений
            listbox1.Items.Clear();
            listbox1.Visibility = Visibility.Collapsed;

            // Разбиваем сырой инпут на слова и работаем с последним из них
            var words = textBox1.Text.Split(' ');
            if (!words.Any()) return;

            // Работаем с словом только если оно не пустое
            var lastWord = words.Last().ToLower();
            if (lastWord.Trim() == "") return;

            var firstWord = words[0];
            var isFirstWord = words.Count() == 1;

            // Если последнее слово является первым, то значит нам нужны предложения названий настолок
            var tags = tabletopDatas.Keys.ToList();
            if (!isFirstWord)
            {
                // В противном случае - пытаемся получить теги для выбранной настолки
                if (!tabletopDatas.TryGetValue(firstWord, out var tabletopTags)) return;
                tags = tabletopTags;
            }

            // Добавляем в список предложений те теги, которые начинаются также как и последнее слово
            foreach (var tag in tags.Where(tag => tag.ToLower().StartsWith(lastWord)))
            {
                listbox1.Items.Add(tag);
            }
            
            // Если список был чем-то заполнен - показываем его
            listbox1.Visibility = !listbox1.Items.IsEmpty ? Visibility.Visible : Visibility.Collapsed;
        }

        private void listbox1_selectionchanged(object sender, RoutedEventArgs e)
        {
            if (listbox1.SelectedItem == null) return;

            // Кешируем выбранное завершение            
            var selected = listbox1.SelectedItem.ToString();

            // Удаляем недописанное слово и вставляем вместо него выбранное 
            var index = textBox1.Text.LastIndexOf(' ') + 1;
            textBox1.Text = textBox1.Text.Remove(index);

            textBox1.Text += selected;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            webbrowser1.Navigate("https://drive.google.com/file/d/1-ecQ7Grm8vQF6HvtJ8soGDVu2WexdHgM/view?usp=sharing");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            webbrowser1.Navigate("https://drive.google.com/file/d/1S3sVUpCg3WJYyPkmIiRhPI9DoOTiBPjK/view?usp=sharing");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            webbrowser1.Navigate("https://drive.google.com/file/d/1hhV4PXj5kg9Okbqc_PnrYQ3AmgSurW6f/view?usp=sharing");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            webbrowser1.Navigate("https://drive.google.com/file/d/1aB766JFYx3KbY4hWTCU4wLbYoKocJMyd/view?usp=sharing");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            webbrowser1.Navigate("https://www.youtube.com/watch?v=ghjFoqXMUkc");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            webbrowser1.Navigate("https://www.cyberforum.ru/windows-forms/thread1755362.html?ysclid=lvsit8l8qx666467821");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            webbrowser1.Navigate("https://drive.google.com/file/d/1F7btMkxCKoa6nbqdafyvidafHVq0pKbK/view?usp=sharing");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            webbrowser1.Navigate("https://drive.google.com/file/d/1PoCve_Gsx9RGegnyZCTA7Q1nof3jPEMg/view?usp=sharing");
        }
    }
}
