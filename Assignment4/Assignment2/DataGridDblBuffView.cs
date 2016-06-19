using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// DataGridDblBuffView class.
    /// This class is to enable DoubleBufferd property.
    /// </summary>
    public class DataGridDblBuffView : DataGridView
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public DataGridDblBuffView()
        {
            this.DoubleBuffered = true;
        }
    }
}
