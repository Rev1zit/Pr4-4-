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
using System.Windows.Shapes;
using Лб4.Model;

namespace Лб4.View
{
    /// <summary>
    /// Логика взаимодействия для WindowsNewEmployee.xaml
    /// </summary>
    public partial class WindowsNewEmployee : Window
    {
        private int id;
        private string lastName;
        private string firstName;
        private Role selectedRole;
        private DateTime birthday;
        public int Id { get { return id; } }
        public string LastName { get { return lastName; } }
        public string FirstName { get { return firstName; } }
        public Role SelectedRole { get { return selectedRole; } }
        public DateTime Birthday { get { return birthday; } }

        public WindowsNewEmployee()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            Role selectedRole = (Role)CbRole.SelectedItem;

            if (selectedRole == null)
            {
                MessageBox.Show("Выберите должность.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbLastName.Text) || string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MessageBox.Show("Введите имя и фамилию.");
                return;
            }
            lastName = TbLastName.Text;
            firstName = TbFirstName.Text;
            selectedRole = (Role)CbRole.SelectedItem;
            birthday = ClBirthday.SelectedDate ?? DateTime.Now;
            DialogResult = true;
        }
    }
}
