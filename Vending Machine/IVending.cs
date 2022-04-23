using static System.Console;

namespace Vending_Machine
{
    public interface IVending
    {
        void Purchase(int SPI);
        void ShowAll();
        void InsertMoney();
        void EndTransaction();
    }
}
