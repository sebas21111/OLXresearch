using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebClient;

namespace olx
{
    class ReturnLinks
    {
        int position, link100_value, j, pages;
        string[,] links = new string[500, 42];
        string index, link100, category;
        public ReturnLinks(string category, int pages)
        {
            this.category = category;
            this.pages = pages;
        }
        public string[,] links_pages()
        {
            for (int i = 1; i <= this.pages; i++)
            {
                links_page(i);
            }

            return links;
        }
        private void links_page(int id_page)
        {
            position = 0;
            using (var client = new WebClient())
            {
                index = client.DownloadString("http://www.olx.pl/" + category + "?page=" + id_page);
            }
            for (int i = 0; i < 84; i++)
            {
                position = index.IndexOf("http://olx.pl/oferta", position + 1);

                if (i % 2 == 0)
                {
                    j = i / 2;
                    link100 = index.Substring(position, 400);

                    link100_value = link100.IndexOf("\"", 0);
                    links[id_page, j] = link100.Substring(0, link100_value);
                }

            }
        }
    }
}
