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
                        SekMenu();
                        selection = 0;
                        CleanConsole();
                        break;

                   case 2:
                        EurMenu();
                        selection = 0;
                        CleanConsole();
                        break;

                    case 3:
                        UsdMenu();
                        selection = 0;
                        CleanConsole();
                        break;
                       
                    default:
                        Console.WriteLine("Fuck, something did not work.");
                        CleanConsole();
                        break;
                }
              
               if(selection == 4)
               {
                   quit = true;
               }

            }

        }

        private static void UsdMenu()
        {
            //throw new NotImplementedException();
        }

        private static void EurMenu()
        {
            //throw new NotImplementedException();
        }

        private static void SekMenu()
        {
            Console.WriteLine("--Sek Menu.--\n" +
                "Please type like this \"800 EUR\" 800 SEK to EUR");
            string valueString = Console.ReadLine();

            string[] value = valueString.Split(' ');
            double currency = Convert.ToDouble(value[0]);


            if (value[1] == "EUR")
            {
                currency = currency / currencyValue[0];
                Console.WriteLine(value[0] + "SEK is " + currency + "EUR"
                    + "\nThis is the bills and coins you will recive:\n");
                CalculateValues(currency, value[1]);
            }
            else if (value[1] == "USD")
            {
                currency = currency / currencyValue[1];
                CalculateValues(currency, value[1]);
            }
            else
            {
                Console.WriteLine("Did you write it wrong?");
            }
           
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to the currency converter.\n" +
                "Please input your current currency\n" +
                "1.SEK\n2.EUR\n3.USD\n4.Quit\n");    
        }

        static int CurrencySelector()
        {
            int temp = 0;
            string strTemp;
            strTemp = Console.ReadLine();
            if(strTemp == "1")
            {
                temp = 1;
            }
            else if (strTemp == "2")
            {
                temp = 2;
            }
            else if (strTemp == "3")
            {
                temp = 3;
            }
            else if(strTemp == "4")
            {
                temp = 4;
            }
            else
            {
                Console.WriteLine("Not a valid entery.");
                CleanConsole();
            }
            return temp;
        }

        static void CalculateValues(double value, string selectedCurrency)
        {
            double[] Currency = {};
            if(selectedCurrency == "SEK")
            {
                Currency = new double[] { 500, 100, 50, 20, 10, 1 };
            }
            else if(selectedCurrency == "EUR")
            {
                Currency = new double[] { 100, 50, 20, 10, 5, 2, 1, 0.5, 0.25, 0.10, 0.05, 0.01 };

            }
            else if (selectedCurrency == "USD")
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
                    Console.WriteLine(Currency[i] + selectedCurrency + " x " + (int)tempValue2);
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
