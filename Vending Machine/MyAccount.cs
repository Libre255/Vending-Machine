using static System.Console;

namespace Vending_Machine
{
    public class MyAccountInfo
    {
        protected int MoneyPool = 0;
        protected List<AProduct> MyPurchasedItems = new List<AProduct>()
        {
            new Chips("Olitas Del Mar", 40, "Sea salted chips from Catalandia")
        };
        
        protected void MyItems(object v)
        {
            if (MyPurchasedItems.Count <= 0)
            {
                WriteLine("You haven't purchased anything yet");
                ReadKey();
                WriteLine("Press any key to go back");
            }
            else
            {
                string[] PurchasedItemsName = MyPurchasedItems.Select(p => p.Name).ToArray();
                Menu PurchasedMenu = new Menu("Here is the list of things you buyed", PurchasedItemsName);
                int SelectedItemIndex = PurchasedMenu.Start();
                ItemInfo(SelectedItemIndex);
            }
        }
        protected void ItemInfo(int ItemIndex)
        {
            AProduct Item = MyPurchasedItems[ItemIndex];
            Menu ItemMenu = new Menu(Item.Name, new string[] { "Use", "Description", "Go back" });
            int SelectedOption = ItemMenu.Start();
            switch (SelectedOption)
            {
                case 0:
                    Item.Use();
                    break;
                case 1:
                    Item.Examine();
                    break;
                case 2:
                    MyItems();
                    break;
            }
            WriteLine("Press any key to go back");
            ReadKey();
            ItemInfo(ItemIndex);
        }
        protected void VendingMachineMoneyPool()
        {
            WriteLine($"[ You have currectly {MoneyPool}kr in the vending machine ]");
            WriteLine("Press any key to go back");
            ReadKey();
        }
    }
}
