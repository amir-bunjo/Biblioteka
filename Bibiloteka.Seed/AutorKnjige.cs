
using Biblioteka.DAL;
using Biblioteka.DAL.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Seeder
{
    public static class AutorKnjige
    {
        
        public static void Collect(ExcelWorksheet rawData, UnitOfWork unit)
        {
            for (int row = 2; row <= rawData.Dimension.Rows; row++)
            {
                unit.AutorKnjiga.Insert(new AutorKnjiga
                {
                    Autor = unit.Autori.Get(Utility.autorDictionary[rawData.ReadInteger(row, 2)]),
                    Knjiga = unit.Knjige.Get(Utility.knjigaDictionary[rawData.ReadInteger(row, 1)])
                });
            }
            unit.Save();
        }
    }
}
