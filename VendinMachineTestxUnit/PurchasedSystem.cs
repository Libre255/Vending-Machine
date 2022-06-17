using Vending_Machine;

namespace VendinMachineTestxUnit
{
    public partial class VendingMachineTestBench
    {
        [Theory]
        [InlineData(100, 100, 0)]
        [InlineData(5, 250, -245)]
        [InlineData(51, 38, 13)]
        public void CheckMoneyPoolAfterPurchase(int _MoneyPool, int ProductPrice, int Expected)
        {
            //Arrange
            machine.MoneyPool = _MoneyPool;
            //Act
            int updatedMoneyPool = machine.MoneyPoolAfterPurchased(machine.MoneyPool, ProductPrice);
            //Assert
            Assert.Equal(Expected, updatedMoneyPool);

        }
        [Theory]
        [InlineData(34, 16, 50)]
        [InlineData(990, 9, 999)]
        [InlineData(2, 122, 124)]
        public void CheckMoneyPoolAfterInsertedMoney(int _MoneyPool, int InsertedMoney, int Expected)
        {
            //Arrange
            machine.MoneyPool = _MoneyPool;
            //Act
            int updatedMoneyPool = machine.MoneyPoolAfterInsertedMoney(_MoneyPool, InsertedMoney);
            //Assert
            Assert.Equal(Expected, updatedMoneyPool);
        }
        [Fact]
        public void MoneyPoolNewValue()
        {
            machine.UpdateMoneyPool(23424);
            Assert.Equal(23424, machine.MoneyPool);
        }
        [Fact]
        public void AddedAItemCheckMyBasket()
        {
            //Arrange
            AProduct Chips = machine.Products[0];
            //Act
            machine.AddItemToMyBasket((AProduct)Chips.Clone());
            //Assert
            Assert.True(machine.MyPurchasedItems.Count == 1);
            Assert.Contains(machine.MyPurchasedItems, item => item.Name == Chips.Name);
        }
        [Fact]
        public void AddedMultipleItemsCheckMyBasket()
        {
            //Arrange
            AProduct Chips = machine.Products[0];
            AProduct ProteinBar = machine.Products[4];
            AProduct CocaCola = machine.Products[6];
            //Act
            machine.AddItemToMyBasket((AProduct)Chips.Clone());
            machine.AddItemToMyBasket((AProduct)ProteinBar.Clone());
            machine.AddItemToMyBasket((AProduct)CocaCola.Clone());
            //Assert
            Assert.True(machine.MyPurchasedItems.Count == 3);
            Assert.Contains(machine.MyPurchasedItems, item => item.Name == Chips.Name);
            Assert.Contains(machine.MyPurchasedItems, item => item.Name == ProteinBar.Name);
            Assert.Contains(machine.MyPurchasedItems, item => item.Name == CocaCola.Name);
        }
    }
}
