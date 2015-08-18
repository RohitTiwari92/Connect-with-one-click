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
    class readGroupFile
    {
     public   void read(ref List<string> grpname , ref List<string> path)
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
            int i = 0;
            string str,str1;
            for (int rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                str = (string)(range.Cells[rCnt, 1] as Excel.Range).Value2;
                str1 = (string)(range.Cells[rCnt, 2] as Excel.Range).Value2;
                grpname.Add(str);
                path.Add(str1);

            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            objcf.releaseObject(xlWorkSheet);
            objcf.releaseObject(xlWorkBook);
            objcf.releaseObject(xlApp);
        }
    }
}
