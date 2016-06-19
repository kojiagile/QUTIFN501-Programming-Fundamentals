using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN501Assignment1
{
    class Program
    {
        const string ADD_SYMBOL = "+";
        const string SUBTRACT_SYNBOL = "-";
        const string MULTIPLY_SYNBOL = "*";
        const string DIVIDE_SYNBOL = "/";

        /// <summary>
        /// IFN 501  Programming Fundamentals Assignment 1 Program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string useOperator = null;
            do
            {
                //wait for user input 
                Console.Write("Please choose an operation (" + ADD_SYMBOL + ", " + SUBTRACT_SYNBOL + ", "
                    + MULTIPLY_SYNBOL + ", " + DIVIDE_SYNBOL + "): ");
                useOperator = Console.ReadLine();

            //repeat until user enters either +, -, * or /
            } while (useOperator != ADD_SYMBOL && useOperator != SUBTRACT_SYNBOL 
                && useOperator != MULTIPLY_SYNBOL && useOperator != DIVIDE_SYNBOL);

            double firstNum;
            double secondNum;
            double result = 0;

            //wait that user inputs two operands.
            EnterOperands(out firstNum, out secondNum);

            //check the second number to avoid dividing by 0(zero).
            while(!CanDivide(useOperator, secondNum))
            {
                Console.WriteLine("Cannot divide by 0. Please enter another number.");
                secondNum = GetNumberFromUser("second");
            }

            switch (useOperator)
            {
                case ADD_SYMBOL:
                    result = AddNumber(firstNum, secondNum);
                    break;
                case SUBTRACT_SYNBOL:
                    result = SubtractNumber(firstNum, secondNum);
                    break;
                case MULTIPLY_SYNBOL:
                    result = MultiplyNumber(firstNum, secondNum);
                    break;
                case DIVIDE_SYNBOL:
                    result = DivideNumber(firstNum, secondNum);
                    break;
            }

            Console.WriteLine("The result of " + firstNum + " " + useOperator + " " + secondNum + " is: " + result);
            Console.ReadLine();
        }


        /// <summary>
        /// User enters two operands and set them to the parameters.
        /// </summary>
        /// <param name="first">first operand</param>
        /// <param name="second">second operand</param>
        private static void EnterOperands(out double firstNum, out double secondNum)
        {
            firstNum = GetNumberFromUser("first");
            secondNum = GetNumberFromUser("second");
        }

        /// <summary>
        /// Check if the first number can be divided by the second number.
        /// When the useOperator is not "/", the method always returns true.
        /// </summary>
        /// <param name="useOperator">the operand user input.</param>
        /// <param name="secondNum">second operand</param>
        /// <returns></returns>
        private static bool CanDivide(string useOperator, double secondNum)
        {
            bool ret = true;
            if (useOperator == DIVIDE_SYNBOL && secondNum == 0)
            {
                ret = false;
            }

            return ret;
        }

        /// <summary>
        /// User enters a number.
        /// When the user input cannot be converted to a double, repeat entering.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static double GetNumberFromUser(string str)
        {
            double ret = 0;
            do
            {
                Console.Write("Please enter " + str + " operand: ");

            } while (!double.TryParse(Console.ReadLine(), out ret));

            return ret;
        }

        /// <summary>
        /// Add first number with second number.
        /// </summary>
        /// <param name="first">first operand</param>
        /// <param name="second">second operand</param>
        /// <returns></returns>
        private static double AddNumber(double first, double second)
        {
            return first + second;
        }

        /// <summary>
        /// Subtract second number from first number.
        /// </summary>
        /// <param name="first">first operand</param>
        /// <param name="second">second operand</param>
        /// <returns></returns>
        private static double SubtractNumber(double first, double second)
        {
            return first - second;
        }

        /// <summary>
        /// Multiply first number by second number 
        /// </summary>
        /// <param name="first">first operand</param>
        /// <param name="second">second operand</param>
        /// <returns></returns>
        private static double MultiplyNumber(double first, double second)
        {
            return first * second;
        }

        /// <summary>
        /// Divide first number by second number.
        /// </summary>
        /// <param name="first">first operand</param>
        /// <param name="second">second operand</param>
        /// <returns></returns>
        private static double DivideNumber(double first, double second)
        {
            return first / second;
        }
    }
}
