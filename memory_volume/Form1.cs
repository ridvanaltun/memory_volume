using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using memory;
using System.Diagnostics;

namespace memory_volume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bellek oku;

        Process[] prc = Process.GetProcessesByName("explorer");
        int deger = 0; Int64 anaAdres = 0;
        int offset1, offset2, offset3, offset4, offset5, offset6, yanDeger;


        private void Form1_Load(object sender, EventArgs e)
        {
            //oku = new Bellek("explorer.exe");
            oku = new Bellek(prc[0]);
            foreach (ProcessModule modul in prc[0].Modules)
            {
                if (modul.ModuleName == "explorer.exe")
                {
                    anaAdres = modul.BaseAddress.ToInt64();
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            deger = oku.Int_OKU_Offset(anaAdres + yanDeger, new int[] { offset1, offset2, offset3, offset4, offset5, offset6 });
            if (deger < 101)
            {
                progressBar1.Value = deger;
                this.Text = "%" + deger;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Apply")
            {

                if (textBox1.Text == "0x" || textBox4.Text == "0x" || textBox11.Text == "0x" || textBox8.Text == "0x" || textBox7.Text == "0x" || textBox6.Text == "0x" || textBox5.Text == "0x")
                {
                    label1.Text = "0x is bad";
                }
                else
                {
                    label1.Text = "good job";
                    yanDeger = Convert.ToInt32(textBox1.Text);
                    offset1 = Convert.ToInt32(textBox4.Text);
                    offset2 = Convert.ToInt32(textBox11.Text);
                    offset3 = Convert.ToInt32(textBox8.Text);
                    offset4 = Convert.ToInt32(textBox7.Text);
                    offset5 = Convert.ToInt32(textBox6.Text);
                    offset6 = Convert.ToInt32(textBox5.Text);

                    textBox1.Enabled = false;
                    textBox4.Enabled = false;
                    textBox11.Enabled = false;
                    textBox8.Enabled = false;
                    textBox7.Enabled = false;
                    textBox6.Enabled = false;
                    textBox5.Enabled = false;

                    button1.Text = "Stop";
                    button2.Enabled = false;
                    timer1.Enabled = true;
                }

            }
            else
            {
                button1.Text = "Apply";
                button2.Enabled = true;
                timer1.Enabled = false;

                textBox1.Enabled = true;
                textBox4.Enabled = true;
                textBox11.Enabled = true;
                textBox8.Enabled = true;
                textBox7.Enabled = true;
                textBox6.Enabled = true;
                textBox5.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0xE94D0";
            textBox4.Text = "0x";
            textBox11.Text = "0x";
            textBox8.Text = "0x";
            textBox7.Text = "0x";
            textBox6.Text = "0x";
            textBox5.Text = "0x";
        }
    }
}
