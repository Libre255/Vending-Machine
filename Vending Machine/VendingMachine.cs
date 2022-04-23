using static System.Console;

namespace Vending_Machine
{
    public partial class VendingMachine : IVending
    {
        string[] MainMenuOptions = { "Show all products", "Insert Money", "End Transaction", "My Account" };
        readonly int[] MoneyDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        private int MoneyPool = 0;
        public void Start_VendingMachine()
        {
            Menu MainMenu = new Menu("Welcom to my vending Machine!", MainMenuOptions);
            int SelectedIndex_Item = MainMenu.Start();

            switch (SelectedIndex_Item)
            {
                case 0:ShowAll();
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
            //You could also create a menu and select the money denomination you would like to insert
            Clear();
            WriteLine("Please insert the amount of money for the vending machine. ");
            WriteLine("You can only insert the following coins/bills.");
            foreach(int MD in MoneyDenominations) Write($" [{MD}kr] ");
            WriteLine('\n');

            int InsertedMoney = Validate_Money_Input();
            MoneyPool += InsertedMoney;

            WriteLine($"+ You inserted: {InsertedMoney} ");
            WriteLine($"+ Your current balance is now: {MoneyPool} ");
            PressAny_Key_To_Go_Back();
            Start_VendingMachine();
        }
        public void EndTransaction()
        {
            if(MoneyPool == 0)
            {
                WriteLine("You haven't money on the vending machine");
            }
            else
            {
                WriteLine("Thanks for using the vending machine! ");
                WriteLine($"Here is your change: {MoneyPool}kr");
                MoneyPool = 0;
            }
            PressAny_Key_To_Go_Back();
            Start_VendingMachine();
        }
        private int Validate_Money_Input()
        {
            int wrongInputRun = 1;
            int numberOutput;
            string userInput;
            do
            {
                if (wrongInputRun >= 2) WriteLine("You can only insert the coins/bills writed above, please try again");
                
                userInput = ReadLine();
                wrongInputRun++;
            } while (!int.TryParse(userInput, out numberOutput) || numberOutput <= 0 || !MoneyDenominations.Contains(numberOutput));
            return numberOutput;
        }
        private void PressAny_Key_To_Go_Back()
        {
            WriteLine("Press any key to go back");
            ReadKey();
        }
    }
}
