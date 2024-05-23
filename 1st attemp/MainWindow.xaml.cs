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
using System.Globalization;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Threading;


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
                    "корневой тег1", 
                    "корневой тег2", 
                    "корневой", 
                    "к",
                    "корневой то и от и э", 
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
            { "зов ктулху", new List<string>
                {
                    "быстрый-старт",
                    "зов-ктулху",
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
            { "mouse guard", new List<string>
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
            listbox1.Items.Clear();

            var completions = GetCompletions(textBox1.Text);
            completions.ForEach(completion => listbox1.Items.Add(completion));
            listbox1.Visibility = completions.Any() ? Visibility.Visible : Visibility.Collapsed;
        }

        private List<string> GetCompletions(string input)
        {
            // Разбиваем сырой инпут на слова
            input = input.Trim().ToLower();
            var split = input.Split(' ');
            if (!split.Any() || string.IsNullOrEmpty(split[0].Trim())) return new List<string>();
            
            // Пытаемся найти среди слов инпута название игры
            var index = 0;
            var gameName = split[0];
            while (!tabletopDatas.ContainsKey(gameName) && index < split.Length-1)
            {
                index++;
                gameName += $" {split[index]}";
            }
            
            if (!tabletopDatas.ContainsKey(gameName))
            {
                // Название игры не дописано, значит пока работаем только с ключами
                return tabletopDatas.Keys.Where(key => key.Trim().ToLower().StartsWith(input)).ToList();
            }

            // Получаем список слов без тех слов, которые являются частью названия игры
            var tags = new List<string>();
            for (int i = index + 1; i < split.Length; i++)
            {
                tags.Add(split[i]);
            }

            var completions = new List<string>();
            var cursor = "";
            
            for (int i = tags.Count - 1; i >= 0; i--)
            {
                cursor = $"{tags[i]} {cursor}".Trim();
                completions.AddRange(tabletopDatas[gameName].Where(tag =>
                {
                    var temp = tag.Trim().ToLower();
                    return temp != cursor && temp.StartsWith(cursor);
                }));
            }
            
            return completions;
        }
        
        private void listbox1_selectionchanged(object sender, RoutedEventArgs e)
        {
            if (listbox1.SelectedItem == null) return;

            var selected = listbox1.SelectedItem.ToString().Split(' ').ToList();
            var input = textBox1.Text.ToLower().Split(' ').ToList();


            int index = input.Count;
            for (int i = input.Count - 1; i >= 0; i--)
            {
                if (selected[0].StartsWith(input[i].ToLower()))
                {
                    index = i;
                    break;
                }
            }

            while (input.Count > index) input.RemoveAt(input.Count-1);
            input.AddRange(selected);

            textBox1.Text = string.Join(" ", input);

            //int index = -1;
            //int min = Math.Min(selected.Count, input.Count);
            //for (int i = 0; i < min; i++)
            //{
            //    if (selected[i] != input[i]) break;
            //    index++;
            //}

            //// Все слова после index не присутствуют в input
            //var completionWords = new List<string>();
            //for (int i = index + 1; i < selected.Count; i++)
            //{
            //    completionWords.Add(selected[i]);
            //}

            //Console.WriteLine(string.Join(", ", completionWords));

            //// Удаляем недописанное слово и вставляем вместо него выбранное 
            //var index = textBox1.Text.LastIndexOf(' ') + 1;
            //textBox1.Text = textBox1.Text.Remove(index);

            //textBox1.Text += selected;
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
