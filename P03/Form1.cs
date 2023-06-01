using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace P03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                double soucet = 0;
                double ar = 0;
                try
                {
                    FileStream fs = new FileStream("cisla.dat", FileMode.Open, FileAccess.ReadWrite);
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        //for (int i = 0; br.BaseStream.Position<br.BaseStream.Length && i < n; i++) { 
                        for (int i = 0; i < n; i++)
                        {
                            double cislo = br.ReadDouble();
                            listBox1.Items.Add(cislo);
                            soucet += cislo;
                        }

                    }
                    if (n == 0) { throw new DivideByZeroException(); }
                    ar = soucet / n;
                    MessageBox.Show($"{ar}");

                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (OverflowException ex)
            {
                MessageBox.Show($"{ex}");
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex}");
            }
            catch (EndOfStreamException ex)
            {
                MessageBox.Show($"{ex}");
            }
            catch(DivideByZeroException ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
