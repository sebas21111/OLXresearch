using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlxResearch
{
    class Handling //: Form1
    {
        string[] category = new string[15];
        ReturnLinks[] Links = new ReturnLinks[15];
        string[,,] links = new string[15, 500, 42];
        Form1 formUp;

        public Handling(Form1 formUp)
        {
            this.formUp = formUp;
        }
        public void Start()
        {
            
            Choice();
            CreateCategory();
            LinkPages();
          
        }
        private void LinkPages()
        {
            for (int i = 0; i < 15; i++)
            {
                if(category[i] != null)
                links = Links[i].links_pages();
            }
            
        }
        private void CreateCategory()
        {
            for(int i = 0; i <15; i++)
            {
                if (category[i] != null)
                    {
                    Links[i] = new ReturnLinks(category[i], 2, i);
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
        

    }
}
