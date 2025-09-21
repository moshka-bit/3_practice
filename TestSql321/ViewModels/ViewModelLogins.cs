using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using TestSql321.Data;

namespace TestSql321.ViewModels
{
    public class ViewModelLogins : ObservableObject
    {
        public List<Login> Logins { get; set; }

        public ViewModelLogins()
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var loginsFromDb = App.DbContext.Logins.ToList();
            Logins = loginsFromDb;
            OnPropertyChanged(nameof(Logins));
        }
    }
}



