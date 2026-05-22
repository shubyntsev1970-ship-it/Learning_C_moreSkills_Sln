using System.Text;

namespace Lessons
{
    internal static partial class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // Изменяем кодировку консоли

            // Смотри проект WinForms_Predictor:
            // ПРЕДСКАЗЫВАЮ БУДУЩЕЕ НА C#. СОЗДАНИЕ ДЕСКТОПНОГО ПРИЛОЖЕНИЯ НА C#
            // WINDOWS FORMS. ASYNC AWAIT

            // Смотри проект WEB_API_weather

            // Смотри проект WPF_TodoApp:
            // ПИШЕМ ПРИЛОЖЕНИЕ СПИСОК ДЕЛ НА C# WPF ОТ НАЧАЛА ДО КОНЦА
            // DATAGRID. JSON ПАРСИНГ РАБОТА С ФАЙЛАМИ

            // Смотри проект Win_Forms_ImageProccesing:
            // ОБРАБОТКА ИЗОБРАЖЕНИЙ. РАБОТА С КАРТИНКАМИ

            // Смотри проект WinForms_GameOfLife:
            // СИМУЛЯЦИЯ ЖИЗНИ НА C#

            // Смотри проект WinForms_Stars:
            // STARFIELD SIMULATION. Скринсейвер из Windows 98 на C#.


            Lesson_001(); // Ловушки с инкрементом/декрементом и коротким замыканием в C#
            Lesson_002(); // СОЗДАНИЕ DLL C#. КАК ПОДКЛЮЧИТЬ DLL. Метод расширения
            Lesson_003(); // КАК ИЗМЕРИТЬ ВРЕМЯ ВЫПОЛНЕНИЯ ПРОГРАММЫ, КОДА, МЕТОДА, ФУНКЦИИ, ЗАПРОСА. STOPWATCH 

            Console.ReadLine();
        }
    }
}
