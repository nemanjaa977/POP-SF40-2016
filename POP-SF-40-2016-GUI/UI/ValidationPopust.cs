using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_40_2016_GUI.UI
{
    class ValidationPopust:ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                string j = value as string;
                int v = int.Parse(j);
                if (v > 0 && v < 99)
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, null);
            }
            catch (Exception)
            {
                return new ValidationResult(false, null);

            }
        }
    }
}
