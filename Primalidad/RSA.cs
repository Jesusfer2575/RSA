using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primalidad
{
    public class RSA
    {
        private static int p;
        private static int q;
        private static int fi;
        private static int n;
        private static int e;
        private static int d;
        private static long encrypted_value;
        private static long decrypted_value;
        private Random rnd;

        public RSA(){}
        

        public void CalculateImportantValues()
        {
            n = p * q;
            fi = (p-1) * (q-1);

            bool isCoprime = false;
            this.rnd = new Random();
            while (!isCoprime)
            {
                e = this.rnd.Next(3, fi);
                if(Euclides.GCD(e, fi) == 1)
                    isCoprime = true;
            }
            
            d = Euclides.Extendido(e, fi);

        }

        public long Encrypt(int m)
        {
            return encrypted_value = Rabin_Miller.binaryPow(m,e,n);
        }

        public long Decrypt(long c)
        {
            return decrypted_value = Rabin_Miller.binaryPow(c, d, n);
        }

        public void CalculatePrimes()
        {
            bool isPrime = false;
            this.rnd = new Random();
            Rabin_Miller rm = new Rabin_Miller();
            while (!isPrime)
            {
                p = this.rnd.Next(1000,100000);
                isPrime = rm.isPrime(p, 4);
            }

            isPrime = false;
            while (!isPrime)
            {
                q = rnd.Next(1000, 10000);
                isPrime = rm.isPrime(q, 4);
            }

        }
    }
}
