using System;
using System.Collections.Generic;
using Xulu.LanguageDomain.Abstracts.DomainLogics;
using Xulu.LanguageDomain.Abstracts.Validators;
using Xulu.LanguageDomain.Implementations.Validators;
using Xulu.LanguageDomain.Models;
using Xulu.Operands.Models;

namespace Xulu.LanguageDomain.Implementations.DomainLogics
{
    public class VerbDomainLogic : IVerbDomainLogic
    {
        private readonly IVerbValidator _verbValidator;
        private readonly XuluVerbs _verbs;
        public VerbDomainLogic(IVerbValidator verbValidator, XuluVerbs verbs)
        {
            _verbValidator = verbValidator;
            _verbs = verbs;
        }
        
        public List<int> GetSentenceStartIndex(string sentence)
        {
            List<int> sentenceStartIndexList = new();
            string[] splitSentence = sentence.Split(' ');
            
            for (int i = 0; i < splitSentence.Length; i++)
            {
                if(_verbValidator.IsValid(splitSentence[i])) sentenceStartIndexList.Add(i);                
            }

            return sentenceStartIndexList;
        }

        public MathematicalOperationEnum TranslateVerbToMathematicalOperation(string verb)
        {
            if (_verbValidator.IsValid(verb))
            {
                return _verbs.List[verb];
            }

            throw new ArgumentException("The requested verb is not valid");
        }
    }
}