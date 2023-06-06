using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            FileStream fs = new FileStream("cisla.dat", FileMode.Create, FileAccess.Write);
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                for (int i = 0; i < textBox1.Lines.Count(); i++)
                {
                    x = Convert.ToInt32(textBox1.Lines[i]);
                    bw.Write(x);
                }
               
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Open, FileAccess.ReadWrite);
            long pos2 = 0;
            int x = 0;
            int max = Int32.MinValue;
            using(BinaryWriter bw = new BinaryWriter(fs))
            {
                using (BinaryReader br = new BinaryReader(fs)) { 
                    while (bw.BaseStream.Position < bw.BaseStream.Length)
                    {
                        x = br.ReadInt32();
                        if (x > max)
                        {
                            max = x;
                            pos2 = br.BaseStream.Position;
                        }
                        listBox1.Items.Add(x);
                    }
                    br.BaseStream.Position -= 4;
                    bw.Write(max);
                    br.BaseStream.Position = pos2 - 4;
                    bw.Write(x);
                    
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Open, FileAccess.Read);
            int x;
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    x = br.ReadInt32();
                    listBox2.Items.Add(x);
                }
            }
        }
    }
}
