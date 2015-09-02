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
            comboBox1.SelectedIndex = 0;
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
            DateTime timer = DateTime.Now;
            Sort.swapsDone = 0;
            switch (comboBox1.Items[comboBox1.SelectedIndex].ToString())
            {
                case "Quick":
                    {
                        Sort.Quick(intarray, 0, intarray.Length-1);
                        break;
                    }
                case "Bubble":
                    {
                        Sort.Bubble(intarray);
                        break;
                    }
                case "Cocktail":
                    {
                        Sort.Cocktail(intarray);
                        break;
                    }
                case "Gnome":
                    {
                        Sort.Gnomesort(intarray);
                        break;
                    }
                case "Comb":
                    {
                        Sort.Comb(intarray);
                        break;
                    }
                case "Odd-even":
                    {
                        Sort.OddEven(intarray);
                        break;
                    }
                case "Selection":
                    {
                        Sort.Selection(intarray);
                        break;
                    }
                case "Heapsort":
                    {
                        Sort.HeapSort(intarray);
                        break;
                    }
                case "Smoothsort":
                    {
                        //Sort.Smoothsort(intarray);
                        break;
                    }
                case "Insertion":
                    {
                        //Sort.Insertion(intarray);
                        break;
                    }
                case "Shellsort":
                    {
                        //Sort.Shellsort(intarray);
                        break;
                    }
                case "Tree sort":
                    {
                        //Sort.TreeSort(intarray);
                        break;
                    }
                case "Merge sort":
                    {
                        //Sort.MergeSort(intarray);
                        break;
                    }
                case "Radix LSD sort":
                    {
                        //Sort.RadixLSD(intarray);
                        break;
                    }
                case "Radix MSD sort":
                    {
                        //Sort.RadixMSD(intarray);
                        break;
                    }
                case "Bucket sort":
                    {
                        //Sort.BucketSort(intarray);
                        break;
                    }
                case "Introsort":
                    {
                        //Sort.Introsort(intarray);
                        break;
                    }
                case "Timsort":
                    {
                        //Sort.Timsort(intarray);
                        break;
                    }
                default:
                    { break; }
            }
            TimeSpan eta = DateTime.Now - timer;
            textBox1.Text = "";
            timeelapsed.Text = "sorting " + intarray.Length.ToString() + " items: " + Sort.swapsDone.ToString()+" swaps done, "
                + eta.Minutes.ToString() +"m"+ eta.Seconds.ToString()+"s"+ eta.Milliseconds.ToString()+"ms"; 
            foreach(int item in intarray)
            {
                textBox1.Text += item.ToString() + Environment.NewLine;
            }
        }
    }
}
