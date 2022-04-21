using static System.Console;

namespace Vending_Machine
{
    public partial class VendingMachine : MyAccountInfo, IVending
    {
        string[] MainMenuOptions = { "Show all products", "Insert Money", "End Transaction", "My Account" };
        readonly int[] MoneyDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        int SelectedProductIndex; 
        List<AProduct> Products = new List<AProduct>()
        {
            new Chips("Olitas Del Mar", 40, "Sea salted chips from Catalandia"),
            new ProteinBar("Vegan Chocholate Proteinbar", 50, "Planet friendly protein bar with delicious chocholate flavor"),
            new Drink("Coca Cola", 35, "The classic of them all, Coca cola! Perfect drink for all occasions")
        };
        
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
        public void ShowAll()
        {
            string[] ProductsName = Products.Select(p => p.Name).ToArray();
            Menu ProductsMenu = new Menu("Select the product that you want to buy", ProductsName);
            int SPI = ProductsMenu.Start();
            SelectedProductIndex = SPI;
            PurchaseSystem();
        }
        public void InsertMoney()
        {
            Clear();
            WriteLine("Please insert the amount of money for the vending machine. ");
            WriteLine("You can only insert the following coins/bills.");
            foreach(int MD in MoneyDenominations)
            {
                Write($" [{MD}kr] ");
            }
            WriteLine('\n');

            int Input = NrValidator();
            bool correctInput = MoneyDenominations.Contains(Input);
            while (!correctInput)
            {
                InsertMoney();
            }
            MoneyPool += Input;
            WriteLine($"You inserted: {MoneyPool} ");
            WriteLine("Press any key to go back");
            ReadKey();
            Start_VendingMachine();
        }
        public void EndTransaction()
        {

        }
        public void MyAccount()
        {
            Menu MyAccountMenu = new Menu("Your Account info", new string[] { "My items", "Vending machine money pool", "Go back" });
            int SelectedOption = MyAccountMenu.Start();
            switch (SelectedOption)
            {
                case 0:
                    MyItems(MyAccount());
                    break;
                case 1:
                    VendingMachineMoneyPool();
                    MyAccount();
                    break;
                case 2:
                    Start_VendingMachine();
                    break;
            }
        }
        private int NrValidator()
        {
            int checkRuns = 1;
            int numberOutput;
            string input;
            do
            {
                if (checkRuns >= 2)
                {
                    WriteLine("You can only write numbers(no negatives), please try again");
                }
                input = ReadLine();
                checkRuns++;
            } while (!int.TryParse(input, out numberOutput) || numberOutput <= 0);
            return numberOutput;
        }

    }
}
