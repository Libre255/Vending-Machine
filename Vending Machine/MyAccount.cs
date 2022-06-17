using static System.Console;

namespace Vending_Machine
{
    public partial class VendingMachine
    {
        public List<AProduct> MyPurchasedItems = new();
        public void MyAccount()
        {
            string MyAccountMenuTitle = "Your Account info";
            string[] AccountOptions = { "My items", "Vending machine money pool", "Go back" };
            int SelectedOption = new Menu(MyAccountMenuTitle, AccountOptions).Start();

            switch (SelectedOption)
            {
                case 0:
                    CheckAmountOfItems();
                    break;
                case 1:
                    VendingMachineMoneyPool();
                    break;
                case 2:
                    Start_VendingMachine();
                    break;
            }
        }
        public void VendingMachineMoneyPool()
        {
            WriteLine($"[ You have currectly {MoneyPool}kr in the vending machine ]");
            GoBackToMyAccount();
        }
        public void CheckAmountOfItems()
        {
            if (MyPurchasedItems.Count <= 0)
            {
                WriteLine("You have no items");
                GoBackToMyAccount();
            }
            else
            {
                DisplayMyItems();
            }
        }
        public void DisplayMyItems()
        {
            string[] MyItemsNames = ProductsNames(MyPurchasedItems);
            int SelectedItemIndex = new Menu("Here is the list of things you buyed", MyItemsNames).Start();

            if (MyItemsNames[SelectedItemIndex] == "Go back")
            {
                MyAccount();
            }
            else
            {
                ItemInfo(SelectedItemIndex);
            }
        }
        readonly string[] Item_Options = { "Use", "Description", "Go back" };
        public void ItemInfo(int ItemIndex)
        {
            string ItemName = $" [ {MyPurchasedItems[ItemIndex].Name} ]";
            int SelectedOption = new Menu(ItemName, Item_Options).Start();

            switch (SelectedOption)
            {
                case 0:UseSelectedItem(ItemIndex);
                    break;
                case 1:ExamineMyItem(ItemIndex);
                    break;
                case 2:CheckAmountOfItems();
                    break;
            }
        }
        public void UseSelectedItem(int ItemIndex)
        {
            UseItem(ItemIndex);
            PressAny_Key_To_Go_Back();
            Clear();
            CheckAmountOfItems();
        }
        public void UseItem(int ItemIndex)
        {
            MyPurchasedItems[ItemIndex].Use();
            MyPurchasedItems.RemoveAll(ItemInfo => ItemInfo.Used);
        }
        public void ExamineMyItem(int ItemIndex)
        {
            MyPurchasedItems[ItemIndex].Examine();
            PressAny_Key_To_Go_Back();
            ItemInfo(ItemIndex);
        }
        public void GoBackToMyAccount()
        {
            PressAny_Key_To_Go_Back();
            MyAccount();
        }
    }
}
