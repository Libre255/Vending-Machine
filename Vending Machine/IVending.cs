using static System.Console;

namespace Vending_Machine
{
    public interface IVending
    {
        void PurchaseSystem(int SPI);
        void ShowAllProducts();
        void InsertMoney();
        void EndTransaction();
    }
}
