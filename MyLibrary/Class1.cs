namespace MyLibrary
{
    // Имя класса не должно совпадать с именем метода расширения, иначе будет ошибка компиляции.
    // Имя класса не должно совпадать с именем namespace, иначе будет ошибка компиляции.
    public class MyMathOp
    {
        public static double Addition(double a, double b)
        {
            return a + b;
        }
        public static double Subtraction(double a, double b)
        {
            return a - b;
        }

        public static double Multiplication(double a, double b)
        {
            return a * b;
        }
        public static double Division(double a, double b)
        {
            if (b == 0)
                return 0;
            return a / b;
        }

    }
}
