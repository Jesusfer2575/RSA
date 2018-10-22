using System;

namespace Primalidad
{
    public class Euclides
    {
        private static int x;
        private static int y;

        /// <summary>
        /// Está función regresa a un valor positivo en caso de que, dado el algoritmo extendido de euclides,
        /// haya dado un valor negativo para el inverso mutiplicativo modular
        /// Complejidad: O(c) Constante
        /// </summary>
        /// <param name="n"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private static int regresa_a_N(int n, int val)
        {
            val = n - (Math.Abs(val)%n); 
            return val;
        }

        /// <summary>
        /// Este método calcula el máximo común divisor, dado el algoritmo de euclides
        /// Complejidad O(log(x/x%y)(xy))
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a = a % b;
                else if (b > a)
                    b = b % a;
            }
            return (a != 0) ? a : b;
        }

        /// <summary>
        /// Este método ejecuta el algoritmo extendido de euclides para el cálculo 
        /// del inverso multiplicativo modular 'd' de 'e' dentro del campo de n
        /// siendo n = p*q
        /// Complejidad O(log n)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void extendedEuclides(int a, int b)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return;
            }
            extendedEuclides(b, a % b);
            int x1 = y;
            int y1 = x - (a / b) * y;// A este punto a=b y b = a%b y se va construyendo desde 0 como el residuo llega a cero con euclides
                                     // y x a 1
            x = x1;
            y = y1;
        }

        public static int Extendido(int a, int b)
        {
            if(Euclides.GCD(a,b) == 1)
            {
                if (a > b)
                {
                    extendedEuclides(b, a);
                    if (x < 0)
                        x = regresa_a_N(a, x);
                }
                else
                {
                    extendedEuclides(a, b);
                    if (x < 0)
                        x = regresa_a_N(b, x);
                }
            }
            return x;
        }
    }
}
