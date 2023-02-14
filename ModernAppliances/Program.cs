using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernAppliances
{
    internal class Program
    {
        public static List<Appliance> appliances = new List<Appliance>();
        private static bool isFinish = true;
        static void Main(string[] args)
        {
            ReadFile();

            while (isFinish)
            {
                string answer = DisplayWelcomeMessage();
                WelcomeOption(answer);
            }

            Console.ReadLine();
        }

        private static string DisplayWelcomeMessage() // DEFAULT WELCOME MESSAGE
        {
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How may we assist you?");
            Console.WriteLine("1 - Checkout appliance");
            Console.WriteLine("2 - Find appliances by brand");
            Console.WriteLine("3 - Display appliances by type");
            Console.WriteLine("4 - Produce random appliance list");
            Console.WriteLine("5 - Save and exit");
            Console.Write("Enter option: ");

            return Console.ReadLine();
        }

        private static void WelcomeOption(string answer) // CHECKING USER INPUT
        {
            if (answer == "1")
            {
                CheckOutOption();
            }
            else if (answer == "2")
            {
                FindByBrand();
            }    
            else if (answer == "3")
            {
                ApplianceType();
            }
            else if (answer == "4")
            {
                RandomAppliances();
            }    
            else if (answer == "5")
            {
                Console.WriteLine("Goodbye!");
                isFinish = false;
            }
                
        }

        private static void CheckOutOption() // FIND APPLIANCES BY ITEM NUMBER
        {
            Console.WriteLine("");
            Console.Write("Enter the item number of an appliance: ");
            long itemNumber = (long) Convert.ToInt32(Console.ReadLine());

            int applianceFilter = 0;
            foreach(Appliance appliance in appliances)
            {
                if (appliance.ItemNumber == itemNumber && appliance.IsAvailable())
                {
                    applianceFilter = 1;
                    appliance.Checkout();
                    break;
                }
                else if (appliance.ItemNumber == itemNumber && !appliance.IsAvailable())
                {
                    applianceFilter = 2;
                    break;
                }
            }

            if(applianceFilter == 1)
                Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
            else if(applianceFilter == 2)
                Console.WriteLine("The appliance is not available to be checked out.");
            else
                Console.WriteLine("No appliances found with that item number.");

            Console.WriteLine("");
        }

        private static void FindByBrand() // FIND APPLIANCES BY BRAND
        {
            Console.WriteLine("");
            Console.Write("Enter brand to search for: ");
            string brandName = Console.ReadLine();

            int brandFilter = 0;
            foreach (Appliance appliance in appliances)
            {
                if (appliance.Brand.ToUpper() == brandName.ToUpper())
                {
                    Console.WriteLine(appliance.ToString());
                    brandFilter = 1;
                }
            }

            if(brandFilter == 0)
            {
                Console.WriteLine("No brand name found!");
            }

            Console.WriteLine("");
        }

        private static void ApplianceType() // FIND APPLIANCES BY TYPE
        {
            Console.WriteLine("");
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacuums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");

            Console.Write("Enter type of appliance: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            if(userInput == 1)
            {
                Console.Write("Enter number of doors: 2 (double doors), 3 (Three door) or 4 (four doors): ");
                int numberOfDoors = Convert.ToInt32(Console.ReadLine());

                foreach(Appliance appliance in appliances)
                {
                    if(appliance is Refrigerator)
                    {
                        if(((Refrigerator)appliance).NumberOfDoors == numberOfDoors)
                        {
                            Console.WriteLine(appliance.ToString());
                        }
                    }
                }
            }
            else if (userInput == 2)
            {
                Console.Write("Enter battery voltage value. 18V (low) or 24V (high): ");
                int voltage = Convert.ToInt32(Console.ReadLine());

                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Vacuum)
                    {
                        if (((Vacuum)appliance).BatteryVoltage == voltage)
                        {
                            Console.WriteLine(appliance.ToString());
                        }
                    }
                }
            }
            else if(userInput == 3)
            {
                Console.Write("Room where the microwave will be installed: K (kitchen) or W (work site): ");
                string roomType = Console.ReadLine().ToUpper();

                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Microwave)
                    {
                        if (((Microwave)appliance).RoomType == roomType)
                        {
                            Console.WriteLine(appliance.ToString());
                        }
                    }
                }
            }
            else if(userInput == 4)
            {
                Console.Write("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate): ");
                string feature = Console.ReadLine().ToUpper();

                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Dishwasher)
                    {
                        if (((Dishwasher)appliance).FeatureAndFinish.ToUpper() == feature)
                            Console.WriteLine(appliance.ToString());
                    }
                }
            }

            Console.WriteLine("");

        }

        private static void RandomAppliances() // GENERATE RANDOM APPLIANCES
        {
            Console.WriteLine("");
            Console.Write("Enter number of appliances: ");
            int numberOfAppliances = Convert.ToInt32(Console.ReadLine());

            Random rnd = new Random();
            for (int i = 0; i < numberOfAppliances; i++)
            {
                int randomNumber = rnd.Next(appliances.Count);
                Console.WriteLine(appliances[randomNumber].ToString());                
            }

            Console.WriteLine("");
        }


        private static void ReadFile() // READING FILE FROM TEXT
        {
            string[] fileArray = File.ReadAllLines("C:\\Users\\Anthony Magpantay\\Desktop\\SAIT\\2nd Term\\OOP2\\Assignment 1\\appliances.txt");
            
            foreach (string line in fileArray)
            {
                string[] lineArray = line.Split(';');
                string itemNumber = lineArray[0];
                string brand = lineArray[1];
                int quantity = Convert.ToInt32(lineArray[2]);
                double wattage = Convert.ToDouble(lineArray[3]);
                string color = lineArray[4];
                double price = Convert.ToDouble(lineArray[5]);

                switch (itemNumber[0])
                {
                    case '1': // Refrigerator
                        int numberOfDoors = Convert.ToInt32(lineArray[6]);
                        double height = Convert.ToDouble(lineArray[7]);
                        double width = Convert.ToDouble(lineArray[8]);
                        appliances.Add(new Refrigerator((long)Convert.ToInt32(itemNumber), brand, quantity, wattage, color, price, numberOfDoors, height, width));
                        break;
                    case '2': // Vacuum
                        string grade = lineArray[6];
                        int voltage = Convert.ToInt32(lineArray[7]);
                        appliances.Add(new Vacuum((long)Convert.ToInt32(itemNumber), brand, quantity, wattage, color, price, grade, voltage));
                        break;
                    case '3': // Microwave
                        double capacity = Convert.ToDouble(lineArray[6]);
                        string roomType = lineArray[7];
                        appliances.Add(new Microwave((long)Convert.ToInt32(itemNumber), brand, quantity, wattage, color, price, capacity, roomType));
                        break;
                    default: // Dishwasher (4,5)
                        string soundRating = lineArray[6];
                        string feature = lineArray[7];
                        appliances.Add(new Dishwasher((long)Convert.ToInt32(itemNumber), brand, quantity, wattage, color, price, soundRating, feature));
                        break;
                }
            }

            Console.WriteLine("");
        }
    }
}
