using static System.Console;
namespace Vending_Machine
{
    public partial class VendingMachine 
    {
        public void Purchase()
        {
            //Check money pool and add item
        }
        public void PurchaseSystem()
        {
            Menu ItemMenu = new Menu("Select your option", new string[] { "Purchase", "Check item info", "Go back" });
            int SelectedOption = ItemMenu.Start();

            switch (SelectedOption)
            {
                case 0:Purchase();
                    break;
                case 1: Products[SelectedProductIndex].Examine();
                    break;
                case 2: ShowAll();
                    break;
            }
            WriteLine("Press any key to go back to Item menu");
            ReadKey();
            PurchaseSystem();
        }
       
    }
}
