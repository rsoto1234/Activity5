using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp3
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String str;
        int max_val = 0, max_index = 0, vow_count = 0, vow_index;

        private void btnSelect_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //here we can see the open file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                str = System.IO.File.ReadAllText(openFileDialog1.FileName); //read text file from our string file s
                txtdisplay.Text = str.ToLower();//make it in lower
                string[] array = str.Split(' ');//split string with blank seperator
                txtfirstword.Text = array[0];//it is first word
                txtlastword.Text = array[array.Length - 1];//it is last word
                for (int i = 0; i < array.Length - 1; i++)//here loop from start to end to make our appropriate output
                {
                    if (max_val < array[i].Length)
                    {
                        max_val = array[i].Length;
                        max_index = i;
                    }
                    if (vow_count < VowelCount(array[i]))
                    {
                        vow_count = VowelCount(array[i]);
                        vow_index = i;
                    }
                }
                txtlongest.Text = array[max_index];//output dispaly
                txtvowel.Text = array[vow_index];//output dispaly
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\write.txt");//Textfile write here
                sw.WriteLine("Converting in Lower ::" + txtdisplay.Text);//Textfile write here
                sw.WriteLine("First Word ::" + txtfirstword.Text);//Textfile write here
                sw.WriteLine("Last Word ::" + txtlastword.Text);//Textfile write here
                sw.WriteLine("Longest word ::" + txtlongest.Text);//Textfile write here
                sw.WriteLine("Longest Vowel Word ::" + txtvowel.Text);//Textfile write here
                sw.Close();
                MessageBox.Show("Text file is Created");//output display for message
            }

        }
        public int VowelCount(string sentence)//function for vowel count here
        {
            int vowels = 0;
            for (int i = 0; i < sentence.Length - 1; i++)
            {
                if ((sentence[i] == 'a' || sentence[i] == 'e' || sentence[i] == 'i' || sentence[i] == 'o' || sentence[i] == 'u') || (sentence[i] == 'A' || sentence[i] == 'E' || sentence[i] ==
                'I' || sentence[i] == 'O' || sentence[i] == 'U'))
                {
                    vowels = vowels + 1;
                }

            }
            return vowels;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}