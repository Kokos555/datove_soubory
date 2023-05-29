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

namespace P01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Create, FileAccess.ReadWrite);
            try {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    using (StreamReader sr = new StreamReader("cisla.txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            try
                            {
                                int cisla = Convert.ToInt32(sr.ReadLine());
                                listBox1.Items.Add(cisla);
                                bw.Write(cisla);
                            }
                            catch (FormatException)
                            {

                            }
                        }
                    }

                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            int x = br.ReadInt32();
                            listBox2.Items.Add(x);
                        }
                    }

                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(String.Format($"{ex}"));
            }
        }
    }
}
