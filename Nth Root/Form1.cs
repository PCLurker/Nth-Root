using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nth_Root
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int MSB(UInt64 I)
        {
            if (I == 0) return -1;
            int R = 32;
            UInt64 T = 1;
            T <<= 32;
            if (T > I)
            {
                T >>= 16;
                R -= 16;
            }
            else
            {
                T <<= 16;
                R += 16;
            }
            if (T > I)
            {
                T >>= 8;
                R -= 8;
            }
            else
            {
                T <<= 8;
                R += 8;
            }
            if (T > I)
            {
                T >>= 4;
                R -= 4;
            }
            else
            {
                T <<= 4;
                R += 4;
            }
            if (T > I)
            {
                T >>= 2;
                R -= 2;
            }
            else
            {
                T <<= 2;
                R += 2;
            }
            if (T > I)
            {
                T >>= 1;
                R -= 1;
            }
            else
            {
                T <<= 1;
                R += 1;
            }
            if (T > I) R -= 1;
            return R;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UInt64.TryParse(textBox1.Text, out UInt64 S))
            {

            }
            else return;
            if (S == 0)
            {
                textBox3.Text = "0";
                return;
            }
            if (int.TryParse(textBox2.Text, out int B))
            {

            }
            else return;
            int m = MSB(S);
            int n = m / B;
            UInt64 R = 1;
            R <<= n;
            for (int i = n; i > 0; i--)
            {
                R |= (UInt64)(1) << (i - 1); //Flip bit to 1 and try
                if (Math.Pow(R, B) > S) R &= ~((UInt64)(1) << (i - 1)); //>, Test fail, flip bit to 0
            }
            textBox3.Text = R.ToString();
            textBox4.Text = (S - (UInt64)Math.Pow(R, B)).ToString();
        }
    }
}
