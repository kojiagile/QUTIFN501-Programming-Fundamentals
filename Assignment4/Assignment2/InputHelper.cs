using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// InputHelper class
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// Check if the character is appropriate for controls 
        /// that allows to input numeric, backspace, delete and dot(.).
        /// </summary>
        /// <param name="keyChar"></param>
        /// <returns></returns>
        public static bool IsNumericWithDotAndEraseKey(char keyChar)
        {
            if ((keyChar < '0' || '9' < keyChar)
                && keyChar != '\b'
                && keyChar != '.'
                && keyChar.ToString() != Keys.Delete.ToString())
            {
                //The value is not a numeric, backspace, delete or dot.
                return false;
            }
            return true;
        }
    }
}
