using System;

namespace MyCodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите сумму: ");
            double sum1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите суммы распределения: ");
            string[] str = Console.ReadLine().Split(";");
            double[] num1 = new double[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                num1[i] = Convert.ToDouble(str[i]);
            }

            Console.Write("Введите тип распределения ('ПРОП', 'ПЕРВ', 'ПОСЛ'): ");
            string type = Console.ReadLine();

            // В классе Entry обозначается общая информация
            switch (type)
            {
                case "ПРОП":
                    double[] propor = FunctionProp(sum1, num1);
                    Entry(sum1, num1, type);

                    Console.Write("\r\nВыход: ");
                    for (int i = 0; i < propor.Length; i++)
                    {
                        Console.Write(Math.Round(propor[i], 2) + ";");
                    }
                    break;

                case "ПЕРВ":
                    double[] one = FunctionFirst(sum1, num1);
                    Entry(sum1, num1, type);

                    Console.Write("\r\nВыход: ");
                    for (int i = 0; i < one.Length; i++)
                    {
                        Console.Write(Math.Round(one[i], 2) + ";");
                    }
                    break;

                case "ПОСЛ":
                    double[] last = FunctionLast(sum1, num1);
                    Entry(sum1, num1, type);

                    Console.Write("\r\nВыход: ");
                    Array.Reverse(last);
                    for (int i = 0; i < last.Length; i++)
                    {
                        Console.Write(Math.Round(last[i], 2) + ";");
                    }
                    break;
            }
            Console.ReadKey();
        }

        // Распределение пропорционально
        public static double[] FunctionProp(double sum1, double[] num1)
        {
            double addition = 0;
            double[] Functionprop = new double[num1.Length];

            for (int i = 0; i < num1.Length; i++)
            {
                addition += num1[i];
            }
            for (int i = 0; i < num1.Length; i++)
            {
                Functionprop[i] = (sum1 / addition) * (Math.Round(num1[i], 2));
            }


            return Functionprop;
        }

        // Распределение по первым суммам
        public static double[] FunctionFirst(double sum1, double[] num1)
        {
            double counter = 0;
            double[] Functionone = new double[num1.Length];

            for (int i = 0; i < num1.Length; i++)
            {
                counter += num1[i];
                if (counter < sum1)
                {
                    Functionone[i] = Math.Round(num1[i], 2);
                }
                else
                {
                    counter = sum1 - (counter - num1[i]);
                    Functionone[i] = Math.Round(counter, 2);
                    return Functionone;
                }
            }
            return Functionone;
        }

        // Распределение по последним суммам
        public static double[] FunctionLast(double sum1, double[] num1)
        {
            double counter = 0;
            double[] Functionlast = new double[num1.Length];

            Array.Reverse(num1);
            for (int i = 0; i < num1.Length; i++)
            {
                counter += num1[i];
                if (counter < sum1)
                {
                    Functionlast[i] = Math.Round(num1[i], 2);
                }
                else
                {
                    counter = sum1 - (counter - num1[i]);
                    Functionlast[i] = Math.Round(counter, 2);
                    return Functionlast;
                }
            }
            return Functionlast;
        }

        // Вывод общей информацией
        public static void Entry(double sum1, double[] num1, string type)
        {
            Console.WriteLine("Тип распределения - порпорционально" + "(" + type + ")");
            Console.WriteLine("Сумма - " + sum1);

            // Инвертирование массива для последнеко случая
            if (type == "ПОСЛ")
            {
                Array.Reverse(num1);
                Console.Write("Суммы: ");
                for (int i = 0; i < num1.Length; i++)
                {
                    Console.Write(num1[i] + ";");
                }
            }
            else
            {
                Console.Write("Суммы: ");
                for (int i = 0; i < num1.Length; i++)
                {
                    Console.Write(num1[i] + ";");
                }
            }
        }
    }
}
