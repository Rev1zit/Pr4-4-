using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Лб4.Model;
using Лб4.ViewModel;

namespace Лб4.View
{

    /// <summary>
    /// Логика взаимодействия для WindowsNewRole.xaml
    /// </summary>
    public partial class WindowsNewRole : Window
    {
        RoleViewModel vmRole;
        Role role;
        public WindowsNewRole(RoleViewModel vmRole)
        {
            InitializeComponent();
            this.vmRole = vmRole;
        }
        public void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            role = new Role(0, " ");
            vmRole.ListRole.Add(role);
        }
    }
}
