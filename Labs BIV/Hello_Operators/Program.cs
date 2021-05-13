using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators_stud
{
    class Program
    {
        
        static void Main(string[] args)
        {
            long a;
            Console.Write(@"Please,  type the number:
            1. Farmer, wolf, goat and cabbage puzzle
            2. Console calculator
            3. Factirial calculation

            to EXIT: press enter only

Your choice: ");

            string res = Console.ReadLine();
            try
            {
                a = long.Parse((res == "" ? "0" : res) ?? "0");
            } catch(Exception e)
            {
                a = -1;
            }
            
            switch (a)
            {
                case 1:
                    Farmer_puzzle();
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.Clear();
                    Calculator();
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.Clear();
                    Factorial_calculation();
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.ResetColor();
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        // Prints the specified number of empty console screen rows
        //
        static void PrintEmptyLines(int nLinesQuantity)
        {
            for (int i = 0; i <= nLinesQuantity; i++) Console.WriteLine();
        }

        // Prints the specified number of space character
        //
        static void PrintEmptySymbol(int nSymbolsQuantity)
        {
            for (int i = 0; i <= nSymbolsQuantity; i++) Console.Write(" ");
        }

        static void PostMessage(string sMsg, bool bPressKeyMsg = false)
        {
            Console.Clear();
            
            int nLinesQuantityStart = Console.WindowHeight / 2 - 2;
            PrintEmptyLines(nLinesQuantityStart);

            PrintEmptySymbol((Console.WindowWidth - sMsg.Length) / 2);
            Console.WriteLine(sMsg.ToUpper());
            
            int nLinesQuantityEnd = Console.WindowHeight - nLinesQuantityStart - (bPressKeyMsg ? 7 : 6);
            PrintEmptyLines(nLinesQuantityEnd);
            if (bPressKeyMsg) 
            {
                Console.ResetColor();
                Console.WriteLine("Press any key"); 
            }
        }

        static bool ConfirmationRequest()
        {
            string sRequest = "Are You sure? (Y/N): ";
            Console.Clear();

            int nLinesQuantityStart = Console.WindowHeight / 2 - 2;
            PrintEmptyLines(nLinesQuantityStart);

            PrintEmptySymbol((Console.WindowWidth - sRequest.Length) / 2);
            Console.ResetColor();
            Console.Write(sRequest);

            string sEnteredSymbol = Console.ReadLine();

            if (sEnteredSymbol.ToLower() == "y") return true;

            return false;
        }

        #region farmer
        static void Farmer_puzzle()
        {
            //Key sequence: 3817283 or 3827183
            // Declare 7 int variables for the input numbers and other variables

            int nGameResult, nParsedSymbol, nIter = 0;
            string sEnteredSymbol;
            StringBuilder sbEnteredDigits = new StringBuilder("", 7);

            while (true)
            {
                nIter++;
                Console.Clear();
                FarmerPuzzleInfo();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please, type numbers by step: {0}", sbEnteredDigits.ToString());
                sEnteredSymbol = Console.ReadLine();

                if (sEnteredSymbol.ToLower() == "q") // user wants to quit the game
                {
                    if (ConfirmationRequest())
                    {
                        PostMessage("Bye bye...");
                        return;
                    }

                    nIter--;
                    continue;
                }
                
                nParsedSymbol = -1;
                try
                {
                    nParsedSymbol = int.Parse((sEnteredSymbol == "" ? "0" : sEnteredSymbol) ?? "0");
                } catch(Exception e)
                {
                    PostMessage("Incorrect input...", true);
                    Console.ReadKey();
                    nIter--;
                    continue;
                }

                if(nParsedSymbol < 1 || nParsedSymbol > 3827183)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    PostMessage("Incorrect input. Try again.. )", true);
                    Console.ReadKey();
                    continue;
                }

                sbEnteredDigits.Append(nParsedSymbol);

                if (sbEnteredDigits.Length >= 7) break;
            }

            Console.WriteLine("Result checking...");

            try
            {
                nGameResult = int.Parse(sbEnteredDigits.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            switch (nGameResult)
            {
                case 3817283:
                case 3827183:
                    PostMessage("Congrats! You won!");
                    break;
                default:
                    PostMessage("You lost... Try again");
                    break;
            }
               
        }

        static void FarmerPuzzleInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PUZZLE: the farmer, wolf, goat and cabbage\n");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"From one bank to another should carry a wolf, goat and cabbage. 
At the same time can neither carry nor leave together on the banks of a wolf and a goat, 
a goat and cabbage. You can only carry a wolf with cabbage or as each passenger separately. 
You can do whatever how many flights. How to transport the wolf, goat and cabbage that all went well?" + "\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t" + @"THERE:
            1. Farmer and wolf
            2. Farmer and cabbage
            3. Farmer and goat
            4. Farmer" + "\n");
            Console.WriteLine("\t" + @"BACK:
            5. Farmer and wolf
            6. Farmer and cabbage
            7. Farmer and goat
            8. Farmer" + "\n");
        }
        #endregion

        #region calculator
        static void Calculator()
        {
            // Set Console.ForegroundColor  value
            Console.WriteLine(@"Select the arithmetic operation:
1. Multiplication 
2. Divide 
3. Addition 
4. Subtraction
5. Exponentiation ");
            // Implement option input (1,2,3,4,5)
            //     and input of  two or one numbers
            //  Perform calculations and output the result 
        }
        #endregion

        #region Factorial
        static void Factorial_calculation()
        {
            // Implement input of the number
            // Implement input the for circle to calculate factorial of the number
            // Output the result
        }
        #endregion
    }
}
