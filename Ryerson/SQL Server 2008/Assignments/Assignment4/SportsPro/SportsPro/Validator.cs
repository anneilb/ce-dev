using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SportsPro
{
    public static class Validator
    {
        public static bool IsPresent(Control ctlControl, string strName)
        {
            bool blnResult = false;

            if (ctlControl.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox txtTextBox = (TextBox)ctlControl;

                if (txtTextBox.Text.Length == 0)
                {
                    ShowError(strName + " is a required field.");
                    txtTextBox.Focus();
                }
                else
                {
                    blnResult = true;
                }
            }
            else if (ctlControl.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox cboComboBox = (ComboBox)ctlControl;

                if (cboComboBox.SelectedIndex == -1)
                {
                    ShowError(strName + " is a required field.");
                    cboComboBox.Focus();
                }
                else
                {
                    blnResult = true;
                }
            }

            return blnResult;
        }

        public static bool IsNumeric(Control ctlControl, string strName)
        {
            bool blnResult = false;
            int intTemp = 0;

            if (ctlControl.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox txtTextBox = (TextBox)ctlControl;

                if (!int.TryParse(txtTextBox.Text, out intTemp))
                {
                    ShowError(strName + " must be a numeric value.");
                    txtTextBox.Focus();
                }
                else
                {
                    blnResult = true;
                }
            }

            return blnResult;
        }

        public static bool IsLength(Control ctlControl, string strName, int intLength)
        {
            bool blnResult = false;

            if (ctlControl.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox txtTextBox = (TextBox)ctlControl;

                if (txtTextBox.Text.Length != intLength)
                {
                    ShowError(string.Format(strName + " must be at least {0} characters long.", intLength));
                    txtTextBox.Focus();
                }
                else
                {
                    blnResult = true;
                }
            }

            return blnResult;
        }

        public static void ShowError(string text)
        {
            MessageBox.Show(text, "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
