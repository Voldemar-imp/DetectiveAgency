using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DetectiveAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DetectiveAgency detectiveAgency = new DetectiveAgency();

            detectiveAgency.Work();
        }
    }

    class DetectiveAgency
    {
        private FileCabinet _fileCabinet = new FileCabinet();
        private const string _commandExit = "exit";

        public void Work()
        {
            bool isContinue = true;

            while (isContinue)
            {
                Console.Clear();
                Console.WriteLine("Введите национальность:");
                string nationality = Console.ReadLine();
                Console.WriteLine("Введите рост:");
                int height = UserUtils.GetNumber(); 
                Console.WriteLine("Введите вес:");
                int weight = UserUtils.GetNumber();
                _fileCabinet.ShowFilteredCriminal(nationality, height, weight);

                Console.WriteLine($"Хотите продолжить? Введите {_commandExit} чтобы выйти");
                string userCommand = Console.ReadLine();
                if (userCommand == _commandExit)
                {
                isContinue = false;
                }
            }
        }

    }

    static class UserUtils
    {
        public static int GetNumber()
        {
            int number = 0;
            bool success = false;

            while (success == false)
            {               
                string userInput = Console.ReadLine();
                success = int.TryParse(userInput, out number);
                if (success == false)
                {
                    Console.WriteLine("Введенное значение не является числом");
                }               
            }

            return number;
        }
    }

    class FileCabinet
    {
        private List<Criminal>_criminals = new List<Criminal>();

        public FileCabinet()
        {
            _criminals.Add(new Criminal("Еремин Дмитрий Ярославович", "Русский", 170, 80, false));
            _criminals.Add(new Criminal("Болдырев Ярослав Андреевич", "Белорус", 170, 80, false));
            _criminals.Add(new Criminal("Калинин Мирон Алексеевич", "Украинец", 175, 90, false));
            _criminals.Add(new Criminal("Муравьев Всеволод Даниилович", "Русский", 170, 80, false));
            _criminals.Add(new Criminal("Золотарев Вадим Иванович", "Белорус", 175, 90, true));
            _criminals.Add(new Criminal("Поляков Даниил Михайлович", "Русский", 170, 70, false));
            _criminals.Add(new Criminal("Андреев Роман Егорович", "Русский", 170, 86, true));
            _criminals.Add(new Criminal("Петров Никита Лукич", "Белорус", 170, 80, false));
            _criminals.Add(new Criminal("Русанов Андрей Иванович", "Украинец", 175, 90, true));
            _criminals.Add(new Criminal("Галкин Егор Робертович", "Русский", 170, 70, false));
            _criminals.Add(new Criminal("Васильев Алексей Артёмович", "Русский", 170, 86, true));
            _criminals.Add(new Criminal("Носов Михаил Артемьевич", "Русский", 170, 80, false));
        }

        public void ShowFilteredCriminal(string nationality, int height, int weight)
        {
            var filteredCriminals = _criminals.Where(criminal => criminal.Nationality == nationality && criminal.Height == height && criminal.Weight == weight && criminal.IsInJail == false);

            if (filteredCriminals.Any() == false)
            {
                Console.WriteLine("По вашему запросу нет данных");
            }

            foreach (var filteredCriminal in filteredCriminals)
            {
            Console.WriteLine(filteredCriminal.Name); 
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string Nationality { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public bool IsInJail { get; private set; }

        public Criminal(string name, string nationality, int height, int weight, bool isInJail)
        {
            Name = name;
            Nationality = nationality;
            Height = height;
            Weight = weight;
            IsInJail = isInJail;
        }

    }
}
