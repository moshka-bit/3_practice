using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestSql321.Data;

namespace TestSql321.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public List<User> Users { get; set; }

        public List<Role> Roles { get; set; }

        public List<Login> Logins { get; set; }

        public List<Item> Items { get; set; }

        public List<Busket> Baskets { get; set; }

        public MainWindowViewModel()
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var usersFromDb = App.DbContext.Users.ToList();
            Users = usersFromDb;
            OnPropertyChanged(nameof(Users));

            var RolesFromDb = App.DbContext.Roles.ToList();
            Roles = RolesFromDb;
            OnPropertyChanged(nameof(Roles));

            var LoginsFromDb = App.DbContext.Logins.ToList();
            Logins = LoginsFromDb;
            OnPropertyChanged(nameof(Logins));

            var ItemsFromDb = App.DbContext.Items.ToList();
            Items = ItemsFromDb;
            OnPropertyChanged(nameof(Items));

            var BasketsFromDb = App.DbContext.Buskets.ToList();
            Baskets = BasketsFromDb;
            OnPropertyChanged(nameof(Baskets));
        }
    }
}
