using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernAppliances
{
    abstract class Appliance
    {
        public long ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public double Wattage { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }

        public abstract bool IsAvailable();

        public abstract void Checkout();

        public abstract string FormatForFile();

        public override string ToString()
        {
            return $"Appliance Item Number : {ItemNumber} " +
                $"\n Brand : {Brand} " +
                $"\n Quantity : {Quantity} " +
                $"\n Wattage : {Wattage} " +
                $"\n Color : {Color} " +
                $"\n Price : {Price}";
        }
    }
}
