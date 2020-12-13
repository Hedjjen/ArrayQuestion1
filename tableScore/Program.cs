using System;
using static System.Console;

namespace tableScore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.
            // Заказчик просит вас написать приложение по учету финансов
            // и протестрировать его работу!
            // Суть задачи в следующем:
            // Руководство фирмы по 12 месяцев ведет учет расходов и поступлений средств.
            // За год получены два массива - расходов и поступлений.
            // Определить прибыли по месяцам 
            // Количество месяцев с положительной прибылью
            // Добавить возможность вывода трех худших показателей по месяцам с худшей прибылью,
            // если есть несколько месяцев, в которых худшая прибыль совпала - вместе их все
            // Организовать дружелюбный интерфейс взаимодействия и вывода на экран

            // Пример:

            // Месяц     Доход, тыс. руб.     Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1             100 000                80 000                 20 000
            //     2             120 000               120 000                      0
            //     3              90 000                65 000                 25 000
            //     4              65 000                30 000                 35 000

            string[] nameTable = { "Месяц", "Доход, тыс. руб.", "Расход, тыс. руб.", "Прибыль, тыс. руб." };
            int[] mounth = new int[12];
            int[] income = new int[12];
            int[] consumption = new int[12];
            int[] profit = new int[12];

            FillingTable(mounth, income, consumption, profit);

            Print(nameTable, mounth, income, consumption, profit);

            int[] profitCopy = new int[12];

            Array.Copy(profit, profitCopy, 12);
            Array.Sort(profitCopy);

            int count = 0;
            int firstBadNumber = profitCopy[0];
            int secondBadNumber = 0;
            int thirdBadNumber = 0;

            for (int i = 0; i < profit.Length; i++)
            {
                if (profitCopy[i] > firstBadNumber && count == 0) 
                {
                    secondBadNumber = profitCopy[i];
                    count++;
                }

                if (profitCopy[i] > secondBadNumber && count == 1)
                {
                    thirdBadNumber = profitCopy[i];
                    count++;
                }
            }

            Write("Худшие месяцы по показанию выручки: ");
            for (int i = 0; i < 12; i++)
            {
                 if (profit[i] == firstBadNumber || profit[i] == secondBadNumber || profit[i] == thirdBadNumber)
                 {
                    Write($"{mounth[i]} месяц ");
                 }
            }
    
            ReadKey();
        }

        static void FillingTable(int[] mounth, int[] income, int[] consumption, int[] profit)
        {
            Random random = new Random();

            for (int i = 0; i < 12; i++)
            {
                mounth[i] = i + 1;
                income[i] = random.Next(100_000);
                consumption[i] = random.Next(100_000);
                profit[i] = income[i] - consumption[i];
            }
        }

        static void Print(string[] nameTable, int[] mounth, int[] income, int[] consumption, int[] profit)
        {
            foreach (var item in nameTable)
            {
                Write($"{item,20}");
            }
            WriteLine();

            for (int i = 0; i < 12; i++)
            {
                Write($"{mounth[i],20}{income[i],20}{consumption[i],20}{profit[i],20}");
                WriteLine();
            }

        }


                        
        

}
}
