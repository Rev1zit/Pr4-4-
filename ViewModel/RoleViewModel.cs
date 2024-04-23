using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лб4.Model;

namespace Лб4.ViewModel
{
    public class RoleViewModel
    {
        public ObservableCollection<Role> ListRole { get; set; } = new ObservableCollection<Role>();
        public RoleViewModel()
        {
            ListRole.Add(new Role(1, "Директор"));
            ListRole.Add(new Role(2, "Бухгалтер"));
            ListRole.Add(new Role(3, "Менеджер"));
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var r in ListRole)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                }
            }
            return max;
        }
    }
}

