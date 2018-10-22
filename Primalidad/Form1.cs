using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primalidad
{
    public partial class Form1 : Form
    {
        public long c;
        private RSA rsa;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init(){}

        private void Decrypt_Click(object sender, EventArgs e)
        {
            this.rsa = new RSA();
            long m = this.rsa.Decrypt(this.c);
            txtEncripted.Text = m.ToString(); 
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            this.rsa = new RSA();
            this.rsa.CalculatePrimes();
            this.rsa.CalculateImportantValues();
            this.c = this.rsa.Encrypt(Convert.ToInt32(txtMessage.Text));
            txtEncripted.Text = c.ToString();
        }
    }
}
