using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace olx
{
    static class ChoiceCategory
    {
        static int category;
        static int pages;
        static string choice;
        static bool result;

        static public int Choice_pages()
        {
            Console.WriteLine("Ilość stron: ");
            while (!(result = int.TryParse(Console.ReadLine(), out pages)) || !(pages >= 1 && pages <= 500))
            {
                Console.WriteLine("Podana wartość musi być liczbą z przedziału 1 - 500");
                Console.WriteLine("Ilość stron: ");
            }

            return pages;

        }

        static public string ChoiceCat()
        {
            Console.WriteLine("Kategoria:");
            Console.WriteLine("1. Motoryzacja");
            Console.WriteLine("2. Elektronika");
            Console.WriteLine("3. Dla dzieci");
            Console.WriteLine("4. Oddam za darmo");
            Console.WriteLine("5. Nieruchomości");
            Console.WriteLine("6. Moda");
            Console.WriteLine("7. Sport i Hobby");
            Console.WriteLine("8. Zamienię");
            Console.WriteLine("9. Praca");
            Console.WriteLine("10. Rolnictwo");
            Console.WriteLine("11. Muzyka i Edukacja");
            Console.WriteLine("12. Dom i Ogród");
            Console.WriteLine("13. Zwierzęta");
            Console.WriteLine("14. Usługi i Firmy");
            Console.WriteLine("15. Wszystko");
            Console.WriteLine();
            Console.WriteLine("Wybierz: ");
            while (!(result = int.TryParse(Console.ReadLine(), out category)) || !(category >= 1 && category <= 15))
            {
                Console.WriteLine("Podana wartość musi być liczbą z przedziału 1 - 15");
                Console.WriteLine("Wybierz: ");
            }
            switch (category)
            {
                case 1:
                    choice = "motoryzacja";
                    break;
                case 2:
                    choice = "elektronika";
                    break;
                case 3:
                    choice = "dla-dzieci";
                    break;
                case 4:
                    choice = "oddam-za-darmo";
                    break;
                case 5:
                    choice = "nieruchomosci";
                    break;
                case 6:
                    choice = "moda";
                    break;
                case 7:
                    choice = "sport-hobby";
                    break;
                case 8:
                    choice = "zamienie";
                    break;
                case 9:
                    choice = "praca";
                    break;
                case 10:
                    choice = "rolnictwo";
                    break;
                case 11:
                    choice = "myzuka-edukacja";
                    break;
                case 12:
                    choice = "dom-ogrod";
                    break;
                case 13:
                    choice = "zwierzeta";
                    break;
                case 14:
                    choice = "uslugi-firmy";
                    break;
                case 15:
                    choice = "all";
                    break;
            }
            return choice;
        }

    }
}
