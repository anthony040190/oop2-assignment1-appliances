using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernAppliances
{
    internal class Dishwasher : Appliance
    {
        public string SoundRating { get; set; }
        public string FeatureAndFinish { get; set; }

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string soundRating, string featureAndFinish)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.SoundRating = soundRating;
            this.FeatureAndFinish = featureAndFinish;
        }

        public override string ToString()
        {
            return $"Dishwasher Item Number : {ItemNumber} " +
                $"\n Brand : {Brand} " +
                $"\n Quantity : {Quantity} " +
                $"\n Wattage : {Wattage} " +
                $"\n Color : {Color} " +
                $"\n Price : {Price}" +
                $"\n Sound Rating : {SoundRating} " +
                $"\n Feature : {FeatureAndFinish} \n\n";
        }

        public override bool IsAvailable()
        {
            if(base.Quantity > 0)
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
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{SoundRating};{FeatureAndFinish}";
        }
    }
}
