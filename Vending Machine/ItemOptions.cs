using static System.Console;

namespace Vending_Machine
{
    public partial class VendingMachine
    {
        public void ItemOptions(int ItemIndex)
        {
            Menu ItemMenu = new("Select your option", new string[] { "Purchase", "Check item info", "Go back" });
            int SelectedOption = ItemMenu.Start();

            switch (SelectedOption)
            {
                case 0:
                    PurchaseSystem(ItemIndex);
                    break;
                case 1:
                    ExamineTheProduct(ItemIndex);
                    break;
                case 2:
                    ShowAllProducts();
                    break;
            }
        }
        public void ExamineTheProduct(int ItemIndex)
        {
            Products[ItemIndex].Examine();
            PressAny_Key_To_Go_Back();
            ItemOptions(ItemIndex);
        }
    }
}
