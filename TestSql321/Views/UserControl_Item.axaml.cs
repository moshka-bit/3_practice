using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestSql321.Data;
using TestSql321.Models;
using TestSql321.ViewModels;

namespace TestSql321;

public partial class UserControl_Item : UserControl
{
    public UserControl_Item()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedItem = MainDataGridItems.SelectedItem as Item;

        if (selectedItem == null) return;

        UserVariableData.selectedItemInMainWindow = selectedItem;

        var parent = this.VisualRoot as Window;
        if (parent == null)
        {
            return;
        }

        var createAndChangeItemWindow = new CreateAndChangeItem();
        await createAndChangeItemWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        UserVariableData.selectedItemInMainWindow = null;

        var parent = this.VisualRoot as Window;
        if (parent == null)
        {
            return;
        }

        var createAndChangeItemWindow = new CreateAndChangeItem();
        await createAndChangeItemWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }
}