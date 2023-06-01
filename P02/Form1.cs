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

namespace P02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) { 
                    string jmeno = openFileDialog1.FileName;
                    FileStream fs = new FileStream(jmeno, FileMode.Open, FileAccess.Read);
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                        {
                            while (br.BaseStream.Position < br.BaseStream.Length) { 
                                int x = br.ReadInt32();
                                listBox1.Items.Add(x);
                                sw.WriteLine(x);
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(saveFileDialog1.FileName))
            {
                while (!sr.EndOfStream)
                {
                    string x = sr.ReadLine();
                    listBox2.Items.Add(x);
                }
            }
        }
    }
}
