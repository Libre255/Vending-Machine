﻿using static System.Console;
namespace Vending_Machine
{
    public abstract class AProduct
    {
        private string iName;
        private int iPrice;
        private string iDescription;
        private bool iUsed = false;
        public string Name { get { return iName; } set { iName = value; } }
        public int Price { get { return iPrice; } set { iPrice = value; } }
        public string Description { get { return iDescription; } set { iDescription = value; } }
        public bool Used { get { return iUsed; } set { iUsed = value; } }

        public AProduct (string ItemName, int ItemPrice, string ItemDescription)
        {
            Name = ItemName;
            Price = ItemPrice;
            Description = ItemDescription;
        }
        public void Examine()
        {
            WriteLine($"Name: {Name}" + '\n' +
                     $"Price: {Price}" + '\n' +
                     $"Description: {Description}" + '\n' +
                     $"Used:{Used}");
        }
        public abstract void Use();
    }

    public class Drink : AProduct
    {
        public Drink(string DrinkName, int DrinkPrice, string DrinkDescription)
              :base(DrinkName, DrinkPrice, DrinkDescription){}
        public override void Use()
        {
            WriteLine($"You drinked the {Name}");
            Used = true;
        }

    }
    public class Chips : AProduct
    {
        public Chips(string ChipsName, int ChipsPrice, string ChipsDescription) 
              :base(ChipsName, ChipsPrice, ChipsDescription){}
       
        public override void Use()
        {
            WriteLine($"You eated the chips {Name}");
            Used = true;
        }
    }
    public class ProteinBar : AProduct
    {
        public ProteinBar(string ProteinBarName, int ProteinBarPrice, string ProteinBarDescription):
               base(ProteinBarName, ProteinBarPrice, ProteinBarDescription){}
        public override void Use()
        {
            WriteLine($"You eated the proteinbar {Name}");
            Used = true;
        }
    } 
}