using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;

namespace OlxResearch
{
    class GenerateExcel
    {
        string[,,] data = new string[501, 42, 2];
        object[] dataAll = new object[15];
        bool[] check = new bool[6];
        string[] letters = { "A", "B", "C", "D", "E", "F" };
        string cat, category;
        Form1 formUp = new Form1();
        public GenerateExcel(object[] dataAll, Form1 formUp)
        {
            this.dataAll = dataAll;
            this.formUp = formUp;
        }
        public void Generate()
        {
            FileInfo file = new FileInfo(formUp.ReurnFileDialog);
            using (var fileExcel = new ExcelPackage(file))
            {
                var sheet = fileExcel.Workbook.Worksheets.Add("Kontakty z OLX");
                Check();
                Header(fileExcel, sheet);
                int numberLine = 2;

                for (int i = 0; i < 15; i++)
                {
                    if (dataAll[i] != null)
                    {
                        data = (string[,,])dataAll[i];
                        category = Category(i);
                        numberLine = GenerateFromCategory(fileExcel, sheet, numberLine);
                    }
                }
                fileExcel.Save();

            }

        }
        void Check()
        {
            check[0] = formUp.checkBox16.Checked;
            check[1] = formUp.checkBox17.Checked;
            check[2] = formUp.checkBox18.Checked;
            check[3] = formUp.checkBox19.Checked;
            check[4] = formUp.checkBox20.Checked;
            check[5] = true;
        }
        string Category(int i)
        {
            switch (i)
            {
                case 0:
                    cat = "Motoryzacja";
                    break;
                case 1:
                    cat = "Elektronika";
                    break;
                case 2:
                    cat = "Dla dzieci";
                    break;
                case 3:
                    cat = "Oddam za darmo";
                    break;
                case 4:
                    cat = "Nieruchomości";
                    break;
                case 5:
                    cat = "Moda";
                    break;
                case 6:
                    cat = "Sport i Hobby";
                    break;
                case 7:
                    cat = "Zamienię";
                    break;
                case 8:
                    cat = "Praca";
                    break;
                case 9:
                    cat = "Rolnictwo";
                    break;
                case 10:
                    cat = "Muzyka i Edukacja";
                    break;
                case 11:
                    cat = "Dom i Ogród";
                    break;
                case 12:
                    cat = "Zwierzęta";
                    break;
                case 13:
                    cat = "Usługi i Firmy";
                    break;
            }
            return cat;
        }
        void Header(ExcelPackage fileExcel, ExcelWorksheet sheet)
        {

            for (int i = 0; i < 6; i++)
            {
                if (check[0])
                {
                    sheet.Cells[letters[i] + 1].Value = "Imię";
                    check[0] = false;
                    continue;
                }
                if (check[1])
                {
                    sheet.Cells[letters[i] + 1].Value = "Telefon";
                    check[1] = false;
                    continue;
                }
                if (check[2])
                {
                    sheet.Cells[letters[i] + 1].Value = "Miasto";
                    check[2] = false;
                    continue;
                }
                if (check[3])
                {
                    sheet.Cells[letters[i] + 1].Value = "Województwo";
                    check[3] = false;
                    continue;
                }
                if (check[4])
                {
                    sheet.Cells[letters[i] + 1].Value = "Data ogłoszenia";
                    check[4] = false;
                    continue;
                }
                if (check[5])
                {
                    sheet.Cells[letters[i] + 1].Value = "Z kategorii";
                    check[5] = false;
                    continue;
                }

            }
            sheet.Cells["A1:E1"].Style.Font.Bold = true;
        }
        int GenerateFromCategory(ExcelPackage fileExcel, ExcelWorksheet sheet, int numberLine)
        {



            for (int i = 1; i <= 500; i++)
            {
                for (int j = 0; j < 42; j++)
                {
                    Check();
                    if (data[i, j, 0] != null || data[i, j, 1] != null || data[i, j, 2] != null || data[i, j, 3] != null || data[i, j, 4] != null)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (check[0])
                            {
                                sheet.Cells[letters[k] + numberLine].Value = data[i, j, 0];
                                check[0] = false;
                                continue;
                            }
                            if (check[1])
                            {
                                sheet.Cells[letters[k] + numberLine].Value = data[i, j, 1];
                                check[1] = false;
                                continue;
                            }

                            if (check[2])
                            {
                                sheet.Cells[letters[k] + numberLine].Value = data[i, j, 2];
                                check[2] = false;
                                continue;
                            }
                            if (check[3])
                            {
                                sheet.Cells[letters[k] + numberLine].Value = data[i, j, 3];
                                check[3] = false;
                                continue;
                            }
                            if (check[4])
                            {
                                sheet.Cells[letters[k] + numberLine].Value = data[i, j, 4];
                                check[4] = false;
                                continue;
                            }
                            if (check[5])
                            {
                                sheet.Cells[letters[k] + numberLine].Value = category;
                                check[5] = false;
                                continue;
                            }

                        }
                        numberLine++;
                    }
                   


                }

            }
            return numberLine;


        }
    }
}

