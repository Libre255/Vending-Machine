using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    interface IVending
    {
        void Purchase();
        void ShowAll();
        void InsertMoney();
        void EndTransaction();
    }
    //interface IAccount{
    //    public void Start_VendingMachine()
    //    {
    //        Menu MainMenu = new Menu("Welcom to my vending Machine!", MainMenuOptions);
    //        int SelectedIndex_Item = MainMenu.Start();

    //        switch (SelectedIndex_Item)
    //        {
    //            case 0:
    //                ShowAll();
    //                break;
    //            case 1:
    //                InsertMoney();
    //                break;
    //            case 2:
    //                EndTransaction();
    //                break;
    //            case 3:
    //                MyAccount();
    //                break;
    //        }
    //    }
    //    public void MyAccount()
    //    {
    //        Menu MyAccountMenu = new Menu("Your Account info", new string[] { "My items", "Vending machine money pool", "Go back" });
    //        int SelectedOption = MyAccountMenu.Start();
    //        switch (SelectedOption)
    //        {
    //            case 0:
    //                MyItems(MyAccount());
    //                break;
    //            case 1:
    //                VendingMachineMoneyPool();
    //                MyAccount();
    //                break;
    //            case 2:
    //                Start_VendingMachine();
    //                break;
    //        }
    //    }

    //}
}
