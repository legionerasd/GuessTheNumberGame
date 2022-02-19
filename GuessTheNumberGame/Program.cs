using System;

namespace GuessTheNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Минимальное загаданное число.
            int minimumHiddenNumber = 0;
            // Максимальное загаданное число.
            int maximumHiddenNumber = 100;
            // Колличество попыток.
            int numberOfAttempts = 5;
            
            int secretNumber = new Random().Next(minimumHiddenNumber, maximumHiddenNumber);

            Console.WriteLine("Добро пожаловать в игру 'Угадай число'");
            Console.Write("Как вас зовут?: ");
            string? userName = Console.ReadLine();
            Console.WriteLine(
                $"Привет {userName}. " +
                $"Я загадал тебе число от {minimumHiddenNumber} до {maximumHiddenNumber}. " +
                $"Попробуй отгадать!");

            while (true)
            {
                bool isIntNumber = false;
                
                if (numberOfAttempts <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Вы проиграли исчерпав все попытки. Попробуйте испытать удачу снова.");
                    break;
                }
                
                Console.WriteLine("Для выхода из игры наберите \"Выход\"");
                Console.Write($"Введи число от {minimumHiddenNumber} до {maximumHiddenNumber}. У тебя {numberOfAttempts} попыток: ");
                string? userInput = Console.ReadLine().ToLower();
                    
                    
                isIntNumber = int.TryParse(userInput, out int userNumber);
                
                if (userInput == "выход")
                {
                    Console.Clear();
                    Console.WriteLine("Вы вышли из игры!");
                    Environment.Exit(0);
                }
                
                if (!isIntNumber)
                {
                    Console.WriteLine("#### Ошибка ввода! ####");
                    Console.WriteLine($"Вы ввели недопустимое значение ({userInput}). Нужно ввести число от {minimumHiddenNumber} до {maximumHiddenNumber}");
                    Console.WriteLine("#######################");
                    continue;
                }
                else if (userNumber <= 0 || userNumber > 100)
                {
                    Console.WriteLine("#### Ошибка ввода! ####");
                    Console.WriteLine($"Нужно ввести число от в правильном диапозоне от {minimumHiddenNumber} до {maximumHiddenNumber}");
                    Console.WriteLine("#######################");
                    continue;
                }
                


                if (userNumber > secretNumber)
                {
                    Console.WriteLine($"Ваше число ({userNumber}) больше, чем загаданное.");
                    --numberOfAttempts;
                }
                else if (userNumber < secretNumber)
                {
                    Console.WriteLine($"Ваше число ({userNumber}) меньше, чем загаданное.");
                    --numberOfAttempts;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы победили!");
                    break;
                }
            }
        }
    }
}