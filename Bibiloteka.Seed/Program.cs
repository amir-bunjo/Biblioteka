using Biblioteka.DAL;
using Biblioteka.Seeder;
using OfficeOpenXml;
using System;
using System.IO;

namespace Bibiloteka.Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            FileInfo file = new FileInfo(@"C:\Library.xlsx");
            using (ExcelPackage package = new ExcelPackage(file))
            {
                using (UnitOfWork unit = new UnitOfWork())
                {

                   // unit.Context.Database.EnsureDeleted(); 
                  //  unit.Context.Database.EnsureCreated();  command dont work on this version,explore more

                  
                    Izdavaci.Collect(package.Workbook.Worksheets["Publishers"], unit);
                    Console.WriteLine("Publishers seeded, pres any key to continue loading books");
                    Console.ReadKey();
                    Knjige.Collect(package.Workbook.Worksheets["Books"], unit);
                    Console.WriteLine("Books seeded, pres any key to continue loading authors");
                    Console.ReadKey();
                    Autori.Collect(package.Workbook.Worksheets["Authors"], unit);
                    Console.WriteLine("Authors seeded, pres any key to continue loading autorbooks");
                    Console.ReadKey();
                    AutorKnjige.Collect(package.Workbook.Worksheets["AuthBooks"], unit);

                }
            }
        }
    }
}
