using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace OlxResearch
{
    public class Handling
    {
        string[] category = new string[15];
        ReturnLinks[] Links = new ReturnLinks[15];
        ReturnTel[] Tel = new ReturnTel[15];
        //string[,,] links = new string[15, 500, 42];
        //string[,,,] data = new string[15, 501, 42, 5];
        object[] linksAll = new object[15];
        object[] dataAll = new object[15];
        Form1 formUp;
        Form2 form2;
        public int numberOfCategories { get; private set; }

        public Handling(Form1 formUp, Form2 form2)
        {
            /* Można było również zrobić to przez publiczną właściwość w Form1 
               która by zwracała czy checkBox jest kliknięty */
            this.formUp = formUp;
            this.form2 = form2;
        }
        public void Start()
        {
            //Form2 form2 = new Form2();
            //form2.Show();
            //Thread thr2 = Thread.CurrentThread;
            //thr2 = new Thread(new ThreadStart(form2.Show));
            //thr2.
            // thr2.Start();
            Choice();
            CreateCategory();
            numberOfCategories = NumberOfCategories();
            LinkPages();
            GenerateExcel Generate = new GenerateExcel(dataAll, formUp);
            Generate.Generate();

            
        }
        private void LinkPages()
        {
            for (int i = 0; i < 15; i++)
            {
                if (category[i] != null)
                {
                    
                    linksAll[i] = Links[i].links_pages();
                    dataAll[i] = Tel[i].Return_data((string[,])linksAll[i]);
                    //Action<int> updateAction = new Action<int>((value) => form2.progressBar1.Value += numberOfCategories);
                    //formUp.progressBar1.Invoke(updateAction, 32);
                    Action<int> updateAction = new Action<int>((value) => form2.Proces(numberOfCategories));
                    form2.progressBar1.Invoke(updateAction, 32);
                    //form2.Proces(numberOfCategories);

                    //formUp.progressBar1.Increment(1);

                }

            }

        }
        private void CreateCategory()
        {
            int pages = int.Parse(formUp.textBox4.Text);
            
            for (int i = 0; i < 15; i++)
            {
                if (category[i] != null)
                {
                    Links[i] = new ReturnLinks(category[i], pages);
                    Tel[i] = new ReturnTel(pages, formUp);
                }

            }
            
        }
        private void Choice()
        {

            if (formUp.checkBox1.Checked)
                category[0] = "motoryzacja";
            if (formUp.checkBox2.Checked)
                category[1] = "elektronika";
            if (formUp.checkBox3.Checked)
                category[2] = "dla-dzieci";
            if (formUp.checkBox4.Checked)
                category[3] = "oddam-za-darmo";
            if (formUp.checkBox5.Checked)
                category[4] = "nieruchomosci";
            if (formUp.checkBox6.Checked)
                category[5] = "moda";
            if (formUp.checkBox7.Checked)
                category[6] = "sport-hobby";
            if (formUp.checkBox8.Checked)
                category[7] = "zamienie";
            if (formUp.checkBox9.Checked)
                category[8] = "praca";
            if (formUp.checkBox10.Checked)
                category[9] = "rolnictwo";
            if (formUp.checkBox11.Checked)
                category[10] = "muzyka-edukacja";
            if (formUp.checkBox12.Checked)
                category[11] = "dom-ogrod";
            if (formUp.checkBox13.Checked)
                category[12] = "zwierzeta";
            if (formUp.checkBox14.Checked)
                category[13] = "uslugi-firmy";
            if (formUp.checkBox15.Checked)
                category[14] = "all";
        }

        private int NumberOfCategories()
        {
            int i = 0;
            for(int j = 0; j < 15; j++)
            {
                if (this.category[j] != null)
                    i++;
            }
            i = 100 / i;
            
            return i;
        }
    }
}
