using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebClient;
using System.Globalization;
using System.Windows.Forms;

namespace OlxResearch
{
    class ReturnTel
    {

        string[,,] data = new string[501, 42, 5];
        string tel, index, tel100, name100, place100, place200, date100;
        int positionName, positionTel, positionPlace1, positionPlace2, positionDate, pages;
        TextInfo bigLetters = CultureInfo.CurrentCulture.TextInfo;
        Form1 formUp;

        public ReturnTel(int pages, Form1 formUp)
        {
            this.pages = pages;
            this.formUp = formUp;
            
        }

        public string[,,] Return_data(string[,] links)
        {
            positionName = 0;
            positionTel = 0;
            positionPlace1 = 0;
            positionPlace2 = 0;
            positionDate = 0;
            using (var client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
                for (int i = 1; i <= this.pages; i++)
                {
                    for (int j = 0; j < 42; j++)
                    {

                        if (links[i, j] != null)

                            index = client.DownloadString(links[i, j]);

                        if (links[i, j] != null)
                        {
                            if(formUp.checkBox16.Checked)
                                RName(i, j);
                            if (formUp.checkBox18.Checked)
                                RPlace1(i, j);
                            if (formUp.checkBox19.Checked)
                                RPlace2(i, j);
                            if (formUp.checkBox20.Checked)
                                RDate(i, j);
                            if (formUp.checkBox17.Checked)
                                RTel(i, j);
                        }
                    }

                }
            }


            return data;
        }

        void RName(int i, int j)
        {
            positionName = index.IndexOf("<span class=\"block color-5 brkword xx-large\">", 0);
            if (positionName > 0)
            {
                positionName += 45;
                name100 = index.Substring(positionName, 30);
                positionName = name100.IndexOf("<", 0);
            }
            if (positionName > 0)
                data[i, j, 0] = bigLetters.ToTitleCase(name100.Substring(0, positionName));
        }
        void RTel(int i, int j)
        {
            positionTel = index.IndexOf("'path':'phone', 'id':'", 0);
            if (positionTel > 0)
            {
                positionTel += 22;
                tel100 = index.Substring(positionTel, 15);
                positionTel = tel100.IndexOf("'", 0);
            }
            if (positionTel > 0)
            {
                tel = tel100.Substring(0, positionTel);
                using (var client = new WebClient())
                {
                    index = client.DownloadString("http://olx.pl/ajax/misc/contact/phone/" + tel + "/");
                }
                tel100 = index.Substring(10);
                positionTel = tel100.IndexOf("\"");
                if (tel100[0] != '<')
                    data[i, j, 1] = tel100.Substring(0, positionTel);
            }
        }

        void RPlace1(int i, int j)
        {
            positionPlace1 = index.IndexOf("city:", 0);
            if (positionPlace1 > 0)
            {
                positionPlace1 += 5;
                place100 = index.Substring(positionPlace1, 35);
                positionPlace1 = place100.IndexOf("'", 0);
            }
            if (positionPlace1 > 0)
                data[i, j, 2] = bigLetters.ToTitleCase(place100.Substring(0, positionPlace1).Trim());
        }

        void RPlace2(int i, int j)
        {
            positionPlace2 = index.IndexOf("region:", 0);
            if (positionPlace2 > 0)
            {
                positionPlace2 += 7;
                place200 = index.Substring(positionPlace2, 30);
                positionPlace2 = place200.IndexOf("'", 0);
            }
            if (positionPlace2 > 0)
                data[i, j, 3] = bigLetters.ToTitleCase(place200.Substring(0, positionPlace2).Trim());
        }

        void RDate(int i, int j)
        {
            positionDate = index.IndexOf("class=\"pdingleft10 brlefte5\"", 0);
            if (positionDate > 0)
            {
                positionDate += 28;
                date100 = index.Substring(positionDate, 500);
                positionDate = date100.IndexOf(",", 0);
                date100 = date100.Substring((positionDate + 1), 20);
                positionDate = date100.IndexOf(",", 0);
            }
            if (positionDate > 0)
                data[i, j, 4] = date100.Substring(0, positionDate).Trim();
        }


    }
}
