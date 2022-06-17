using static System.Console;
namespace Vending_Machine
{
    public abstract class AProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool Used { get; set; }

        public AProduct (string ItemName, int ItemPrice, string ItemDescription)
        {
            Name = ItemName;
            Price = ItemPrice;
            Description = ItemDescription;
            Used = false;
        }
        public void Examine()
        {
            WriteLine($"Name: {Name}" + '\n' +
                     $"Price: {Price}" + '\n' +
                     $"Description: {Description}");
        }
        public abstract void Use();
        public abstract object Clone();
    }

    public class Drink : AProduct,ICloneable
    {
        public Drink(string DrinkName, int DrinkPrice, string DrinkDescription)
              :base(DrinkName, DrinkPrice, DrinkDescription){}
        public  override object Clone()
        {
            return this.MemberwiseClone();
        }
        public override void Use()
        {
            Used = true;
            WriteLine($"** Drinked the {Name} **");
        }

    }
    public class Chips : AProduct
    {
        public Chips(string ChipsName, int ChipsPrice, string ChipsDescription) 
              :base(ChipsName, ChipsPrice, ChipsDescription){}
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
        public override void Use()
        {
            WriteLine($"** Eated the chips {Name} **");
            Used = true;
        }
    }
    public class ProteinBar : AProduct
    {
        public ProteinBar(string ProteinBarName, int ProteinBarPrice, string ProteinBarDescription):
               base(ProteinBarName, ProteinBarPrice, ProteinBarDescription){}
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
        public override void Use()
        {
            WriteLine($"** Eated the proteinbar {Name} **");
            Used = true;
        }
    } 
}
