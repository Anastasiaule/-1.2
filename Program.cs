namespace лаба_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начальную сумму вклада (A): ");
            double A = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите величину ежемесячного увеличения вклада, после которого нужно прекратить (B): ");
            double B = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите величину вклада, после которого нужно прекратить (C): ");
            double C = double.Parse(Console.ReadLine());

            // Проверки через класс и методы
            var calculator = new DepositCalculator();

            int monthForIncrease = calculator.GetMonthForIncrease(A, B);
            Console.WriteLine($"Величина ежемесячного увеличения превысит {B} руб. в {monthForIncrease} месяце.");

            int monthForBalance = calculator.GetMonthForBalance(A, C);
            Console.WriteLine($"Размер вклада превысит {C} руб. через {monthForBalance} месяцев.");
        }
    }

    public class DepositCalculator
    {
        // Метод для расчета месяца, когда увеличение вклада превысит B
        public int GetMonthForIncrease(double A, double B)
        {
            double balance = A;
            int month = 0;

            // Цикл for для подсчета месяца, когда увеличение превысит B
            for (month = 1; balance * 0.02 <= B; month++)
            {
                balance += balance * 0.02;
            }

            return month;
        }

        // Метод для расчета месяца, когда размер вклада превысит C
        public int GetMonthForBalance(double A, double C)
        {
            double balance = A;
            int month = 0;

            // Цикл for для подсчета месяца, когда вклад превысит C
            for (month = 1; balance <= C; month++)
            {
                balance += balance * 0.02;
            }

            return month;
        }
    }
}

