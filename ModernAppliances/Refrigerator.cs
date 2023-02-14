using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernAppliances
{
    internal class Refrigerator : Appliance
    {
        public int NumberOfDoors { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }


        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int numberOfDoors, double height, double width)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.NumberOfDoors = numberOfDoors;
            this.Height = height;
            this.Width = width;
        }

        public override string ToString()
        {
            return $"Refrigerator Item Number : {ItemNumber} " +
                $"\n Brand : {Brand} " +
                $"\n Quantity : {Quantity} " +
                $"\n Wattage : {Wattage} " +
                $"\n Color : {Color} " +
                $"\n Price : {Price}" +
                $"\n Number of Doors : {NumberOfDoors}" +
                $"\n Height : {Height}" +
                $"\n Width : {Width} \n\n";
        }

        public override bool IsAvailable()
        {
            if (base.Quantity > 0)
            {
                return true;
            }

            return false;
        }

        public override void Checkout()
        {
            base.Quantity -= 1;
        }

        public override string FormatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{NumberOfDoors};{Height};{Width}";
        }
    }
}
