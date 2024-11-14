using System;
using System.IO;

namespace Task2
{
    class Program
    {
        // Определяем событие
        public delegate void SortEventHandler(List<string> surnames);
        public static event SortEventHandler OnSort;

        static void Main(string[] args)
        {
            List<string> surnames = new List<string>
        {
            "Иванов",
            "Петров",
            "Сидоров",
            "Кузнецов",
            "Смирнов"
        };

            OnSort += SortByAlphabet; // Подписка на событие

            while (true)
            {
                Console.WriteLine("Введите 1 для сортировки А-Я или 2 для сортировки Я-А:");
                string input = Console.ReadLine();
                try
                {
                    if (input == "1")
                    {
                        OnSort?.Invoke(surnames);
                        Console.WriteLine("Сортировка А-Я:");
                    }
                    else if (input == "2")
                    {
                        surnames.Sort((x, y) => y.CompareTo(x)); // Сортируем Я-А
                        Console.WriteLine("Сортировка Я-А:");
                    }
                    else
                    {
                        throw new InvalidInputException("Недопустимый ввод. Пожалуйста, введите 1 или 2.");
                    }

                    // Выводим отсортированный список
                    foreach (var surname in surnames)
                    {
                        Console.WriteLine(surname);
                    }
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear(); // Очищаем консоль перед следующим вводом
                }
            }
        }

        // Метод для сортировки А-Я
        private static void SortByAlphabet(List<string> surnames)
        {
            surnames.Sort(); // Сортируем по алфавиту
        }
    }

    // Пользовательское исключение
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}