using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEx3
{
    /// <summary>
    /// Input Helper class.
    /// </summary>
    public static class InputHelper
    {

        /// <summary>
        /// Get an int number from user via console.
        /// </summary>
        /// <param name="message">A message to be displayed on console.</param>
        /// <param name="maxNum">A minimum number that user can enter.</param>
        /// <param name="maxNum">A muximum number that user can enter.</param>
        /// <returns>A int number user enters.</returns>
        public static int GetIntFromUser(string message, int minNum, int maxNum)
        {
            int ret = 0;
            do
            {
                Console.Write(message);
                //A number that a user enters has to be between minNum and maxNum
            } while (!int.TryParse(Console.ReadLine(), out ret) || ret < minNum || ret > maxNum);
            return ret;
        }


        /// <summary>
        /// Get string value (name, etc.) from user via console.
        /// </summary>
        /// <param name="message">A message to be displayed.</param>
        /// <returns>A string value user enters.</returns>
        public static string GetStringFromUser(string message)
        {
            string name = null;
            do
            {
                Console.Write(message);
                name = Console.ReadLine();
            } while (name == string.Empty || name == null);
            return name;
        }


        /// <summary>
        /// Get a double number from user via console.
        /// </summary>
        /// <param name="message">A message to be displayed.</param>
        /// <returns>A positive double numerical number.</returns>
        public static double GetPositiveDoubleFromUser(string message)
        {
            double ret = 0.0;
            do
            {
                Console.Write(message);
            } while (!double.TryParse(Console.ReadLine(), out ret) || ret < 0);

            return ret;
        }

    }
}
