namespace FilmApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем словарь для хранения фильмов и информации о том, смотрел ли человек фильм (0 - Нет, 1 - Да).
            var films = new Dictionary<string, int>();

            while (true)
            {
                // Запрашиваем у пользователя ввод названия фильма.
                Console.WriteLine("Введите имя фильма для добавления, удаления или поиска (или введите 'q' для выхода):");
                string userInput = Console.ReadLine();

                // Проверка на пустой ввод.
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите имя фильма.");
                    continue;
                }

                // Проверка на выход из программы.
                if (userInput.ToLower() == "q")
                {
                    break;
                }

                string filmTitle = userInput.Trim();

                // Проверяем, начинается ли ввод с "delete ".
                if (filmTitle.ToLower().StartsWith("delete "))
                {
                    // Если начинается, вызываем функцию для удаления фильма из словаря.
                    DeleteMovie(films, filmTitle);
                }
                else
                {
                    // Если фильм уже существует в словаре, выводим информацию о нем.
                    // Иначе, добавляем новый фильм в словарь с рандомным значением 0 или 1 (Нет или Да).
                    Random random = new Random();
                    int randomNumber = random.Next(0, 2); // Генерация случайного числа 0 или 1

                    // Проверка на null перед обращением к словарю.
                    if (films.ContainsKey(filmTitle))
                    {
                        Console.WriteLine($"Фильм '{filmTitle}' уже существует. Смотрел: {(films[filmTitle] == 1 ? "Да" : "Нет")}");
                    }
                    else
                    {
                        films.Add(filmTitle, randomNumber);
                        Console.WriteLine($"Фильм '{filmTitle}' добавлен. Смотрел: {(randomNumber == 1 ? "Да" : "Нет")}");
                    }
                }
            }

            // Выводим список фильмов и информацию о том, смотрел ли человек каждый фильм.
            Console.WriteLine("\nСписок фильмов:");
            foreach (var film in films)
            {
                Console.WriteLine($"{film.Key} - Смотрел: {(film.Value == 1 ? "Да" : "Нет")}");
            }
        }

        // Функция для удаления фильма из словаря.
        static void DeleteMovie(Dictionary<string, int> films, string filmTitle)
        {
            string movieToDelete = filmTitle.Substring(7).Trim();

            // Проверка на null перед удалением из словаря.
            if (films.ContainsKey(movieToDelete))
            {
                films.Remove(movieToDelete);
                Console.WriteLine($"Фильм '{movieToDelete}' удален.");
            }
            else
            {
                Console.WriteLine($"Фильма '{movieToDelete}' не существует.");
            }
        }
    }
}