using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernAppliances
{
    internal class Microwave : Appliance
    {
        public double Capacity { get; set; }
        public string RoomType { get; set; }

        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, string roomType)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Capacity = capacity;
            this.RoomType = roomType;
        }

        public override string ToString()
        {
            return $"Microwave Item Number : {ItemNumber} " +
                $"\n Brand : {Brand} " +
                $"\n Quantity : {Quantity} " +
                $"\n Wattage : {Wattage} " +
                $"\n Color : {Color} " +
                $"\n Price : {Price}" +
                $"\n Capacity : {Capacity}" +
                $"\n Room Type : {RoomType} \n\n";
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
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Capacity};{RoomType}";
        }
    }
}
