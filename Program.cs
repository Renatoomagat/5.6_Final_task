namespace _5._6_Итоговая_работа
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte petNumb = 0;
            byte colorNumb = 0;
            ReturnCort(ref petNumb, ref colorNumb);
            ShowUserData(GetUserData);
        }

        static (string Name, string LastName, int Age, bool HasPet, string[] pets, string[] favColors) GetUserData;
        
        static void ReturnCort(ref byte petNumb, ref byte colorNumb)
        {
            Console.WriteLine("Введите имя");
            GetUserData.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            GetUserData.LastName = Console.ReadLine();

            GetUserData.Age = CheckNumber("Введите возраст", 150);
            Console.WriteLine("Домашние животные? Да/Нет");
            var result = Console.ReadLine();
            while (result != "Да" && result != "Нет")
            {
                Console.WriteLine("Нужно ответить Да или Нет");
                result = Console.ReadLine();
            }
            if (result == "Да")
            {
                GetUserData.HasPet = true;
                petNumb = CheckNumber("Сколько у Вас животных?", 100);
                while (petNumb == 0) 
                {
                    Console.WriteLine("Число должно быть больше 0");
                    petNumb = CheckNumber("Сколько у Вас животных?", 100);
                }
                GetUserData.pets = NumbOfPets(ref petNumb);
            }
            else
            {
                GetUserData.HasPet = false;
            }
            colorNumb = CheckNumber("Напишите количество любимых цветов", 10);
            GetUserData.favColors = NumbOfColors(ref colorNumb);
                    }
        static string[] NumbOfColors (ref byte colorNumb)
        {
            string[] color = new string[colorNumb];
            Console.WriteLine("Напишите названия цветов");
            for (int n = 0; n < colorNumb; n++)
            {
                color[n] = Console.ReadLine();
            }
            return color;
        }
        static string[] NumbOfPets(ref byte petNumb)
        {
            string[] petName = new string[petNumb];
            Console.WriteLine("Напишите имена любимцев");
            for (int i = 0; i < petNumb; i++)
            {
                petName[i] = Console.ReadLine();
            }
            return petName;
        }
        static byte CheckNumber(string message, byte maxValue)
        {
            byte result;
            bool allowedValue;
            do
            {
                Console.WriteLine(message);
                allowedValue = byte.TryParse(Console.ReadLine(), out result) && result <= maxValue;
                if (!allowedValue)
                {
                    Console.WriteLine($"Введите число от 0 до {allowedValue}.");
                }
            }
            while (!allowedValue);
            return result;
        }
        static void ShowUserData((string Name, string LastName, int Age, bool HasPet, string[] pets, string[] favColors) GetUserData)
        {
            Console.WriteLine($"Имя: {GetUserData.Name}");
            Console.WriteLine($"Фамилия: {GetUserData.LastName}");
            Console.WriteLine($"Возраст: {GetUserData.Age}");
            if (GetUserData.HasPet)
            {
                Console.WriteLine($"Количество домашних животных: {GetUserData.pets.Length}");
                Console.WriteLine($"Имена животных:");
                foreach (string pet in GetUserData.pets)
                {
                    Console.WriteLine(pet);
                }
            }
            else
            {
                Console.WriteLine("Домашних животных нет");
            }
            Console.WriteLine($"Количество любимых цветов: {GetUserData.favColors.Length}");
            Console.WriteLine("Любимые цвета:");
            foreach (string col in GetUserData.favColors)
            {
                Console.WriteLine(col);
            }
        }
        
    }
}