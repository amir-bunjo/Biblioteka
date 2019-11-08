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
    public static class Knjige
    {
        public static void Collect(ExcelWorksheet rawData, UnitOfWork unit)
        {
            for (int row = 2; row <= rawData.Dimension.Rows; row++)
            {
                int oldId = rawData.ReadInteger(row, 1);
                Knjiga k = new Knjiga
                {
                    Naslov = rawData.ReadString(row, 2),

                    Cijena = rawData.ReadDecimal(row, 6),
                    Izdavac = unit.Izdavaci.Get(Utility.izdavacDictionary[rawData.ReadInteger(row, 7)])
                };
                unit.Knjige.Insert(k);
                unit.Save();
                Utility.knjigaDictionary.Add(oldId, k.kId);
            }
        }
    }
}
