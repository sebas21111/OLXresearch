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
        string fileName;
        public GenerateExcel(string[,,] data)
        {
            this.data = data;
        }

        public void Generate()
        {
            int numberLine = 2;
            Console.WriteLine("Podaj nazwę pliku w którym ma zostać zapisany raport: ");
            fileName = Console.ReadLine();
            FileInfo file = new FileInfo(@fileName + ".xlsx");




            using (var fileExcel = new ExcelPackage(file))
            {
                var sheet = fileExcel.Workbook.Worksheets.Add("Kontakty z OLX");
                sheet.Cells["A" + 1].Value = "Imię";
                sheet.Cells["B" + 1].Value = "Telefon";
                sheet.Cells["C" + 1].Value = "Miasto";
                sheet.Cells["D" + 1].Value = "Województwo";
                sheet.Cells["E" + 1].Value = "Data ogłoszena";
                sheet.Cells["A1:E1"].Style.Font.Bold = true;
                for (int i = 1; i <= 500; i++)
                {
                    for (int j = 0; j < 42; j++)
                    {
                        if (data[i, j, 0] != null && data[i, j, 1] != null)
                        {
                            sheet.Cells["A" + numberLine].Value = data[i, j, 0];
                            sheet.Cells["B" + numberLine].Value = data[i, j, 1];
                            sheet.Cells["C" + numberLine].Value = data[i, j, 2];
                            sheet.Cells["D" + numberLine].Value = data[i, j, 3];
                            sheet.Cells["E" + numberLine].Value = data[i, j, 4];
                            numberLine++;

                        }
                    }
                }
                fileExcel.Save();
            }

        }

    }
}
