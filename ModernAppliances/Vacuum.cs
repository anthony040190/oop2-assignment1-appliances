using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernAppliances
{
    internal class Vacuum : Appliance
    {
        public string Grade { get; set; }
        public int BatteryVoltage { get; set; }

        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int voltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Grade = grade;
            this.BatteryVoltage = voltage;
        }

        public override string ToString()
        {
            return $"Vacuum Item Number : {ItemNumber} " +
                $"\n Brand : {Brand} " +
                $"\n Quantity : {Quantity} " +
                $"\n Wattage : {Wattage} " +
                $"\n Color : {Color} " +
                $"\n Price : {Price}" +
                $"\n Grade : {Grade}" +
                $"\n Voltage : {BatteryVoltage} \n\n";
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
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Grade};{BatteryVoltage}";
        }
    }
}
