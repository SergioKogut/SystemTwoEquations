using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Разработать метод для решения системы 2 линейных уравнений:
A1×X + B1×Y = C1
A2×X + B2×Y = C2
Метод с помощью выходных параметров должен возвращать найденное решение или ошибку,
если решения не существует
Відповідь: для рішення використовуємо метод Гауса для системи двох рівнянь:

Delta=A1*B2-A2*B1;
x=(C1*B2-C2*B1)/Delta;
x=(A1*C2-C1*A2)/Delta;

*/

namespace SystemTwoEquations
{
    static class SystemEquations
    {
        internal static void Solve(double a1, double b1, double c1, double a2, double b2, double c2, out double x, out double y)
        {

            if ((a1 != 0 && b1 != 0) || (a2 != 0 || b2 != 0))
            {
                double Delta = a1 * b2 - a2 * b1;
                if (Delta==0)
                {
                    x = 0;
                    y = 0;
                }
                x = Math.Round((c1 * b2 - c2 * b1) / Delta, 2);
                y = Math.Round((a1 * c2 - a2 * c1) / Delta, 2);

            }
            else
            {
                throw new ArgumentOutOfRangeException("One of lines is not existing.");
            }


        }

    }   

        class Program
        {
            static void Main(string[] args)
            {
                double x, y;
                double a1 = -1, b1 = 3, a2 = 2, b2 = 6, c1 = 7, c2 = 10;

                try
                {
                    SystemEquations.Solve(a1, b1, a2, b2,c1,c2, out x, out y);
                    Console.WriteLine($"x = {x};  y = {y};");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Solution is not existing. " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Process decision ended good!!");
                }
                Console.ReadKey();
            }
        }
    }
