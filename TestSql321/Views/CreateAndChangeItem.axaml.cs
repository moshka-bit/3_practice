using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestSql321.Data;
using TestSql321.Models;

namespace TestSql321;

public partial class CreateAndChangeItem : Window
{
    public CreateAndChangeItem()
    {
        InitializeComponent();

        DataContext = new ViewModels.MainWindowViewModel();

        if (UserVariableData.selectedItemInMainWindow == null) return;
        NameText.Text = UserVariableData.selectedItemInMainWindow.ItemName;
        PriceText.Text = UserVariableData.selectedItemInMainWindow.ItemPrice.ToString();
        DescriptionText.Text = UserVariableData.selectedItemInMainWindow.Description;

    }
    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (UserVariableData.selectedItemInMainWindow != null)
        {
            if (int.TryParse(PriceText.Text, out int price))
            {
                var IdItem = UserVariableData.selectedItemInMainWindow.ItemId;
                var thisItem = App.DbContext.Items.FirstOrDefault(x => x.ItemId == IdItem);

                if (thisItem == null) return;

                thisItem.ItemName = NameText.Text;
                thisItem.Description = DescriptionText.Text;
                thisItem.ItemPrice = price;
            }
            else
            {
                this.Close();
            }
        }
        else
        {
            if (int.TryParse(PriceText.Text, out int price))
            {
                var newItem = new Item()
                {
                    ItemName = NameText.Text,
                    Description = DescriptionText.Text,
                    ItemPrice = price,
                };
                App.DbContext.Items.Add(newItem);
            }
            else
            {
                this.Close();
            }
        }
        App.DbContext.SaveChanges();
        this.Close();
    }
}

