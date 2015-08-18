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

namespace Connect_With_One_Click
{
    /// <summary>
     //Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            hiddenips();
            hideaddmember();
            groupdatagrid.Visibility = Visibility.Hidden;
            groupdatagrid.IsVisibleChanged += groupdatagrid_IsVisibleChanged;
           
        }
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void visibleips()
        {
            ipaddlable.Visibility = System.Windows.Visibility.Visible;
            ipadress.Visibility = System.Windows.Visibility.Visible;
            portno.Visibility = System.Windows.Visibility.Visible;
            portnolable.Visibility = System.Windows.Visibility.Visible;
            connectbutton.Visibility = System.Windows.Visibility.Visible;
        }
        private void hiddenips()
        {
            ipaddlable.Visibility = System.Windows.Visibility.Hidden;
            ipadress.Visibility = System.Windows.Visibility.Hidden;
            portno.Visibility = System.Windows.Visibility.Hidden;
            portnolable.Visibility = System.Windows.Visibility.Hidden;
            connectbutton.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            studentGrid.Visibility = Visibility.Hidden;
            groupdatagrid.Visibility = Visibility.Hidden;
            groupbuttonhide();
            visibleips();
            hideaddmember();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            studentGrid.Visibility = Visibility.Hidden;
            groupdatagrid.Visibility = Visibility.Hidden;
            hiddenips();
            hideaddmember();
            groupbuttonhide();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           
            groupdatagrid.Visibility = Visibility.Hidden;

            hiddenips();
            hideaddmember();
            groupbuttonhide();
            if (studentGrid.Items != null)
            {
                studentGrid.Items.Clear();
            }
          //  studentGrid.Visibility = Visibility.Visible;
            //===============================


            //===============================


        }
        List<string> grpname = new List<string>();
        List<string> grppath = new List<string>();
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            studentGrid.Visibility = Visibility.Hidden;
            groupdatagrid.Visibility = Visibility.Hidden;
            hiddenips();
            hideaddmember();
            grouplist.Items.Clear();
            if (grpname != null)
            {
                grpname.Clear();
                grppath.Clear();
            }
            readGroupFile objread = new readGroupFile();
            objread.read(ref grpname,ref grppath);
            foreach (string item in grpname)
            {                
                grouplist.Items.Add(item); 
            }
           
            groupbuttonshow();

        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            studentGrid.Visibility = Visibility.Hidden;
            groupdatagrid.Visibility = Visibility.Hidden;
            hiddenips();
            showaddmember();
            groupbuttonhide();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void addmember_Click(object sender, RoutedEventArgs e)
        {
            addmember objaddmem = new addmember();
            appendfile objappend = new appendfile();
           int res= objaddmem.check(combogroup.Text,combotype.Text);
           string pt;
           if (combotype.Text.Equals("Student"))
           {
               pt = @"d:\database\Student\" + combogroup.Text + ".xlsx";
           }
           else
           {
               pt = @"d:\database\Faculty\" + combogroup.Text + ".xlsx";
           }
         //  MessageBox.Show(pt);
          // MessageBox.Show(res.ToString());
            if(res==0)
            {
              //  MessageBox.Show("file create");
                createfile objcreate = new createfile();              
                objcreate.create(@pt, nametxt.Text, phonetxt.Text, emailtxt.Text, combotype.Text, combogroup.Text);
            }
            else
            {
                objappend.add(@pt, nametxt.Text, phonetxt.Text, emailtxt.Text, combotype.Text, combogroup.Text);
            }
        }
        private void hideaddmember()
        {
            combogroup.Visibility = Visibility.Hidden;
            name.Visibility = Visibility.Hidden;
            group.Visibility = Visibility.Hidden;
            email.Visibility = Visibility.Hidden;
            emailtxt.Visibility = Visibility.Hidden;
            nametxt.Visibility = Visibility.Hidden;
            phoneno.Visibility = Visibility.Hidden;
            phonetxt.Visibility = Visibility.Hidden;
            combotype.Visibility = Visibility.Hidden;
            type.Visibility = Visibility.Hidden;
            addmember.Visibility = Visibility.Hidden;
        }
        private void showaddmember()
        {
            combogroup.Visibility = Visibility.Visible;
            name.Visibility = Visibility.Visible;
            group.Visibility = Visibility.Visible;
            email.Visibility = Visibility.Visible;
            emailtxt.Visibility = Visibility.Visible;
            nametxt.Visibility = Visibility.Visible;
            phoneno.Visibility = Visibility.Visible;
            phonetxt.Visibility = Visibility.Visible;
            combotype.Visibility = Visibility.Visible;
            type.Visibility = Visibility.Visible;
            addmember.Visibility = Visibility.Visible;
        }

        private void showmember_Click(object sender, RoutedEventArgs e)
        {
           
            if (grouplist.SelectedIndex > 0)
            {
                groupbuttonhide();
              
              // MessageBox.Show(grouplist.SelectedIndex.ToString());
                groupdatagrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Select One Group");
            }
     

        }

        void groupdatagrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
            var items = new List<sh>();
            readfiles rdfile = new readfiles();
            List<string> name = new List<string>();
            List<string> phone = new List<string>();
            List<string> email = new List<string>();
            List<string> gname = new List<string>();
           
                rdfile.read(@grppath[grouplist.SelectedIndex], ref name, ref phone, ref email, ref gname);
                for (int i = 0; i < name.Count; i = i + 1)
                {
                    items.Add(new sh(name[i], phone[i], email[i], gname[i]));

                }

                var grid = sender as System.Windows.Controls.DataGrid;
                grid.ItemsSource = items;
                
        }

        private void grouplist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void delete_group_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void groupbuttonshow()
        {
            grouplist.Visibility = Visibility.Visible;
            showmember.Visibility = Visibility.Visible;
            delete_group.Visibility = Visibility.Visible;
        }
        private void groupbuttonhide()
        {
            grouplist.Visibility = Visibility.Hidden;
            showmember.Visibility = Visibility.Hidden;
            delete_group.Visibility = Visibility.Hidden;
        }

        private void groupdatagrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
        }

        private void groupdatagrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }

    class sh
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string GroupName { get; set; }
        public sh(string name1, string phone1,string email1,string gname)
        {
            this.name = name1;
            this.email = email1;
            this.phone =phone1 ;
            this.GroupName = gname;
        }
    }
}
