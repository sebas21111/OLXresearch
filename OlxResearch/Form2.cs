using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace OlxResearch
{
    public partial class Form2 : Form
    {
        Form1 form1;
        int i;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            //this.sterowanie = sterowanie;
            this.form1 = form1;
            

        }

        public void Proces(int proces)
        {
            // Action<int> updateAction = new Action<int>((value) => progressBar1.Value += sterowanie.numberOfCategories);
            // progressBar1.Invoke(updateAction, 32);
            
            if(progressBar1.Value > 95)
            {
                i = 100 - progressBar1.Value;
                progressBar1.Value += i;
            }
            if (progressBar1.Value == 1)
                progressBar1.Value += proces - 1;
            else
                progressBar1.Value += proces;
            transparentLabel1.Text = progressBar1.Value.ToString()+"%";
            this.Refresh();
            if (progressBar1.Value == 100)
            {
                MessageBox.Show("Raport wygenerowany!","Gratulacje!");
                this.EndOperation();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.progressBar1.Value = 1;
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.thr.Abort();
            this.EndOperation();
        }
        void EndOperation()
        {
            this.Close();
            form1.label1.Enabled = true;
            form1.label2.Enabled = true;
            form1.label3.Enabled = true;
            form1.button1.Enabled = true;
            form1.button2.Enabled = true;
            form1.checkBox1.Enabled = true;
            form1.checkBox2.Enabled = true;
            form1.checkBox3.Enabled = true;
            form1.checkBox4.Enabled = true;
            form1.checkBox5.Enabled = true;
            form1.checkBox6.Enabled = true;
            form1.checkBox7.Enabled = true;
            form1.checkBox8.Enabled = true;
            form1.checkBox9.Enabled = true;
            form1.checkBox10.Enabled = true;
            form1.checkBox11.Enabled = true;
            form1.checkBox12.Enabled = true;
            form1.checkBox13.Enabled = true;
            form1.checkBox14.Enabled = true;
            form1.checkBox15.Enabled = true;
            form1.checkBox16.Enabled = true;
            form1.checkBox17.Enabled = true;
            form1.checkBox18.Enabled = true;
            form1.checkBox19.Enabled = true;
            form1.checkBox20.Enabled = true;
            form1.checkBox21.Enabled = true;
            form1.textBox1.Enabled = true;
            form1.textBox2.Enabled = true;
            form1.textBox3.Enabled = true;
            form1.textBox4.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void transparentLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
