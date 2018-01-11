using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_40_2016_GUI.UI
{
    class ValidationDouble:ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                string unos = value as string;
                double v = double.Parse(unos);
                if (v > 0)
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
