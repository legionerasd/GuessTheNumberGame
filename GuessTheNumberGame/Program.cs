using System;

namespace GuessTheNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int minimumHiddenNumber = 1;
            int maximumHiddenNumber = 50;
            int numberOfAttempts = 5;
            int secretNumber = new Random().Next(minimumHiddenNumber, maximumHiddenNumber);
            bool isWin = false;
            
            Console.WriteLine("Добро пожаловать в игру 'Угадай число'");
            Console.Write("Как вас зовут?: ");
            string? userName = Console.ReadLine();
            Console.WriteLine(
                $"Привет {userName}. " +
                $"Я загадал тебе число от {minimumHiddenNumber} до {maximumHiddenNumber}. " +
                $"Попробуй отгадать!");

            Console.WriteLine(secretNumber);
            
            while (!isWin)
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
                
                
                if (!isIntNumber)
                {
                    Console.WriteLine("#### Ошибка ввода! ####");
                    Console.WriteLine($"Вы ввели недопустимое значение ({userInput}). Нужно ввести число от {minimumHiddenNumber} до {maximumHiddenNumber}");
                    Console.WriteLine("#######################");
                }
                
                
                if (userInput == "выход")
                {
                    Console.Clear();
                    Console.WriteLine("Вы вышли из игры!");
                    Environment.Exit(0);
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

                Console.WriteLine("Попробовать ещё?");
            }
        }
    }
}