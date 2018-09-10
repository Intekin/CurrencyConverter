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
            Console.WriteLine(args[0] + args[1]+ args[2]);
            bool quit = false;

            if (!(args.Length == 0))
            {
                ConvertMenu(args);
                quit = true;
            }
            
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
                        ConvertMenu(null);
                        selection = 0;
                        CleanConsole();
                        break;

                    default:
                        Console.WriteLine("Fuck, something did not work.");
                        selection = 0;
                        CleanConsole();
                        break;
                }

                if (selection == 2)
               {
                   quit = true;
               }

            }

        }

        private static void ConvertMenu(string[] argument)
        {
            string[] value = { "", "", "" }; // Amount, from, to

            if (argument == null)
            {
                Console.WriteLine("-----Conversion Menu.-----\n" +
                    "Please type the amount you want to convert");
                value[0] = Console.ReadLine();

                Console.WriteLine("Please type the currency you have, SEK, EUR, USD");
                value[1] = Console.ReadLine();

                Console.WriteLine("Please type the currency you want to convert to SEK, EUR, USD");
                value[2] = Console.ReadLine();
            }
            else
            {
                value = argument;
            }

            double amount = Convert.ToDouble(value[0]); //Convert value[0] to an int


            if ((value[2] == "EUR") || (value[2] == "USD") || (value[2] == "SEK")) //Onlu convets from sek to usd
            {
                amount = amount / currencyValue[2];
                Console.WriteLine(value[0] + value[1] + " is " + amount + value[2]
                    + "\nThis is the bills and coins you will recive:\n");
                CalculateValues((float)amount, value[1], value[2]);
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

        static void CalculateValues(float value, string fromCurrency, string toCurrency)
        {
            float[] Currency = { };
            if (toCurrency == "SEK")
            {
                Currency = new float[] { 500, 100, 50, 20, 10, 1 };
            }
            else if (toCurrency == "EUR")
            {
                Currency = new float[] { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.50f, 0.20f, 0.10f, 0.05f, 0.02f, 0.01f };
            }
            else if (toCurrency == "USD")
            {
                Currency = new float[] { 100, 50, 20, 10, 5, 2, 1, 0.50f, 0.25f, 0.10f, 0.05f, 0.01f };
            }


            float tempValue = 0;
            float tempValue2 = 0;

            for (int i = 0; i < Currency.Length; i++)
            {

                tempValue = value % Currency[i];
                tempValue2 = value / Currency[i];
                value = tempValue;

                if (!((int)tempValue2 == 0))
                {
                    if (Currency[i] >= 1f)
                    {
                        Console.WriteLine((int)tempValue2 + "st \t" + Currency[i] + " " + toCurrency);
                    }
                    else
                    {
                        string s_temp = Currency[i].ToString("0.00");
                        string s2_temp = s_temp.TrimStart('0', '.');
                        Console.WriteLine((int)tempValue2 + "st \t" + s2_temp + " Cent " + toCurrency);
                    }
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
