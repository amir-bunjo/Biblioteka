using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Biblioteka.Seeder
{
    public static class Utility
    {
        public static Dictionary<int, int> autorDictionary = new Dictionary<int, int>();
        public static Dictionary<int, int> knjigaDictionary = new Dictionary<int, int>();
        public static Dictionary<int, int> izdavacDictionary = new Dictionary<int, int>();

        public static string ReadString(this ExcelWorksheet sht, int row, int col) => sht.Cells[row, col].Value.ToString().Trim();

        public static int ReadInteger(this ExcelWorksheet sht, int row, int col) => int.Parse(sht.ReadString(row, col));

        public static DateTime ReadDate(this ExcelWorksheet sht, int row, int col) => DateTime.Parse(sht.ReadString(row, col));

        public static bool ReadBool(this ExcelWorksheet sht, int row, int col) => sht.ReadString(row, col) == "-1";

        public static decimal ReadDecimal(this ExcelWorksheet sht, int row, int col) => decimal.Parse(sht.ReadString(row, col));
    }
}
