using static System.Console;

namespace Vending_Machine
{
    public interface IVending
    {
        void Purchase();
        void ShowAll();
        void InsertMoney();
        void EndTransaction();
    }
}
