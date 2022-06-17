using static System.Console;

namespace Vending_Machine
{
    public partial class VendingMachine
    {
        public void PurchaseSystem(int SPI)
        {
            AProduct Product = Products[SPI];
            CheckMoneyBalance(Product);
            PressAny_Key_To_Go_Back();
            ShowAllProducts();
        }
        public void CheckMoneyBalance(AProduct Product)
        {
            int UpdatedMoneyPool = MoneyPoolAfterPurchased(MoneyPool, Product.Price);
            if (UpdatedMoneyPool < 0)
            {
                WriteLine("Not enough money on the vending machine");
                WriteLine($"Insert {Math.Abs(UpdatedMoneyPool)} kr and try again");
            }
            else
            {
                UpdateMoneyPool(UpdatedMoneyPool);
                AddItemToMyBasket(Product);
                WriteLine($"*You buyed {Product.Name}*");
            }
        }
        public void UpdateMoneyPool(int UpdatedMoneyPool)
        {
            MoneyPool = UpdatedMoneyPool;
        }
        public void AddItemToMyBasket(AProduct Product)
        {
            MyPurchasedItems.Add((AProduct)Product.Clone());
        }
        public int MoneyPoolAfterPurchased(int MoneyPool, int ProductPrice)
        {
            return MoneyPool - ProductPrice;
        }

    }
}
