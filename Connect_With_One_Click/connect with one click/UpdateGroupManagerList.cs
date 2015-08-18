using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace Connect_With_One_Click
{
    class UpdateGroupManagerList
    {
       public void update(string gname,string path)
        {
            createfile objcf = new createfile();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            object missing = System.Reflection.Missing.Value;



            xlApp = new Excel.Application();

            xlWorkBook = xlApp.Workbooks.Open(@"d:\database\Group.xlsx", 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, true, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            xlWorkSheet.Cells[range.Rows.Count + 1, 1] = gname;
            xlWorkSheet.Cells[range.Rows.Count + 1, 2] = path;
            xlWorkBook.Save();

            xlWorkBook.Close();

            xlApp.Quit();

            objcf.releaseObject(xlWorkSheet);
            objcf.releaseObject(xlWorkBook);
            objcf.releaseObject(xlApp);

        }
    }
}
