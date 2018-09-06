using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter_With_If_Tree
{
    class Program
    {
        static bool quit = false;

        static void Main(string[] args)
        {
            while (!quit)
            {
                MainMenu();

            }
        }

        static void MainMenu()
        {
            string selection = "";
            Console.Clear();
            Console.WriteLine("Welcome to the currency converter.\n" +
                "1. Convert to SEK\n" +
                "2. Convert to EUR\n" +
                "3. Convert to USD\n" +
                "4. Quit\n");

            selection = Console.ReadKey().KeyChar.ToString();
            Console.Clear();

            if (selection == "1") //SEK 
            {
                Console.WriteLine("You have selected SEK\n" +
                    "What amount to you want to convert?");      
                float value = 0;

                if (float.TryParse(Console.ReadLine(), out value))
                {
                    Console.Clear();
                    Console.WriteLine("You want to exchange " + value + "SEK to...?\n" +
                        "1. EUR\n" +
                        "2. USD");

                    selection = Console.ReadKey().KeyChar.ToString();
                    Console.Clear();

                    float newValue;
                    if (selection == "1") //SEK to EUR
                    {
                        newValue = value / 9.48f;
                        Console.WriteLine("You want to exchange " + value + "SEK to EUR\n" +
                            "Calculationg...\n" +
                            value + "SEK is " + newValue + "EUR");
                        CalculateValues(newValue, "SEK", "EUR");
                    }
                    else if (selection == "2") //SEK to USD
                    {
                        newValue = value / 8.08f;
                        Console.WriteLine("You want to exchange " + value + "SEK to USD\n" +
                            "Calculationg...\n" +
                            value + "SEK is " + newValue + "USD");
                        CalculateValues(newValue, "SEK", "USD");
                    }
                    else
                    {
                        CleanConsole();
                    }
                }
                else
                {
                    CleanConsole();
                }
            }
            //-----------------------------------------------------------------------------------------//
            //-----------------------------------------------------------------------------------------//
            //-----------------------------------------------------------------------------------------//

            else if (selection == "2") //EUR
            {
                Console.WriteLine("You have selected EUR\n" +
                    "What amount to you want to convert?");
                float value = 0;

                if (float.TryParse(Console.ReadLine(), out value))
                {
                    Console.Clear();
                    Console.WriteLine("You want to exchange " + value + "EUR to...?\n" +
                        "1. SEK\n" +
                        "2. USD");

                    selection = Console.ReadKey().KeyChar.ToString();
                    Console.Clear();

                    float newValue;
                    if (selection == "1") //EUR to SEK
                    {
                        newValue = value * 9.48f;
                        Console.WriteLine("You want to exchange " + value + "EUR to SEK\n" +
                            "Calculationg...\n" +
                            value + "EUR is " + newValue + "SEK");
                        CalculateValues(newValue, "EUR", "SEK");
                    }
                    else if (selection == "2") //EUR to USD
                    {
                        newValue = value / 0.85f;
                        Console.WriteLine("You want to exchange " + value + "EUR to USD\n" +
                            "Calculationg...\n" +
                            value + "EUR is " + newValue + "USD");
                        CalculateValues(newValue, "EUR", "USD");
                    }
                    else
                    {
                        CleanConsole();
                    }
                }
                else
                {
                    CleanConsole();
                }
            }

            //-----------------------------------------------------------------------------------------//
            //-----------------------------------------------------------------------------------------//
            //-----------------------------------------------------------------------------------------//

            else if (selection == "3") //USD
            {
                Console.WriteLine("You have selected SEK\n" +
                    "What amount to you want to convert?");
                float value = 0;

                if (float.TryParse(Console.ReadLine(), out value))
                {
                    Console.Clear();
                    Console.WriteLine("You want to exchange " + value + "USD to...?\n" +
                        "1. EUR\n" +
                        "2. SEK");

                    selection = Console.ReadKey().KeyChar.ToString();
                    Console.Clear();

                    float newValue;
                    if (selection == "1") //USD to EUR
                    {
                        newValue = value * 0.85f;
                        Console.WriteLine("You want to exchange " + value + "USD to EUR\n" +
                            "Calculationg...\n" +
                            value + "USD is " + newValue + "EUR");
                        CalculateValues(newValue, "USD", "EUR");
                    }
                    else if (selection == "2") //USD to SEK
                    {
                        newValue = value * 8.08f;
                        Console.WriteLine("You want to exchange " + value + "USD to SEK\n" +
                            "Calculationg...\n" +
                            value + "USD is " + newValue + "SEK");
                        CalculateValues(newValue, "USD", "SEK");
                    }
                    else
                    {
                        CleanConsole();
                    }
                }
                else
                {
                    CleanConsole();
                }
            }
            else if (selection == "4")
            {
                quit = true;
            }
            else
            {
                CleanConsole();   
            }

        }

        static void CleanConsole()
        {
            Console.WriteLine("Not a valid entry");
            Console.WriteLine("\nPress Enter to restart...");
            Console.ReadKey();
            Console.Clear();
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
                    if(Currency[i] >= 1f)
                    {
                        Console.WriteLine((int)tempValue2 + "st \t" + Currency[i] + " " + toCurrency);
                    }
                    else
                    {
                        string s_temp = Currency[i].ToString("0.00");
                        string s2_temp = s_temp.TrimStart('0','.');
                        Console.WriteLine((int)tempValue2 + "st \t" + s2_temp + " Cent " + toCurrency);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
