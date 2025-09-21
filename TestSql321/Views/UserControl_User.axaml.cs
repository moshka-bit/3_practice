using Avalonia.Controls;
using TestSql321.Data;
using TestSql321.Models;
using TestSql321.ViewModels;

namespace TestSql321.Views;

public partial class UserControl_User : UserControl
{
    public UserControl_User()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedUser = MainDataGridUsers.SelectedItem as User;

        if (selectedUser == null) return;

        UserVariableData.selectedUserInMainWindow = selectedUser;

        var parent = this.VisualRoot as Window;
        if (parent == null)
        {
            return;
        }

        var createAndChangeUserWindow = new CreateAndChangeUser();
        await createAndChangeUserWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        UserVariableData.selectedUserInMainWindow = null;

        var parent = this.VisualRoot as Window;
        if (parent == null)
        {
            return;
        }

        var createAndChangeUserWindow = new CreateAndChangeUser();
        await createAndChangeUserWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }

}