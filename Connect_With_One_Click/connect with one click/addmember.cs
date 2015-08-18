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
using System.IO;

using System.Threading;
using System.Configuration;

namespace Connect_With_One_Click
{
    class addmember
    {
        public int check(string groupname,string type)
        {
            string path = @"d:\database\" + type;
            groupname = groupname + ".xlsx";
            string[] extensions = { "xlsx" };

          string[]  pathfiles = Directory.GetFiles(@path, "*.*", SearchOption.AllDirectories)
                .Where(f => extensions.Contains(f.Split('.').Last().ToLower())).ToArray();


          foreach (string s in pathfiles)
          {
              FileInfo obj = new FileInfo(@s);
              if (obj.Name.Equals(groupname))
              {
                  return 1;
              }


          }
          
            return 0;
        }
    }
}
