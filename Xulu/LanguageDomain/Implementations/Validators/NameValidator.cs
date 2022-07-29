using System.Linq;
using Xulu.LanguageDomain.Abstracts.Validators;

namespace Xulu.LanguageDomain.Implementations.Validators
{
    public class NameValidator : INameValidator
    {
        public bool IsValid(string str) => !str.Any(ch => ch > 'e' || ch < 'a');
    }
}