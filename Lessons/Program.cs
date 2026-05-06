using System.Text;

namespace Lessons
{
    internal static partial class Program
    {
        static void Main()
        {
            
            Console.OutputEncoding = Encoding.UTF8; // Изменяем кодировку консоли

            // Смотри проект Learning_C_WinForms_Predictor:
            // ПРЕДСКАЗЫВАЮ БУДУЩЕЕ НА C#. СОЗДАНИЕ ДЕСКТОПНОГО ПРИЛОЖЕНИЯ НА C#
            // WINDOWS FORMS. ASYNC AWAIT

            Lesson_001(); // Ловушки с инкрементом/декрементом и коротким замыканием в C#
            Lesson_002(); // СОЗДАНИЕ DLL C#. КАК ПОДКЛЮЧИТЬ DLL. Метод расширения
            
            Console.ReadLine();
        }
    }
}
