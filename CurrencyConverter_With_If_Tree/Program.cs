using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValCon
{
    class Program
    {
        static bool quit = false;

        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                ConvertMoney(args);
                quit = true;
            }

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
                "1. Convert SEK\n" +
                "2. Convert EUR\n" +
                "3. Convert USD\n" +
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
                        newValue = (float)Math.Round(value / 9.48f, 2);
                        Console.WriteLine("You want to exchange " + value + "SEK to EUR\n" +
                            "Calculationg...\n" +
                            value + "SEK is " + newValue + "EUR");
                        CalculateValues(newValue, "SEK", "EUR");
                    }
                    else if (selection == "2") //SEK to USD
                    {
                        newValue = (float)Math.Round(value / 8.08f, 2);
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
                        newValue = (float)Math.Round(value * 9.48);
                        
                        Console.WriteLine("You want to exchange " + value + "EUR to SEK\n" +
                            "Calculationg...\n" +
                            value + "EUR is " + newValue + "SEK");
                        CalculateValues(newValue, "EUR", "SEK");
                    }
                    else if (selection == "2") //EUR to USD
                    {
                        newValue = (float)Math.Round( value / 0.85f, 2);
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
                        newValue = (float)Math.Round(value * 0.85f, 2);
                        Console.WriteLine("You want to exchange " + value + "USD to EUR\n" +
                            "Calculationg...\n" +
                            value + "USD is " + newValue + "EUR");
                        CalculateValues(newValue, "USD", "EUR");
                    }
                    else if (selection == "2") //USD to SEK
                    {
                        newValue = (float)Math.Round(value * 8.08);
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

        private static void ConvertMoney(string[] argument)
        {
            string[] value = { "", "", "" }; // Amount, from, to
            float[] currencyValue = { 8.08f, 9.48f, 0.85f }; //us-sek, eu-sek, us-eur

            for (int i = 1; i <= 2; i++)
            {
                argument[i] = argument[i].ToUpper();
            }

            value = argument;
            float amount;
            if( !float.TryParse(value[0], out amount)) //Convert value[0] to an int
            {
                Console.WriteLine("Conversion Failed, Syntax error");
            }

            if ((value[1] == "SEK") && (value[2] == "EUR"))
            {
                Console.WriteLine(amount + " " + currencyValue[0]);
                amount = amount / currencyValue[1];
            }
            else if ((value[1] == "SEK") && (value[2] == "USD"))
            {
                Console.WriteLine(amount + " " + currencyValue[0]);
                amount = amount / currencyValue[0];
            }
            else if ((value[1] == "EUR") && (value[2] == "SEK"))
            {
                Console.WriteLine(amount + " " + currencyValue[0]);
                amount = (float)Math.Round( amount * currencyValue[1]);
            }
            else if ((value[1] == "EUR") && (value[2] == "USD"))
            {
                Console.WriteLine(amount + " " + currencyValue[0]);
                amount = amount / currencyValue[2];
            }
            else if ((value[1] == "USD") && (value[2] == "SEK"))
            {
                Console.WriteLine(amount + " " + currencyValue[0]);
                amount = (float)Math.Round( amount * currencyValue[0]);
            }
            else if ((value[1] == "USD") && (value[2] == "EUR"))
            {
                Console.WriteLine(amount + " " + currencyValue[0]);
                amount = amount * currencyValue[2];
            }
            else
            {
                CleanConsole();
            }

            amount = (float)Math.Round(amount, 2);

            Console.Clear();
            Console.WriteLine(value[0] + " " + value[1] + " converted to " + amount + " " + value[2]);
            CalculateValues(amount, value[1], value[2]);
        }


        static void CalculateValues(float value, string fromCurrency, string toCurrency)
        {
            float[] Currency = { };
            if (toCurrency == "SEK")
            {
                Currency = new float[] { 500f, 100f, 50f, 20f, 10f, 1f };
            }
            else if (toCurrency == "EUR")
            {
                Currency = new float[] { 500f, 200f, 100f, 50f, 20f, 10f, 5f, 2f, 1f, 0.50f, 0.20f, 0.10f, 0.05f, 0.02f, 0.01f };
            }
            else if (toCurrency == "USD")
            {
                Currency = new float[] { 100f, 50f, 20f, 10f, 5f, 2f, 1f, 0.50f, 0.25f, 0.10f, 0.05f, 0.01f };
            }


            float tempValue = 0;
            float tempValue2 = 0;

            for (int i = 0; i < Currency.Length; i++)
            {

                tempValue = (float)Math.Round( value % Currency[i], 2);
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
