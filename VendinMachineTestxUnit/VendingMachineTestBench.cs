using Vending_Machine;

namespace VendinMachineTestxUnit
{
    public partial class VendingMachineTestBench
    {
        VendingMachine machine;
        public VendingMachineTestBench()
        {
            machine = new VendingMachine();
        }
        [Fact]
        public void SelectedProductsNamesFromList()
        {
            //Arrange
            List<AProduct> TestProductList = new() {
                new Chips("Olitas Del Mar", 40, "Sea salted chips from Catalandia"),
                new Drink("Coca Cola", 45, "The classic of them all, Coca cola! Perfect drink for all occasions"),
                new ProteinBar("Vanilla Proteinbar", 70, "Extra protein with a delicious flavor of vanilla!")
            };
            //Act
            string[] ProductsNames = machine.ProductsNames(TestProductList);
            //Assert
            //Should be 4 because we also adding an "Go back" option. So 3 products + "Go back" string
            Assert.True(ProductsNames.Count() == 4);
            Assert.Contains(ProductsNames, ItemName => ItemName == "Go back");
            Assert.Contains(ProductsNames, ItemName => ItemName == "Olitas Del Mar");
            Assert.Contains(ProductsNames, ItemName => ItemName == "Coca Cola");
            Assert.Contains(ProductsNames, ItemName => ItemName == "Vanilla Proteinbar");
        }
        [Fact]
        public void CheckIfItemWasUsed()
        {
            //Arrange
            machine.MyPurchasedItems.Add(new Chips("Olitas Del Mar", 40, "Sea salted chips from Catalandia"));
            int SelectedItemIndex = machine.MyPurchasedItems.FindIndex(Item => Item.Name == "Olitas Del Mar");
            //Act
            machine.UseItem(SelectedItemIndex);
            //Assert
            Assert.True(machine.MyPurchasedItems.Count() == 0);

        }
    }
}