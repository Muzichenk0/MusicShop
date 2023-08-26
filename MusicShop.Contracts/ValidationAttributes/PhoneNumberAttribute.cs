using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace MusicShop.Contracts.ValidationAttributes
{
    internal sealed class PhoneNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object? obj)
        {
            IList<ValidationResult> validationResults = new List<ValidationResult>();
            if (!(obj is string number))
            {
                validationResults.Add(new ValidationResult($"{nameof(obj)} isn't string"));
                return false;
            }
            Regex phoneNumberRegex = new Regex(@"^\+\d{1}-\d{3}-\d{3}-\d{2}-\d{2}", RegexOptions.Compiled | RegexOptions.Singleline);
            if (phoneNumberRegex.IsMatch(number))
                return true;
            return false;
        }
    }
}
