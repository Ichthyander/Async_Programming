using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*1.    Разработать асинхронный метод для вычисления факториала числа. В методе Main выполнить проверку работы метода.*/

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для вычисления факториала");
            int n = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine(Factorial(n));

            FactorialAsync(n);
            
            //Проверка асинхронности
            Console.WriteLine("Метод Main завершает работу");
            Console.ReadKey();
        }

        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        static async Task<int> FactorialAsync(int n)
        {
            int factorial = await Task.Run(()=>Factorial(n));

            //Вывод организован в теле метода, чтобы в методе Main к FactorialAsync(n) не ставить блокирующий параметр Result
            Console.WriteLine("Факториал числа {0} равен - {1}",n, factorial);
            return factorial;
        }
    }
}
