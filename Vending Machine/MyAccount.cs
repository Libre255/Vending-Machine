using static System.Console;

namespace Vending_Machine
{
    public partial class VendingMachine
    {
        protected List<AProduct> MyPurchasedItems = new List<AProduct>();
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
                WriteLine("You have no items");
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
            Menu ItemMenu = new Menu($" [ {Item.Name} ]", new string[] { "Use", "Description", "Go back" });
            int SelectedOption = ItemMenu.Start();

            switch (SelectedOption)
            {
                case 0:UseItem(Item);
                    break;
                case 1:ExamineMyItem(Item, ItemIndex);
                    break;
                case 2:MyItems();
                    break;
            }
        }
        private void UseItem(AProduct Item)
        {
            Item.Use();
            MyPurchasedItems.RemoveAll(ItemInfo => ItemInfo.Used);
            PressAny_Key_To_Go_Back();
            Clear();
            MyItems();
        }
        private void ExamineMyItem(AProduct Item, int ItemIndex)
        {
            Item.Examine();
            PressAny_Key_To_Go_Back();
            ItemInfo(ItemIndex);
        }
        protected void GoBackToMyAccount()
        {
            PressAny_Key_To_Go_Back();
            MyAccount();
        }
    }
}
