using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting_algorhitms_practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (StreamReader reader = new StreamReader("d:/rnd.txt"))
            {
                string str = reader.ReadLine();
                while(str!=null)
                {
                    textBox1.Text += str+Environment.NewLine;
                    str = reader.ReadLine();
                }
            }
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            string[] stringarray = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int[] intarray = new int[stringarray.Length];
            for (int i = 0; i < stringarray.Length; i++)
            {
                intarray[i] = (int)float.Parse(stringarray[i]);
            }
            //add switchcase selection of algorhitm to use
            //add elapsed time counter
            Sort.Quick(intarray, 0, intarray.Length);
            textBox1.Text = "";
            foreach(int item in intarray)
            {
                textBox1.Text += item.ToString() + Environment.NewLine;
            }
        }
    }
}
