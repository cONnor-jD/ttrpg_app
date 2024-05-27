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
using System.Diagnostics;


namespace _1st_attemp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly List<TabletopData> tabletopDataList = new List<TabletopData>
        {
            new TabletopData(new List<string>
            {
                "корни",
                "roots"
            }, new List<string>
            {
                "корневой тег1", 
                "корневой тег2", 
                "корневой", 
                "к",
                "корневой то и от и э", 
            }),            
            new TabletopData(new List<string>
            {
                "зов ктулху",
                "call of cthulhu"
            }, new List<string>
            {
                "быстрый старт",
                "рулбук",
                "книга правил",
                "что необходимо",
                "ход игры",
                "игровой процесс",
                "геймплей",
                "боевая система",
                "идол тота",
                "приключение",
                "сценарий",
                "безымянный туман",
                "леденящий ужас",
                "лютня ламфеля",
                "недетские игры",
                "санаториум",
                "ужас на халдон хилл",
                "шоу",
                "эликсир жизни",
            }),            
            new TabletopData(new List<string>
            {
                "барокко",
                "hexxen",
                "18 век"
            }, new List<string>
            {
                "рулбук",
                "мир",
                "история",
                "создание персонажа",
                "классы",
                "правила",
                "боевая система",
                "снаряжение",
                "для мастера",
            }),
            new TabletopData(new List<string>
            {
                "кибер панк ред",
                "cyberpunk red"
            }, new List<string>
            {
                "быстрый старт",
                "стартовый набор",
                "для начинающих",
                "мир",
                "история мира",
                "найт-сити",
                "история найт-сити",
                "город",
                "предыстория",
                "введение",
                "создание персонажа",
                "роли",
                "предыстория персонажа",
                "создание предыстории",
                "навыки",
                "распределение навыков",
                "характеристики",
                "ролевой отыгрыш",
                "ролевая система",
                "проверки навыков",
                "действия",
                "хакерство",
                "бой в сети",
                "сеть",
                "жизнь",
                "повседневная жизнь",
                "для мастера",
                "как вести игру",
            }),
            new TabletopData(new List<string>
            {
                "дегенесис",
                "degenesis"
            }, new List<string>
            {
                "анабаптисты",
                "балханы",
                "борка",
                "перерождение",
                "поллен",
                "спитальеры",
                "франка",
                "хронисты",
            }),
            new TabletopData(new List<string>
            {
                "сыщик"
            }, new List<string>
            {
                "введение",
                "основы",
                "создание персонажа",
                "правила",
                "сражения",
                "боевая система",
                "для мастера",
                "шпаргалка",
                "кратко",
            }),
            new TabletopData(new List<string>
            {
                "чужой"
            }, new List<string>
            {
                "правила",
                "история мира",
                "как играть",
                "виды компаний",
                "инструменты",
                "создание персонажа",
                "характеристики",
                "классы",
                "навыки",
                "проверки навыков",
                "боевая система",
                "снаряжение",
                "ксеноморфы",
                "кампании",
            }),
            new TabletopData(new List<string>
            {
                "dark souls",
                "дарк соулс"
            }, new List<string>
            {
                "комикс",
                "для новичков",
                "книга правил",
                "создание персонажа",
                "роли",
                "характеристики",
                "правила игры",
                "боевая механика",
                "для мастера",
                "карты",
            }),
            new TabletopData(new List<string>
            {
                "звездные войны",
                "dnd star wars"
            }, new List<string>
            {
                "создание персонажа",
                "пердыстория",
                "классы",
                "раса",
                "социальное взаимодействие",
                "приключение",
                "сражения",
                "боевая система",
                "космические бои",
                "приключение",
                "сценарий",
                "безымянный туман",
                "леденящий ужас",
                "лютня ламфеля",
                "недетские игры",
                "санаториум",
                "ужас на халдон хилл",
                "шоу",
                "эликсир жизни",
            }),
            new TabletopData(new List<string>
            {
                "лес фей",
                "fairyforest",
                "для детей"
            }, new List<string>
            {
                "правила",
                "приключения",
            }),
            new TabletopData(new List<string>
            {
                "fallout ds"
            }, new List<string>
            {
                "правила",
                "создание персонажа",
                "навыки",
                "характеристики",
                "экипировка",
                "снаряжение",
                "оружие",
                "боевая система",
                "действия",
            }),
            new TabletopData(new List<string>
            {
                "fallout бумага и карандаш"
            }, new List<string>
            {
                "правила",
            }),
            new TabletopData(new List<string>
            {
                "gurps",
                "гурпс"
            }, new List<string>
            {
                "правила",
                "создание персонажа",
                "навыки",
                "умения",
                "шаблон персонажа",
                "снаряжение",
                "характеристики",
                "развитие",
                "магия",
                "ультратех",
                "технологии",
                "робин гуд",
                "кампания",
                "пираты",
                "греция",
                "египет",
                "рим",
                "ледниковый период",
            }),
            new TabletopData(new List<string>
            {
                "mork borg"
            }, new List<string>
            {
                "книга правил",
                "карта",
                "создание персонажа",
                "снаряжение",
                "умения",
                "кампания",
                "склеп неверных",
                "процессия святой триллы",
                "дороги к погибели",
                "в поисках убийственного меча",
                "потерянный наследник короля",
                "гнилой черный ил",
                "классы",
            }),
            new TabletopData(new List<string>
            {
                "мышиная стража",
                "mouse guard"
            }, new List<string>
            {
                "книга правил",
                "навыки",
                "способности",
                "развитие",
                "правила игры",
                "история мира",
                "шаблоны персонажей",
                "как играть",
                "игровые механики",
                "ход игры",
                "мир",
                "обитатели мира",
                "карта",
                "комикс",
            }),
            new TabletopData(new List<string>
            {
                "pathfinder"
            }, new List<string>
            {
                "создание персонажа",
                "классы",
                "навыки",
                "характеристики",
                "правила игры",
                "развитие персонажа",
                "снаряжение",
                "экипировка",
                "магия",
                "заклинания",
                "для мастера",
                "как вести игру",
                "основная книга",
                "книга правил",
                "состояния",
            }),
            new TabletopData(new List<string>
            {
                "blades in the dark",
                "клинки во тьме"
            }, new List<string>
            {
                "основные правила",
                "игровой мир",
                "навыки",
                "характеристики",
                "проверки",
                "развитие персонажа",
                "последствия",
                "дело",
                "магия",
                "действие",
                "для мастера",
                "как вести игру",
                "основная книга",
                "карта мира",
                "команда",
                "создание комнды",
                "ролевой отыгрыш",
                "социальное взаимодействие",
                "как играть",
                "правила",
                "мистика",
                "призраки",
                "город",
                "дасквол",
                "окрестности",
            }),

        };
        //private static readonly Dictionary<string, List<string>> tabletopDatas = new Dictionary<string, List<string>>
        //{
        //    { "корни", new List<string> 
        //        { 
        //            "корневой тег1", 
        //            "корневой тег2", 
        //            "корневой", 
        //            "к",
        //            "корневой то и от и э", 
        //        } 
        //    },
        //    { "мышиная стража", new List<string>
        //        {
        //            "мышиная-стража-тег1",
        //            "мышиная-стража-тег2",
        //        }
        //    },
        //    { "днд", new List<string>
        //        {
        //            "днд-тег1",
        //            "днд-тег2",
        //        }
        //    },
        //    { "зов ктулху", new List<string>
        //        {
        //            "быстрый-старт",
        //            "зов-ктулху",
        //            "рулбук",
        //            "книга-правил",
        //            "что-необходимо",
        //            "боевка",
        //            "ход-игры",
        //            "игровой-процесс",
        //            "геймплей",
        //            "боевая-система",
        //            "идол-тота",
        //            "приключение",
        //            "сценарий",
        //            "безымянный-туман",
        //            "леденящий-ужас",
        //            "лютня-ламфеля",
        //            "недетские-игры",
        //            "санаториум",
        //            "ужас-на-халдон-хилл",
        //            "шоу",
        //            "эликсир-жизни",
        //        }
        //    },
        //    { "mouse guard", new List<string>
        //        {
        //            "mouse-guard-тег1",
        //            "mouse-guard-тег2",
        //        }
        //    },
        //};

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

        private bool IsTabletopExists(string name)
        {
            return tabletopDataList.Any(data => data.Names.Contains(name));
        }

        private IEnumerable<string> GetAllTabletopNames()
        {
            return tabletopDataList.SelectMany(tabletopData => tabletopData.Names);
        }

        private List<string> GetTags(string name)
        {
            return tabletopDataList.Find(data => data.Names.Contains(name))?.Tags;
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
            while (!IsTabletopExists(gameName) && index < split.Length-1)
            {
                index++;
                gameName += $" {split[index]}";
            }
            
            if (!IsTabletopExists(gameName))
            {
                // Название игры не дописано, значит пока работаем только с ключами
                return GetAllTabletopNames().Where(key => key.Trim().ToLower().StartsWith(input)).ToList();
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
                completions.AddRange(GetTags(gameName).Where(tag =>
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
            var input = textBox1.Text.Trim().ToLower().Split(' ').ToList();
            
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
        }

        private void GurpsBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://drive.google.com/file/d/1-ecQ7Grm8vQF6HvtJ8soGDVu2WexdHgM/view?usp=sharing") { UseShellExecute = true });
        }

        private void MouseguardBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://drive.google.com/file/d/1S3sVUpCg3WJYyPkmIiRhPI9DoOTiBPjK/view?usp=sharing") { UseShellExecute = true });
        }

        private void PathfinderBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://drive.google.com/file/d/1hhV4PXj5kg9Okbqc_PnrYQ3AmgSurW6f/view?usp=sharing") { UseShellExecute = true });
        }

        private void CyberpunkredBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://drive.google.com/file/d/1aB766JFYx3KbY4hWTCU4wLbYoKocJMyd/view?usp=sharing") { UseShellExecute = true });
        }

        private void CallofCthulhuBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://drive.google.com/file/d/16wAV1KtcA4PKprBmeGhmIq_9fzaPRRIb/view?usp=sharing") { UseShellExecute = true });
        }

        private void DndBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://drive.google.com/file/d/1UULqSV5-67MP3sJbLI_PKI0eQmHxiopG/view?usp=sharing") { UseShellExecute = true });
        }

        private void VtmBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://drive.google.com/file/d/1F7btMkxCKoa6nbqdafyvidafHVq0pKbK/view?usp=sharing") { UseShellExecute = true });
        }

        private void ShadowrunBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://drive.google.com/file/d/1PoCve_Gsx9RGegnyZCTA7Q1nof3jPEMg/view?usp=sharing") { UseShellExecute = true });
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
