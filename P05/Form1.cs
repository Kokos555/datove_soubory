using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace P05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Sport.dat", FileMode.Create, FileAccess.Write);
            string radek_souboru;
            string[] radek = null;


            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                using (StreamReader sr = new StreamReader("sport.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        try { 
                            radek_souboru = sr.ReadLine();
                            radek = radek_souboru.Split(';');
                            int cislo = Convert.ToInt32(radek[0]);
                            string jmeno = Convert.ToString(radek[1]);
                            string primeni = Convert.ToString(radek[2]);
                            char pohlavi = Convert.ToChar(radek[3]);
                            int vyska = Convert.ToInt32(radek[4]);
                            int hmotnost = Convert.ToInt32(radek[5]);
                            bw.Write(cislo);
                            bw.Write(jmeno);
                            bw.Write(primeni);
                            bw.Write(pohlavi);
                            bw.Write(vyska);
                            bw.Write(hmotnost);
                        }
                        catch (FormatException)
                        {

                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Sport.dat", FileMode.Open, FileAccess.Read);
            string zprava = null;
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {

                    zprava = string.Format($"{br.ReadInt32()};{br.ReadString()};{br.ReadString()};{br.ReadChar()};{br.ReadInt32()};{br.ReadInt32()}");
                    textBox1.Text += zprava + "\n";

                }
            }
        }
    }
}
