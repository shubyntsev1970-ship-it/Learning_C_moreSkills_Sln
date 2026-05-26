
using MyLibrary;
using System.Diagnostics;

namespace Lessons
{
    internal static partial class Program
    {
        // Ловушки с инкрементом/декрементом и коротким замыканием в C#
        public static void Lesson_001()
        {

            Console.WriteLine("Hello from Lesson_001 !!!\nЛовушки с инкрементом/декрементом и коротким замыканием в C#");
            Console.WriteLine();

            // Постфиксный инкремент(декремент): сначала возвращается текущее значение переменной,
            // а потом она увеличивается(уменьшается) на 1.
            // Префиксный инкремент(декремент): сначала переменная увеличивается(уменьшается) на 1,
            // а потом возвращается её новое значение.
            //            Простая мнемоника
            // f++ → “сначала отдай, потом увеличь”
            // ++f → “сначала увеличь, потом отдай”

            //            И ещё важное правило:
            //Операторы с одинаковым приоритетом обычно выполняются слева направо
            //Но присваивания выполняются справа налево

            int? a, b, c;
            bool result;

            a = 5;
            Console.WriteLine($"a = {a}");
            b = a++ + ++a;
            Console.WriteLine($"b = a++ + ++a\t a = {a}\tb = {b}"); // Выведет b = a++ + ++a    a = 7  b = 12
            b = ++a + a++;
            Console.WriteLine($"b = ++a + a++\t a = {a}\tb = {b}"); // Выведет b = ++a + a++    a = 9  b = 16

            Console.WriteLine();

            a = 2;
            Console.WriteLine($"a = {a}");
            b = a * (a += a++);
            Console.WriteLine($"b = a * (a += a++)\ta = {a}\tb = {b}");
            // Выведет b = a * (a += a++) a = 4	b = 8

            Console.WriteLine();

            a = 2;
            Console.WriteLine($"a = {a}");
            b = a++ + a * (a += ++a);
            Console.WriteLine($"b = a++ + a * (a += ++a)\ta = {a}\tb = {b}");
            // Выведет b = a++ + a * (a += ++a)	a = 7	b = 23
            Console.WriteLine();

            a = 1;
            Console.WriteLine($"a = {a}");
            b = (a++) * 2;  // Скобки просто явно подтверждают порядок (и имеют приоритет выше всего).
                            // Сначала a возвращает текущее значение 1 а только потом увеличивается на 1 (несмотря на скобки)
            Console.WriteLine($"b = (a++) * 2\ta = {a}\tb = {b}"); // Выведет b = (a++) * 2    a = 2  b = 2

            Console.WriteLine();

            a = 4;
            b = 1;
            c = 0;
            Console.WriteLine($"a = {a}\tb = {b}\tc = {c}");
            c = a++ / b;
            Console.WriteLine($"c = a++ / b\ta = {a}\tb = {b}\tc = {c}"); // Выведет c = a++ / b
                                                                          // a = 5  b = 1  c = 4
            Console.WriteLine();

            a = 1;
            Console.WriteLine($"a = {a}");
            b = a++ + a++ + ++a;
            Console.WriteLine($"b = a++ + a++ + ++a\ta = {a}\tb = {b}"); // Выведет b = a++ + a++ + ++a    a = 4  b = 7

            Console.WriteLine();

            //            Запомнить просто
            // +, * → слева направо
            // = → справа налево
            a = 1;
            Console.WriteLine($"a = {a}");
            b = a += a++ + ++a;
            Console.WriteLine($"b = a += a++ + ++a\ta = {a}\tb = {b}"); // Выведет b = a += a++ + ++a    a = 5  b = 5

            Console.WriteLine();

            a = 2;
            Console.WriteLine($"a = {a}");
            b = a * (a += a++);
            Console.WriteLine($"b = a * (a += a++)\ta = {a}\tb = {b}"); // Выведет b = a * (a += a++)    a = 4  b = 8

            Console.WriteLine();

            a = 2;
            Console.WriteLine($"a = {a}");
            b = a++ + a * (a += ++a);
            Console.WriteLine($"b = a++ + a * (a += ++a)\ta = {a}\tb = {b}"); // Выведет b = a++ + a * (a += ++a)    a = 7  b = 23

            Console.WriteLine();

            a = 0;
            b = 1;
            result = false;
            Console.WriteLine($"a = {a}\tb = {b}\tresult = {result}");
            result = a++ > 0 && (b++ > 0); // Здесь короткое замыкание. Так как a++ > 0 возвращает false и у нас &&,
                                           // то b++ > 0 не выполняется и b не увеличивается.
            Console.WriteLine($"result = a++ > 0 && (b++ > 0) a = {a}\tb = {b}\tresult = {result}");
            // Выведет result = a++ > 0 && (b++ > 0) a = 1  b = 1  result = False

            //            Ключевой момент
            // && → если слева false → дальше не идём
            // || → если слева true → дальше не идём

            //👉 это называется short-circuit evaluation

            Console.WriteLine();

            a = 0;
            b = 1;
            result = false;
            Console.WriteLine($"a = {a}\tb = {b}\tresult = {result}");
            result = a++ > 0 || (b++ > 0); // Здесь короткое замыкание. Так как a++ > 0 возвращает false и у нас ||,
                                           // то b++ > 0 выполняется и b увеличивается.
            Console.WriteLine($"result = a++ > 0 || (b++ > 0) a = {a}\tb = {b}\tresult = {result}");
            // Выведет result = a++ > 0 || (b++ > 0) a = 1  b = 2  result = True 

            Console.WriteLine();

            a = null;
            b = 2;
            c = 0;
            Console.WriteLine($"a = {a}\tb = {b}\tc = {c}");
            c = a ?? b + 3;
            Console.WriteLine($"c = a ?? b + 3 a = {a}\tb = {b}\tc = {c}");
            // Выведет c = a ?? b + 3    a = null  b = 2  c = 5

            Console.WriteLine();

            a = 0;
            result = false;
            Console.WriteLine($"a = {a}\tresult = {result}");
            result = true || (a++ > 0 && a++ > 0); // Здесь короткое замыкание. Так как true || ... возвращает true,
                                                   // то (a++ > 0 && a++ > 0) не выполняется и a не увеличивается.
            Console.WriteLine($"result = true || (a++ > 0 && a++ > 0) a = {a}\tresult = {result}");
            // Выведет result = true || (a++ > 0 && a++ > 0) a = 0  result = True

            Console.WriteLine();

            a = 1;
            b = 2;
            c = null;
            int? res = 0;
            Console.WriteLine($"a = {a}\tb = {b}\tc = {c}\tres = {res}");
            res = a++ + (c ?? b++ * ++a) + (b += a++);
            Console.WriteLine($"res = a++ + (c ?? b++ * ++a) + (b += a++) a = {a}\tb = {b}\tc = {c}\tres = {res}");
            // Выведет res = a++ + (c ?? b++ * ++a) + (b += a++)    a = 4  b = 6  c = null  res = 13

            Console.WriteLine();

            a = null;
            b = 1;
            c = 2;
            result = false;
            Console.WriteLine($"a = {a}\tb = {b}\tc = {c}\tresult = {result}");
            result = (a ??= b++) > 0 && (b += a++) > 1 || (c += ++b) > 3;
            Console.WriteLine($"result = (a ??= b++) > 0 && (b += a++) > 1 || (c += ++b) > 3 a = {a}\tb = {b}\tc = {c}\tresult = {result}");
            // Выведет result = (a ??= b++) > 0 && (b += a++) > 1 || (c += ++b) > 3    a = 2  b = 3  c = 2  result = True

            Console.WriteLine();

            a = null;
            b = 1;
            c = 2;
            res = 0;
            Console.WriteLine($"a = {a}\tb = {b}\tc = {c}\tres = {res}");
            res = (a ??= b++) + (a ??= ++b) + (b += a++) * (c += b++) + (a ?? c);
            Console.WriteLine($"res = (a ??= b++) + (a ??= ++b) + (b += a++) * (c += b++) + (a ?? c) a = {a}\tb = {b}\tc = {c}\tres = {res}");
            // Выведет res = (a ??= b++) + (a ??= ++b) + (b += a++) * (c += b++) + (a ?? c)    a = 2  b = 4  c = 5  res = 19

            Console.WriteLine(new string('-', 120));
        }

        // СОЗДАНИЕ DLL C#. КАК ПОДКЛЮЧИТЬ DLL. Метод расширения
        public static void Lesson_002()
        {
            Console.WriteLine("Hello from Lesson_002 !!!\nСОЗДАНИЕ DLL C#. КАК ПОДКЛЮЧИТЬ DLL. Метод расширения");
            Console.WriteLine();

            // Создание DLL в C#:
            // 1. Создайте новый проект в Visual Studio и выберите тип проекта "Class Library"
            // (Библиотека классов).
            // 2. Напишите код для вашей библиотеки классов.
            // 3. Постройте проект, чтобы создать DLL-файл.

            // Подключение DLL в C#:
            // 1. В вашем основном проекте щелкните правой кнопкой мыши на "References" (Ссылки)
            // и выберите "Add Reference..." (Добавить ссылку...).
            // 2. В открывшемся окне выберите вкладку "Browse" (Обзор) и найдите созданный DLL-файл.
            // 3. Нажмите "OK", чтобы добавить ссылку на DLL в ваш проект.
            // 4. using MyLibrary;  Подключение пространства имен вашей библиотеки классов
            // 5. Теперь вы можете использовать классы и методы из подключенной DLL в вашем коде.

            double firstValue = 12, secondValue = 3, result;

            Console.WriteLine($"firstValue = {firstValue}, secondValue = {secondValue}");

            // Ниже методы которые вызываются из MyLibrary.dll

            result = MyMathOp.Addition(firstValue, secondValue);
            Console.WriteLine($"MyMathOp.Addition(firstValue, secondValue) = {result}");

            result = MyMathOp.Subtraction(firstValue, secondValue);
            Console.WriteLine($"MyMathOp.Subtraction(firstValue, secondValue) = {result}");

            result = MyMathOp.Multiplication(firstValue, secondValue);
            Console.WriteLine($"MyMathOp.Multiplication(firstValue, secondValue) = {result}");

            result = MyMathOp.Division(firstValue, secondValue);
            Console.WriteLine($"MyMathOp.Division(firstValue, secondValue) = {result}");

            // Теперь мы можем использовать метод расширения Mod2, который был создан в классе MyExtensions.
            //result = MyMathOp.Mod2(firstValue, secondValue); // Так нельзя потому что Mod2 является методом расширения
            // и не может быть вызван напрямую через класс MyMathOp.

            // Только так
            MyMathOp myMathOp = new MyMathOp();

            result = MyExtensions.Mod2(myMathOp, firstValue, secondValue);
            Console.WriteLine($"MyExtensions.Mod2(myMathOp, firstValue, secondValue) = {result}");
            // или
            result = myMathOp.Mod2(firstValue, secondValue);
            Console.WriteLine($"myMathOp.Mod2(firstValue, secondValue) = {result}");
            // или
            result = new MyMathOp().Mod2(firstValue, secondValue);
            Console.WriteLine($"new MyMathOp().Mod2(firstValue, secondValue) = {result}");

            Console.WriteLine(new string('-', 120));
        }

        // КАК ИЗМЕРИТЬ ВРЕМЯ ВЫПОЛНЕНИЯ ПРОГРАММЫ, КОДА, МЕТОДА, ФУНКЦИИ, ЗАПРОСА. STOPWATCH
        public static void Lesson_003()
        {
            Console.WriteLine("Hello from Lesson_003 !!!\nКАК ИЗМЕРИТЬ ВРЕМЯ ВЫПОЛНЕНИЯ ПРОГРАММЫ, КОДА, МЕТОДА, ФУНКЦИИ, ЗАПРОСА. STOPWATCH");
            Console.WriteLine();

            // Для измерения времени выполнения кода в C# можно использовать класс Stopwatch из пространства имен System.Diagnostics.
            // Вот пример использования Stopwatch для измерения времени выполнения метода:
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // Начало измерения времени
            // Здесь размещаем код, время выполнения которого нужно измерить
            Thread.Sleep(123);
            stopwatch.Stop(); // Остановка измерения времени
            Console.WriteLine($"Время выполнения кода: {stopwatch.ElapsedMilliseconds} миллисекунд");

            Console.WriteLine();

            stopwatch.Restart();
            // Здесь размещаем код, время выполнения которого нужно измерить
            for (int i = 0; i < 1000000; i++)
            {
                var temp = Math.Sqrt(i);
            }

            stopwatch.Stop();

            Console.WriteLine($"Время выполнения кода: {stopwatch.Elapsed} миллисекунд");
            Console.WriteLine($"Время выполнения кода: {stopwatch.Elapsed.TotalMilliseconds} миллисекунд");

            Console.WriteLine(new string('-', 120));
        }

        // На что способен один искусственный нейрон. Искусственный нейрон на C# с нуля
        public static void Lesson_004()
        {
            Console.WriteLine("Hello from Lesson_004 !!!\nНа что способен один искусственный нейрон. Искусственный нейрон на C# с нуля");
            Console.WriteLine();
            // Искусственный нейрон - это базовый элемент искусственной нейронной сети, который имитирует работу биологического нейрона.
            // Он принимает несколько входных сигналов, обрабатывает их и выдает выходной сигнал на основе определенной функции активации.
            // На что способен один искусственный нейрон?
            // 1. Логические операции: Один искусственный нейрон может выполнять логические операции, такие как AND, OR, NOT.
            // 2. Линейные функции: Он может моделировать линейные функции и принимать решения на основе линейной комбинации входных данных.
            // 3. Классификация: Искусственный нейрон может использоваться для классификации данных, например, для распознавания образов
            // или текста.
            // 4. Регрессия: Он может использоваться для предсказания числовых значений на основе входных данных.

            decimal km = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();

            Console.WriteLine("До обучения нейрона");
            Console.WriteLine($"{neuron.ProcessInputData(km)} миль в {km} км");
            Console.WriteLine("Нажмите любую кнопку для начала обучения нейрона");
            Console.ReadLine();

            int i = 0;

            do
            {
                i++;

                neuron.Train(km, miles);
                if ( i % 10000 == 0)
                    Console.WriteLine($"Итерация: {i}\tОшибка:\t{neuron.LastError}");

            }
            while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("После обучения нейрона");
            
            Console.WriteLine($"{neuron.ProcessInputData(km)} миль в {km} км");

            Console.WriteLine($"{neuron.ProcessInputData(541)} миль в {541} км");

            Console.WriteLine($"{neuron.RestoreInputData(10)} км в {10} миль");

            Console.WriteLine(new string('-', 120));
        }
    }

    public class Neuron
    {
        private decimal weight = 0.5m;
        public decimal LastError { get; private set; }
        public decimal Smoothing { get; set; } = 0.00001m;
        public decimal ProcessInputData(decimal input)
        {
            return input * weight;
        }

        public decimal RestoreInputData(decimal output)
        {
            return output / weight;
        }

        public void Train(decimal input, decimal expectedResult)
        {
            var actualResult = input * weight;
            LastError = expectedResult - actualResult;
            var correction = (LastError / actualResult) * Smoothing;
            weight += correction;
        }
    }

    // Создаем методы расширения в C#:
    public static class MyExtensions
    {
        public static double Mod2(this MyMathOp myMathOp, double a, double b)
        {
            return a % b;
        }

    }
}
