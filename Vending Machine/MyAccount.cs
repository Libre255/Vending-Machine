using static System.Console;

namespace Vending_Machine
{
    public partial class VendingMachine
    {
        protected int MoneyPool = 0;
        protected List<AProduct> MyPurchasedItems = new List<AProduct>()
        {
            new Chips("Olitas Del Mar", 40, "Sea salted chips from Catalandia")
        };
        public void MyAccount()
        {
            Menu MyAccountMenu = new Menu("Your Account info", new string[] { "My items", "Vending machine money pool", "Go back" });
            int SelectedOption = MyAccountMenu.Start();

            switch (SelectedOption)
            {
                case 0:
                    MyItems();
                    break;
                case 1:
                    VendingMachineMoneyPool();
                    break;
                case 2:
                    Start_VendingMachine();
                    break;
            }
        }
        protected void VendingMachineMoneyPool()
        {
            WriteLine($"[ You have currectly {MoneyPool}kr in the vending machine ]");
            GoBackToMyAccount();
        }
        protected void MyItems()
        {
            if (MyPurchasedItems.Count <= 0)
            {
                WriteLine("You haven't purchased anything yet");
                GoBackToMyAccount();
            }
            else
            {
                string[] PurchasedItemsName = MyPurchasedItems.Select(p => p.Name).Append("Go Back").ToArray();
                Menu PurchasedMenu = new Menu("Here is the list of things you buyed", PurchasedItemsName);
                int SelectedItemIndex = PurchasedMenu.Start();
                bool selectedGoBack = (SelectedItemIndex == PurchasedItemsName.Length - 1);

                if (selectedGoBack)
                {
                    MyAccount();
                }
                else
                {
                    ItemInfo(SelectedItemIndex);
                }
            }
        }
        protected void ItemInfo(int ItemIndex)
        {
            AProduct Item = MyPurchasedItems[ItemIndex];
            Menu ItemMenu = new Menu(Item.Name, new string[] { "Use", "Description", "Go back" });
            int SelectedOption = ItemMenu.Start();

            if(SelectedOption == 0 && SelectedOption == 1)
            {

            }
            switch (SelectedOption)
            {
                case 0:
                    Item.Use();
                    GoBackToMyItemMenu(ItemIndex);
                    break;
                case 1:
                    Item.Examine();
                    GoBackToMyItemMenu(ItemIndex);
                    break;
                case 2:
                    MyItems();
                    break;
            }
        }

        protected void GoBackToMyAccount()
        {
            WriteLine("Press any key to go back");
            ReadKey();
            MyAccount();
        }
        private void GoBackToMyItemMenu(int ItemIndex)
        {
            WriteLine("Press any key to go back");
            ReadKey();
            ItemInfo(ItemIndex);
        }
        
    }
}
