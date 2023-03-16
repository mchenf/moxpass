using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace moxpass_gui.ValidationRules
{
    public class ValidateEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Input is null reference");
            }
            if(MailAddress.TryCreate(value.ToString(), out _))
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, $"{value} is not a valid email");
            }

        }
    }
}
