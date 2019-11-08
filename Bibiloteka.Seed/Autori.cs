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
    public static class Autori
    {

        public static void Collect(ExcelWorksheet rawData, UnitOfWork unit)
        {
            for (int row = 2; row <= rawData.Dimension.Rows; row++)
            {
                int oldId = rawData.ReadInteger(row, 1);
                Autor a = new Autor
                {
                    Ime = rawData.ReadString(row, 2),
                    Email = rawData.ReadString(row, 6)
                };
                unit.Autori.Insert(a);
                unit.Save();
                Utility.autorDictionary.Add(oldId, a.aId);
            }
        }
    }
}
