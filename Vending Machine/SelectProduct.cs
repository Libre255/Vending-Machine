namespace Vending_Machine
{
    public partial class VendingMachine 
    {
        public List<AProduct> Products = new()
        {
            new Chips("Olitas Del Mar", 40, "Sea salted chips from Catalandia"),
            new ProteinBar("Vegan Chocholate Proteinbar", 80, "Planet friendly protein bar with delicious chocholate flavor"),
            new Drink("Coca Cola", 45, "The classic of them all, Coca cola! Perfect drink for all occasions"),
            new Drink("Fanta", 30, "Orange juice with extra energi!"),
            new ProteinBar("Vanilla Proteinbar", 70, "Extra protein with a delicious flavor of vanilla!"),
            new Chips("Chili Capitan", 62, "Sourchili chips, perfect balance of spice, flavor and salt!"),
            new Drink("Dr Pepper", 49, "the World's Oldest Major Soft Drink")
        };

        public void ShowAllProducts()
        {
            string[] ProductsName = ProductsNames(Products);

            int ProductIndex = new Menu("Select the product that you want to buy", ProductsName).Start();

            if (ProductsName[ProductIndex] == "Go back") Start_VendingMachine();
            ItemOptions(ProductIndex);
        }

        public string[] ProductsNames(List<AProduct> Products)
        {
            return Products.Select(p => p.Name).Append("Go back").ToArray();
        }
    }
}
