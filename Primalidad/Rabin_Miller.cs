using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primalidad
{
    public class Rabin_Miller
    {
        public Rabin_Miller()
        {

        }

        public static long binaryPow(long a, long n, long m)
        {
            long res = 1;
            a = a % m;

            while (n > 0)
            {
                if ((n & 1) == 1)
                    res = (res*a) % m;
                n = n >> 1;
                a = (a * a) % m;
            }

            return res;
        }

        private bool millerTest(int d, int n)
        {
            Random rnd = new Random();
            int a = 2 + rnd.Next(2,n-2) % (n - 4);

            long x = binaryPow(a, d, n);

            if (x == 1 || x == n - 1)
                return true;

            while (d != n - 1)
            {
                x = (x * x) % n;
                d *= 2;

                if (x == 1) return false;
                if (x == n - 1) return true;
            }

            return false;
        }

        public bool isPrime(int n, int k)
        {
            if (n <= 1 || n == 4) return false;
            if (n <= 3) return true;

            int d = n - 1;
            while (d % 2 == 0)
                d /= 2;

            for (int i = 0; i < k; i++)
                if (!millerTest(d, n))
                    return false;

            return true;
        }
    }
}
