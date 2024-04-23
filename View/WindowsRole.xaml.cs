using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для WindowsRole.xaml
    /// </summary>
    public partial class WindowsRole : Window
    {
        RoleViewModel vmRole;
        public WindowsRole()
        {
            InitializeComponent();
            RoleViewModel vmPerson = new RoleViewModel();
            lvRole.ItemsSource = vmPerson.ListRole;
            vmRole = new RoleViewModel();
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowsNewRole wnRole = new WindowsNewRole(vmRole)
            {
                Title = "Новая должность",
                Owner = this
            };

            int maxIdRole = vmRole.MaxId() + 1;
            if (vmRole.ListRole.Count == 0)
            {
                maxIdRole = 1;
            }

            Role role = new Role(maxIdRole, "");
            wnRole.DataContext = role;
            if (wnRole.ShowDialog() == true)
            {
                vmRole.ListRole.Add(role);
                lvRole.ItemsSource = null;
                lvRole.ItemsSource = vmRole.ListRole;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowsNewRole wnRole = new WindowsNewRole(vmRole)
            {
                Title = "Редактирование должности",
                Owner = this
            };
            Role role = lvRole.SelectedItem as Role;
            if (role != null)
            {
                Role tempRole = role.ShallowCopy();
                wnRole.DataContext = tempRole;
                if (wnRole.ShowDialog() == true)
                {
                    // сохранение данных
                    role.NameRole = tempRole.NameRole;
                    lvRole.ItemsSource = null;
                    lvRole.ItemsSource = vmRole.ListRole;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Role role = (Role)lvRole.SelectedItem;
            if (role != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " + 
                role.NameRole, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmRole.ListRole.Remove(role);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
