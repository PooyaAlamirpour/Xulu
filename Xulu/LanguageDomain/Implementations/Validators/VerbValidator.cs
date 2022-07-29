using System;
using System.Linq;
using Xulu.LanguageDomain.Abstracts.Validators;
using Xulu.LanguageDomain.Models;

namespace Xulu.LanguageDomain.Implementations.Validators
{
    public class VerbValidator : IVerbValidator
    {
        private readonly XuluVerbs _verbs;
        public VerbValidator(IServiceProvider serviceProvider)
        {
            _verbs = new XuluVerbs(serviceProvider);
        }
        
        public bool IsValid(string verb) => _verbs.List.Any(x => x.Key.Equals(verb));
    }
}