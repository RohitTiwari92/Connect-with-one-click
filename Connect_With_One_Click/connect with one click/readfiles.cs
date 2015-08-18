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
    class readfiles
    {
        public void read(string path, ref List<string> name, ref List<string> phone, ref List<string> email,ref List<string> gname)
        {
            createfile objcf = new createfile();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            object missing = System.Reflection.Missing.Value;



            xlApp = new Excel.Application();

            xlWorkBook = xlApp.Workbooks.Open(path, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, true, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
           
            string str,str1,str2,str3;
            for (int rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                str = (string)(range.Cells[rCnt, 1] as Excel.Range).Value2;
                str1 = (string)((range.Cells[rCnt, 2] as Excel.Range).Value2).ToString();
                str2 = (string)(range.Cells[rCnt, 3] as Excel.Range).Value2;
                str3 = (string)(range.Cells[rCnt, 5] as Excel.Range).Value2;
                name.Add(str);
                phone.Add(str1);
                email.Add(str2);
                gname.Add(str3);
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            objcf.releaseObject(xlWorkSheet);
            objcf.releaseObject(xlWorkBook);
            objcf.releaseObject(xlApp);
        }
    }
}
