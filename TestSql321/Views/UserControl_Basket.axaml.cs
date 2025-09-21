using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestSql321.Data;
using TestSql321.Models;
using TestSql321.ViewModels;

namespace TestSql321;

public partial class UserControl_Basket : UserControl
{
    public UserControl_Basket()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedBasket = MainDataGridBaskets.SelectedItem as Busket;

        if (selectedBasket == null) return;

        UserVariableData.selectedBasketInMainWindow = selectedBasket;

        var parent = this.VisualRoot as Window;
        if (parent == null)
        {
            return;
        }

        var createAndChangeBasketWindow = new CreateAndChangeBasket();
        await createAndChangeBasketWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        UserVariableData.selectedBasketInMainWindow = null;

        var parent = this.VisualRoot as Window;
        if (parent == null)
        {
            return;
        }

        var createAndChangeBasketWindow = new CreateAndChangeBasket();
        await createAndChangeBasketWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }
}