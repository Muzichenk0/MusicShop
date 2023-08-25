using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MusicShop.Contracts.ValidationAttributes
{
    public class PasswordAttribute : ValidationAttribute
    {
        private Regex _regex = new Regex(@"[@!#$%&*]", RegexOptions.Compiled | RegexOptions.Singleline);
        public override bool IsValid(object? value)
        {
            if (value != null && value is string valueString)
            {
                if (valueString.Any(char.IsDigit) &&
                    valueString.Any(char.IsUpper) &&
                    _regex.IsMatch(valueString))
                    return true;

                return false;
            }
            return false;
        }
    }
}
