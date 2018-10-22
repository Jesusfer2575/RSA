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
        
        /// <summary>
        /// Este método calcula algunas operaciones parte de RSA
        /// </summary>
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

        /// <summary>
        /// Este método Cifra el texto en forma de número
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public long Encrypt(int m)
        {
            return encrypted_value = Rabin_Miller.binaryPow(m,e,n);
        }


        /// <summary>
        /// Este método descifra el mensaje cifrado
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public long Decrypt(long c)
        {
            return decrypted_value = Rabin_Miller.binaryPow(c, d, n);
        }

        /// <summary>
        /// Con ayuda de la clase Rabin_Miller
        /// se calculan dos números primos, del orden 1x10^8
        /// </summary>
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
