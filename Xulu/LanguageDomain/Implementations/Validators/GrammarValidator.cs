using System.Collections.Generic;
using System.Linq;
using Xulu.LanguageDomain.Abstracts.DomainLogics;
using Xulu.LanguageDomain.Abstracts.Validators;

namespace Xulu.LanguageDomain.Implementations.Validators
{
    public class GrammarValidator : IGrammarValidator
    {
        private readonly IVerbDomainLogic _verbDomainLogic;
        public GrammarValidator(IVerbDomainLogic verbDomainLogic)
        {
            _verbDomainLogic = verbDomainLogic;
        }
        
        public bool IsValid(string sentence)
        {
            List<int> sentenceStartIndexList = _verbDomainLogic.GetSentenceStartIndex(sentence);
            return sentenceStartIndexList.Any(index => index == 0);
        }
    }
}