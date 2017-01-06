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
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            deger = oku.Int_OKU_Offset(anaAdres + 0xE94D0, new int[] { 0x338, 0x158, 0x40, 0xc8, 0xd8, 0xe8 });
            if (deger < 101)
            {
                progressBar1.Value = deger;
                this.Text = "%" + deger;
            }
        }
    }
}
