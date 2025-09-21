using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestSql321.Data;
using TestSql321.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestSql321;

public partial class CreateAndChangeBasket : Window
{
    public CreateAndChangeBasket()
    {
        InitializeComponent();

        DataContext = new ViewModels.MainWindowViewModel();

        if (UserVariableData.selectedBasketInMainWindow == null) return;
        CountText.Text = UserVariableData.selectedBasketInMainWindow.Count.ToString();

        var viewModel = (ViewModels.MainWindowViewModel)DataContext;
        ComboIdUser.SelectedItem = viewModel.Users
            .FirstOrDefault(r => r.UserId == UserVariableData.selectedBasketInMainWindow.UserId);

        ComboItems.SelectedItem = viewModel.Items
            .FirstOrDefault(r => r.ItemId == UserVariableData.selectedBasketInMainWindow.ItemId);
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedUser = ComboIdUser.SelectedItem as User;
        if (selectedUser == null) return;

        var selectedItem = ComboItems.SelectedItem as Item;
        if (selectedItem == null) return;



        if (UserVariableData.selectedBasketInMainWindow != null)
        {
            if (int.TryParse(CountText.Text, out int count))
            {
                var IdBasket = UserVariableData.selectedBasketInMainWindow.BusketId;
                var thisBasket = App.DbContext.Buskets
                    .FirstOrDefault(x => x.BusketId == IdBasket);

                if (thisBasket == null) return;

                thisBasket.UserId = selectedUser.UserId;
                thisBasket.ItemId = selectedItem.ItemId;
                thisBasket.Count = count;
            }
            else
            {
                this.Close();
                return;
            }
        }
        else
        {
            if (int.TryParse(CountText.Text, out int count))
            {
                var newBasket = new Busket()
                {
                    UserId = selectedUser.UserId,
                    ItemId = selectedItem.ItemId,
                    Count = count,
                };
                App.DbContext.Buskets.Add(newBasket);
            }
            else
            {
                this.Close();
                return;
            }
        }
        App.DbContext.SaveChanges();
        this.Close();
    }
}
