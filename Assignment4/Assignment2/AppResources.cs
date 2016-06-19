using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// AppResources class.
    /// </summary>
    public static class AppResources
    {
        // List box 
        public const string DISP_MEMBER_CATA_LIST_BOX = "CatalogueName";
        
        // Combo box data 
        public const string NAME_DT_CATE_COMBO_DATA_SRC = "categoryTable";

        // Category combo box
        public const string DISP_MEMBER_CATE_COMBO = "Display";
        public const string VAL_MEMBER_CATE_COMBO = "Value";

        // Header text name
        public const string NAME_GRID_HEADER_TEXT_CATEGORY = "Category";
        public const string NAME_GRID_HEADER_TEXT_PRD_NAME = "Product Name";
        public const string NAME_GRID_HEADER_TEXT_RET_PRICE = "Retail Price";
        public const string NAME_GRID_HEADER_NAME_CATEGORY = "Category";
        public const string NAME_GRID_HEADER_NAME_PRD_NAME = "ProductName";
        public const string NAME_GRID_HEADER_NAME_RET_PRICE = "RetailPrice";
        // Combo box in the data grid view
        public const string DISP_MEMBER_GRID_CATE_COMBO_DISP = "Display";
        public const string VAL_MEMBER_GRID_CATE_COMBO = "Value";

        // Median calculate list 
        public const string NAME_CALC_MEDIAN_CATA_LIST_NAME = "catalogOfAllProducts";

        // Message box captions
        public const string MSG_CAP_ERROR = "Error";
        public const string MSG_CAP_INFO = "Information";
        public const string MSG_CAP_CONF = "Confirmation";

        // Messages
        public const string MSG_NO_CATALOGUES = "No catalogues exist.";
        public const string MSG_CATE_SELECTED_TO_DELETE = "Please select a catalogue you would like to delete.";
        public const string MSG_SELECT_CATALOGUE = "Please select a catalogue.";
        public const string MSG_FILL_OUT_FORM = "Please fill out the form with correct data.";
        public const string MSG_CANNOT_BE_EMPTY = "The cell cannot be empty.\nPlease enter value, or press ESC key to cancell updating.";
        public const string MSG_MEDIAN_PRICE = "Median Price: \nThis catalogue: {0:c2} \nAross all catalogues: {1:c2}";

        // Confirmation messages
        public const string MSG_ASK_DELETE_CATA = "Are you sure you would like to delete the catalogue?";
        public const string MSG_ASK_DELETE_PRD = "Are you sure you would like to delete the product?";
        public const string MSG_INFO_FILE_IMPORTED = "The file has been Imported.";
        public const string MSG_INFO_FILE_EXPORTED = "The file has been generated.";

        //Exception messages
        public const string EXP_MSG_EXP = "System error has occured.";
        public const string EXP_MSG_IO_EXP = "File I/O error has occured.\nPlease check if a file exists, or is opened by another application.";
        


        /// <summary>
        /// Initialize category combo box
        /// </summary>
        public static void InitializeCategoryCombo(ComboBox CboxCategory)
        {
            CboxCategory.DataSource = Enum.GetValues(typeof(Categories));
            CboxCategory.DisplayMember = AppResources.DISP_MEMBER_GRID_CATE_COMBO_DISP;
            CboxCategory.ValueMember = AppResources.VAL_MEMBER_GRID_CATE_COMBO;
        }

    }
}
