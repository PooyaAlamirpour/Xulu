using System;
using System.Collections.Generic;
using System.Linq;
using Xulu.LanguageDomain.Abstracts;
using Xulu.LanguageDomain.Abstracts.DomainLogics;
using Xulu.LanguageDomain.Abstracts.Validators;
using Xulu.Operands.Abstracts;

namespace Xulu.LanguageDomain.Implementations.DomainLogics
{
    public class ComputeEquivalent : IComputeEquivalent
    {
        private readonly INameValidator _nameValidator;
        private readonly ISentenceDomainLogic _sentenceDomainLogic;
        private readonly IVerbDomainLogic _verbDomainLogic;
        private readonly IMathematicalOperationFactory _mathematicalOperationFactory;
        public ComputeEquivalent(ISentenceDomainLogic sentenceDomainLogic, 
            IVerbDomainLogic verbDomainLogic, 
            IMathematicalOperationFactory 
                mathematicalOperationFactory, 
            INameValidator nameValidator)
        {
            _sentenceDomainLogic = sentenceDomainLogic;
            _verbDomainLogic = verbDomainLogic;
            _mathematicalOperationFactory = mathematicalOperationFactory;
            _nameValidator = nameValidator;
        }
        
        public int ComputeSentenceEquivalentNumber(string inputSentence)
        {
            var splitSentence = inputSentence.Split(' ');
            var isValidWord = splitSentence.All(word => _nameValidator.IsValid(word));
            if (!isValidWord) throw new ArgumentException("There is at least an invalid word inside of the sentence.");

            var sumOfEquivalentNumber = 0;
            
            List<string> separatedSentenceList = _sentenceDomainLogic.SeparateSentences(inputSentence);
            foreach (var sentence in separatedSentenceList)
            {
                var separateWordList = sentence.Split(' ');
                if (separateWordList.Length <= 1) continue;
                
                var operand = _verbDomainLogic.TranslateVerbToMathematicalOperation(separateWordList.First());
                var restPartOfSentence = separateWordList.Where((x, index) => index >= 1).ToList();
                
                var mathematicalOperation = _mathematicalOperationFactory.Create(operand);
                var equivalentNumber = mathematicalOperation.Calculate(restPartOfSentence);
                sumOfEquivalentNumber += equivalentNumber;
            }

            return sumOfEquivalentNumber;
        }
    }
}