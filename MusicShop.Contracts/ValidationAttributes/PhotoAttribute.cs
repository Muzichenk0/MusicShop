
using MusicShop.Contracts.File;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MusicShop.Contracts.ValidationAttributes
{
    internal class PhotoCollectionAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            IList<ValidationResult> validationResults = new List<ValidationResult>();
            try
            {
                if (value is null)
                    throw new ArgumentNullException($"{nameof(value)} is null");

                if (!(value is ICollection<SiteFileInfoResponse> siteFileEnum))
                {
                    validationResults.Add(new ValidationResult($"{value} is not a {typeof(SiteFileInfoResponse)} typed object"));
                    return false;
                }

                Regex photoCheckRegex = new Regex(@"[png jpeg]");

                foreach (SiteFileInfoResponse? file in siteFileEnum)
                {
                    if (file is null)
                        throw new ArgumentNullException(file.Name);

                    else if (photoCheckRegex.IsMatch(file.Extension))
                        return true;

                    validationResults.Add(new ValidationResult($"{file.Name} is not a photo. Extension: {file.Extension}"));
                    return false;
                }
            }
            catch (Exception ex)
            {
                validationResults.Add(new ValidationResult(ex.Message));
                return false;
            }
            return false;
        }
    }
}
