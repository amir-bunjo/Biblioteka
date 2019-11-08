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
    public static class Izdavaci
    {
        public static void Collect(ExcelWorksheet rawData, UnitOfWork unit)
        {
            for (int row = 2; row <= rawData.Dimension.Rows; row++)
            {
                int oldId = rawData.ReadInteger(row, 1);
                Izdavac i = new Izdavac
                {
                    Ime = rawData.ReadString(row, 2),
                    //country city zipcode
                    Sjediste = rawData.ReadString(row, 6) + rawData.ReadString(row, 5) + rawData.ReadString(row, 4)

                };
                unit.Izdavaci.Insert(i);
                unit.Save();
                Utility.izdavacDictionary.Add(oldId, i.Id);
            }
        }
    }
}
