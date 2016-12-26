using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace arraySample
{
    public partial class Form1 : Form
    {
        Inst inst = null; // define inst class
        public Form1()
        {
            InitializeComponent();
            inst = new Inst(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inst.process();
            printResult();
        }

        public ListBox getListBox()
        {
            return this.listBox1;
        }
        private void printResult()
        {
            for (int j = 0; j < 15; j++)
            {
                try
                {
                    listBox1.Items.Add(String.Concat("index = ", Convert.ToString(j)," = ", Convert.ToString(inst.ar[j])));
                }
                catch (NullReferenceException e)
                {
                    // MessageBox.Show("Null exception");
                }
            }

            for (int j = 15; j < 30; j++)
            {
                try
                {
                    listBox2.Items.Add(String.Concat("index = ", Convert.ToString(j), " = ", Convert.ToString(inst.ar[j])));
                }
                catch (NullReferenceException e)
                {
                    // MessageBox.Show("Null exception");
                }
            }
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------
    // it class proposed for moving elements "inside" one array;
    public class Inst
    {
        // it handles 15 elements in one array
        public int[] ar = new int[30]; //  three dimensioned

        int neg_ind = 0;
        int nul_ind = 0;
        int pos_ind = 0;
        Form form;
        ListBox list;

        public Inst(Form form)
        {
            // constructor
            // ar.Initialize(); // init array
            for (int i = 0; i < 30; i++)
            {
                ar[i] = 0;
            }
            ar[0] = -1;
            ar[1] = 15;
            ar[2] = 0;
            ar[3] = 10;
            ar[4] = 5;
            ar[5] = -7;
            ar[6] = -8;
            ar[7] = 0;
            ar[8] = 0;
            ar[9] = 2;
            ar[10] = 1;
            ar[11] = 2;
            ar[12] = 0;
            ar[13] = 1;
            ar[14] = -1;
            this.form = form;
        }

        public void setListBox(ListBox box)
        {
            this.list = box;
        }

        
        public void process()
        {
            placeNegatives();
            placeNulls();
            placePositives();

            printResult();
        }

        // 0:14 = source
        // 15:30 = neg
        // 31:46 = nul
        // 47:61 = pos

        private void printResult()
        {
            for (int j = 0; j < 31; j++)
            {
                try
                {
                    list.Items.Add(String.Concat("index = ", Convert.ToString(j), Convert.ToString(ar[j])));
                }
                catch (NullReferenceException e)
                {
                    // MessageBox.Show("Null exception");
                }
            }
        }
        private void placeNegatives()
        {
            //15-30
            neg_ind = 15;
            int elem = 0;
            for (int j = 0; j < 15; j++)
            {
                elem = (int)ar.GetValue(j);
                if (elem < 0) 
                {
                    ar.SetValue(elem, neg_ind);
                    neg_ind++;
                }
            }
            // MessageBox.Show(String.Concat("negative index = ",Convert.ToString(neg_ind)));
        }
        private void placeNulls()
        {
            //15-30
            nul_ind = neg_ind;

            int elem = 0;
            for (int j = 0; j < 15; j++)
            {
                elem = (int)ar.GetValue(j);
                if (elem == 0)
                {
                    ar.SetValue(elem, nul_ind);
                    nul_ind++;
                }
            }
            MessageBox.Show(String.Concat("null index = ",Convert.ToString(nul_ind)));
        }
        private void placePositives()
        {
            //15-30
            pos_ind = nul_ind;

            int elem = 0;
            for (int j = 0; j < 15; j++)
            {
                elem = (int)ar.GetValue(j);
                if (elem > 0)
                {
                    ar.SetValue(elem, pos_ind);
                    pos_ind++;
                }
            }
            MessageBox.Show(String.Concat("pos index = ", Convert.ToString(pos_ind)));
        }
    }
}
