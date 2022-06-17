using static System.Console;

namespace Vending_Machine
{
    public partial class VendingMachine : IVending
    {
        public string[] MainMenuOptions = { "Show all products", "Insert Money", "End Transaction", "My Account" };
        public readonly int[] MoneyDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public int MoneyPool = 0;

        public void Start_VendingMachine()
        {
            Menu MainMenu = new("Welcom to my vending Machine!", MainMenuOptions);
            int SelectedIndex_Item = MainMenu.Start();

            switch (SelectedIndex_Item)
            {
                case 0:ShowAllProducts();
                    break;
                case 1:InsertMoney();
                    break;
                case 2:EndTransaction();
                    break;
                case 3:MyAccount();
                    break;
            }
        }
        public void InsertMoney()
        {
            string [] MoneyOptions = MoneyDenominations.Select(Money => $"[ {Money}kr ]").Append("Go back").ToArray();
            Menu MoneyDenominationMenu = new(">Please select the amount of money you want you insert to the vending machine.", MoneyOptions);
            int SelectedAmount = MoneyDenominationMenu.Start();

            if(MoneyOptions[SelectedAmount] == "Go back")
            {
                Start_VendingMachine();
            }
            else
            {
                MoneyPool = MoneyPoolAfterInsertedMoney(MoneyPool, MoneyDenominations[SelectedAmount]);
                WriteLine($"+ You inserted: {MoneyDenominations[SelectedAmount]} ");
                WriteLine($"+ Your current balance is now: {MoneyPool} ");
                PressAny_Key_To_Go_Back();
                Start_VendingMachine();
            }

        }
        public void EndTransaction()
        {
            if(MoneyPool == 0)
            {
                WriteLine(">> You haven't money on the vending machine");
            }
            else
            {
                WriteLine("Thanks for using the vending machine! ");
                WriteLine($"Here is your change: [ {MoneyPool}kr ]");
                MoneyPool = 0;
            }
            PressAny_Key_To_Go_Back();
            Start_VendingMachine();
        }
        private void PressAny_Key_To_Go_Back()
        {
            WriteLine("> Press any key to go back");
            ReadKey();
        }
        public int MoneyPoolAfterInsertedMoney(int MP, int InsertedSum)
        {
            return MP + InsertedSum;
        }
    
    }
}
