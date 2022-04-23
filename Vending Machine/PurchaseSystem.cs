using static System.Console;
namespace Vending_Machine
{
    public partial class VendingMachine 
    {
        List<AProduct> Products = new List<AProduct>()
        {
            new Chips("Olitas Del Mar", 40, "Sea salted chips from Catalandia"),
            new ProteinBar("Vegan Chocholate Proteinbar", 80, "Planet friendly protein bar with delicious chocholate flavor"),
            new Drink("Coca Cola", 45, "The classic of them all, Coca cola! Perfect drink for all occasions"),
            new Drink("Fanta", 30, "Orange juice with extra energi!"),
            new ProteinBar("Vanilla Proteinbar", 70, "Extra protein with a delicious flavor of vanilla!"),
            new Chips("Chili Capitan", 62, "Sourchili chips, perfect balance of spice, flavor and salt!"),
            new Drink("Dr Pepper", 49, "the World's Oldest Major Soft Drink")
        };

        public void ShowAll()
        {
            string[] ProductsName = Products.Select(p => p.Name).Append("Go back").ToArray();
            Menu ProductsMenu = new Menu("Select the product that you want to buy", ProductsName);
            int SelectedProductIndex = ProductsMenu.Start();

            if (SelectedProductIndex == ProductsName.Length - 1) Start_VendingMachine();
            PurchaseSystem(SelectedProductIndex);
        }
        public void PurchaseSystem(int SPI)
        {
            Menu ItemMenu = new Menu("Select your option", new string[] { "Purchase", "Check item info", "Go back" });
            int SelectedOption = ItemMenu.Start();

            switch (SelectedOption)
            {
                case 0:Purchase(SPI);
                    break;
                case 1:ExamineTheProduct(SPI);
                    break;
                case 2: ShowAll();
                    break;
            }
        }
        public void Purchase(int SPI)
        {
            AProduct Product = Products[SPI];
            
            if ((MoneyPool - Product.Price) < 0)
            {
                WriteLine("Not enough money on the vending machine");
                WriteLine($"Insert {Math.Abs(MoneyPool - Product.Price)} kr and try again");
                PressAny_Key_To_Go_Back();
                ShowAll();
            }else
            {
                MoneyPool -= Product.Price;
                MyPurchasedItems.Add(Product);
                WriteLine($"*You buyed {Product.Name}*");
                PressAny_Key_To_Go_Back();
                ShowAll();
            }
        }
        public void ExamineTheProduct(int SPI)
        {
            Products[SPI].Examine();
            PressAny_Key_To_Go_Back();
            PurchaseSystem(SPI);
        }
    }
}
