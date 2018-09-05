using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Program
    {
        static double[] currencyValue = { 8.08d, 9.48d, 0.85d }; //us-sek, eu-sek, us-eur

        static void Main(string[] args)
        {
            bool quit = false;
            int selection = 0;

            while (!quit)
            {

                switch (selection)
                {
                    case 0:
                        MainMenu();
                        selection = CurrencySelector();
                        Console.Clear();
                        break;

                    case 1:
                        ConvertMenu();
                        selection = 0;
                        CleanConsole();
                        break;

                    default:
                        Console.WriteLine("Fuck, something did not work.");
                        CleanConsole();
                        break;
                }

                if (selection == 2)
               {
                   quit = true;
               }

            }

        }

        private static void ConvertMenu()
        {
            string[] value = { "", "", "" }; // Amount, from, to

            Console.WriteLine("-----Conversion Menu.-----\n" +
                "Please type the amount you want to convert");
            value[0] = Console.ReadLine();

            Console.WriteLine("Please type the currency you have, SEK, EUR, USD");
            value[1] = Console.ReadLine();

            Console.WriteLine("Please type the currency you want to convert to SEK, EUR, USD");
            value[2] = Console.ReadLine();

            double amount = Convert.ToDouble(value[0]);


            if ((value[2] == "EUR") || (value[2] == "USD"))
            {
                amount = amount / currencyValue[1];
                Console.WriteLine(value[0] + value[1] + " is " + amount + value[1]
                    + "\nThis is the bills and coins you will recive:\n");
                CalculateValues(amount, value[1], value[2]);
            }
            else
            {
                Console.WriteLine("Did you write it wrong?");
            }
           
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to the currency converter.\n" +
                "Select what you want to do.\n" +
                "1.Convert\n2.Quit\n");    
        }

        static int CurrencySelector()
        {
            int temp = 0;
            string strTemp;

            strTemp = Console.ReadKey().KeyChar.ToString();

            if(strTemp == "1")
            {
                temp = 1;
            }
            else if (strTemp == "2")
            {
                temp = 2;
            }
            else
            {
                Console.WriteLine("Not a valid entery.");
                CleanConsole();
            }
            return temp;
        }

        static void CalculateValues(double value,string fromCurrency, string toCurrency)
        {
            double[] Currency = {};
            if(toCurrency == "SEK")
            {
                Currency = new double[] { 500, 100, 50, 20, 10, 1 };
            }
            else if(toCurrency == "EUR")
            {
                Currency = new double[] { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.20, 0.10, 0.05, 0.02, 0.01 };

            }
            else if (toCurrency == "USD")
            {
                Currency = new double[] { 100, 50, 20, 10, 5, 2, 1, 0.5, 0.25, 0.10, 0.05, 0.01 };

            }
            double tempValue = 0;
            double tempValue2 = 0;

            for (int i = 0; i < Currency.Length; i++)
            {

                tempValue = value % Currency[i];
                tempValue2 = value / Currency[i];
                value = tempValue;

                if (!((int)tempValue2 == 0))
                {
                    Console.WriteLine((int)tempValue2 + "st " + Currency[i] + toCurrency);
                }
            }
            Console.ReadKey();     
        }

        static void CleanConsole()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
