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
    class createfile
    {
        public void create(string path, string name, string phoneno, string Email, string type, string gname)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object missing = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(missing);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);     
             xlWorkBook.SaveAs(@path,
             Excel.XlFileFormat.xlOpenXMLWorkbook, missing, missing,
             false, false, Excel.XlSaveAsAccessMode.xlNoChange,
             missing, missing, missing, missing, missing);
             xlApp.Quit();

             releaseObject(xlWorkSheet);
             releaseObject(xlWorkBook);
             releaseObject(xlApp);
             MessageBox.Show("New Group Created");        
              //============================
             
             xlApp = new Excel.Application();

             xlWorkBook = xlApp.Workbooks.Open(path, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, true, 0, true, 1, 0);
             xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
             




             //  MessageBox.Show(_lastRow.ToString());
             xlWorkSheet.Cells[1, 1] = name;
             xlWorkSheet.Cells[ 1, 2] = phoneno;
             xlWorkSheet.Cells[ 1, 3] = Email;
             xlWorkSheet.Cells[ 1, 4] = type;
             xlWorkSheet.Cells[ 1, 5] = gname;


             xlWorkBook.Save();

             xlWorkBook.Close();

             xlApp.Quit();
              //============================

             UpdateGroupManagerList updatem = new UpdateGroupManagerList();
             updatem.update(gname,path);



            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
           // MessageBox.Show("New Group Created");

        }
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
