using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestSql321.Data;
using TestSql321.Models;

namespace TestSql321;

public partial class CreateAndChangeUser : Window
{
    public CreateAndChangeUser()
    {
        InitializeComponent();

        DataContext = new ViewModels.MainWindowViewModel();

        if (UserVariableData.selectedUserInMainWindow == null) return;

        FullNameText.Text = UserVariableData.selectedUserInMainWindow.FullName;
        DescriptionText.Text = UserVariableData.selectedUserInMainWindow.Description;
        PhoneNumberText.Text = UserVariableData.selectedUserInMainWindow.PhoneNumber;

        var viewModel = (ViewModels.MainWindowViewModel)DataContext;
        ComboRole.SelectedItem = viewModel.Roles
            .FirstOrDefault(r => r.RoleId == UserVariableData.selectedUserInMainWindow.RoleId);

        var login = App.DbContext.Logins
            .FirstOrDefault(l => l.UserId == UserVariableData.selectedUserInMainWindow.UserId);

        if (login != null)
        {
            Login1.Text = login.Login1;
            Password.Text = login.Password;
        }


    }
    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedRole = ComboRole.SelectedItem as Role;
        if (selectedRole == null) return;

        if (Login1.Text == null) return;
        if (Password.Text == null) return;

        if (UserVariableData.selectedUserInMainWindow != null)
        {
            var idUser = UserVariableData.selectedUserInMainWindow.UserId;
            var thisUser = App.DbContext.Users.FirstOrDefault(x => x.UserId == idUser);



            if (thisUser == null) return;

            thisUser.PhoneNumber = PhoneNumberText.Text;
            thisUser.Description = DescriptionText.Text;
            thisUser.FullName = FullNameText.Text;
            thisUser.RoleId = selectedRole.RoleId;

            var login = thisUser.Logins.FirstOrDefault();
            if (login != null)
            {
                login.Login1 = Login1.Text;
                login.Password = Password.Text;
            }
            else
            {
                var newLogin = new Login
                {
                    Login1 = Login1.Text,
                    Password = Password.Text,
                    UserId = thisUser.UserId
                };
                App.DbContext.Logins.Add(newLogin);
            }
        }
        else
        {
            var newUser = new User() { 
                FullName = FullNameText.Text,
                Description = DescriptionText.Text,
                PhoneNumber = PhoneNumberText.Text,
                RoleId = selectedRole.RoleId,


            };
            App.DbContext.Users.Add(newUser);
            App.DbContext.SaveChanges();

            var newLogin = new Login()
            {
                Login1 = Login1.Text,
                Password = Password.Text,
                UserId = newUser.UserId
            };
            App.DbContext.Logins.Add(newLogin);
        }
        App.DbContext.SaveChanges();
        this.Close();
    }
}