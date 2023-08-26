
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.ValidationAttributes
{
    internal class MinValueAttribute : ValidationAttribute
    {
        private double _minDouble { get; set; }
        public MinValueAttribute(double minDouble) => _minDouble = minDouble;
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            else if (double.TryParse((string)value, out double doubleRes))
                if (doubleRes <= _minDouble)
                    return true;

                else return false;

            return false;
        }
    }
}
