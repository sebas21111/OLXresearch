using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace OlxResearch
{
    public partial class Form1 : Form
    {
        internal Thread thr;
        public string ReurnFileDialog
        {
            get
            {
                return saveFileDialog1.FileName;
            }
            
        }
        public Form1()
        {
            InitializeComponent();
           
        }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = "Raport.xlsx";
            saveFileDialog1.Title = "Zapisywanie raportu";
            saveFileDialog1.DefaultExt = ".xlsx";
            saveFileDialog1.ShowDialog();
            CheckGeneruj();
        }

        private void CheckGeneruj()
        {
            if (saveFileDialog1.Title == "Zapisywanie raportu")
            {
                if (checkBox1.Checked ||
                   checkBox2.Checked ||
                   checkBox3.Checked ||
                   checkBox4.Checked ||
                   checkBox5.Checked ||
                   checkBox6.Checked ||
                   checkBox7.Checked ||
                   checkBox8.Checked ||
                   checkBox9.Checked ||
                   checkBox10.Checked ||
                   checkBox11.Checked ||
                   checkBox12.Checked ||
                   checkBox13.Checked ||
                   checkBox14.Checked ||
                   checkBox15.Checked
                 )
                {
                    if (checkBox16.Checked ||
                        checkBox17.Checked ||
                        checkBox18.Checked ||
                        checkBox19.Checked ||
                        checkBox20.Checked ||
                        checkBox21.Checked
                        )
                    {
                        button2.Enabled = true;
                    }
                    else
                    {
                        button2.Enabled = false;
                    }
                }
                else
                {
                    button2.Enabled = false;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int pages = 0;
            bool result = int.TryParse(textBox4.Text, out pages);
            if (result == false)
            {
                MessageBox.Show("Podaj prawidłową ilość stron", "Uwaga");
            }
            else
            {
                if (pages > 500)
                {
                    MessageBox.Show("Podaj ilość stron w przedziale <1;500>", "Uwaga");
                }
                else {
                    Form2 form2 = new Form2(this);
                    Handling sterowanie = new Handling(this, form2);
                    thr = new Thread(sterowanie.Start);
                    thr.Start();
                    //sterowanie.Start();

                    form2.Show();
                    //form2.Proces();
                    label1.Enabled = false;
                    label2.Enabled = false;
                    label3.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox3.Enabled = false;
                    checkBox4.Enabled = false;
                    checkBox5.Enabled = false;
                    checkBox6.Enabled = false;
                    checkBox7.Enabled = false;
                    checkBox8.Enabled = false;
                    checkBox9.Enabled = false;
                    checkBox10.Enabled = false;
                    checkBox11.Enabled = false;
                    checkBox12.Enabled = false;
                    checkBox13.Enabled = false;
                    checkBox14.Enabled = false;
                    checkBox15.Enabled = false;
                    checkBox16.Enabled = false;
                    checkBox17.Enabled = false;
                    checkBox18.Enabled = false;
                    checkBox19.Enabled = false;
                    checkBox20.Enabled = false;
                    checkBox21.Enabled = false;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                checkBox16.Checked = true;
                checkBox17.Checked = true;
                checkBox18.Checked = true;
                checkBox19.Checked = true;
                checkBox20.Checked = true;
            }
            else
            {
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
                checkBox20.Checked = false;
            }
            CheckGeneruj();
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;
                checkBox10.Checked = true;
                checkBox11.Checked = true;
                checkBox12.Checked = true;
                checkBox13.Checked = true;
                checkBox14.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
            }
            CheckGeneruj();
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                label1.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label1.Visible = false;
                textBox1.Visible = false;
            }
            CheckGeneruj();
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked ==true)
            {
                label2.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox2.Visible = false;
            }
            CheckGeneruj();
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                label3.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                label3.Visible = false;
                textBox3.Visible = false;
            }
            CheckGeneruj();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            CheckGeneruj();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
