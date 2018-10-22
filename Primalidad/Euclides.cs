using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primalidad
{
    public class Euclides
    {
        private static int x;
        private static int y;

        private static int regresa_a_N(int n, int val)
        {
            int ans;
            while (val < 0)
                val += n;
            //ans = n - (abs(val)%n); Calculo en constante
            return val;
        }

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
