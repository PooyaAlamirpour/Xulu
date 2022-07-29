using System;
using System.Collections.Generic;
using Moq;
using Xulu;
using Xulu.LanguageDomain.Abstracts;
using Xulu.LanguageDomain.Abstracts.Validators;
using Xulu.LanguageDomain.Implementations;
using Xulu.LanguageDomain.Implementations.DomainLogics;
using Xulu.LanguageDomain.Implementations.Validators;
using Xulu.LanguageDomain.Models;
using Xulu.Operands;
using Xulu.Operands.Implementations;
using Xunit;

namespace XuluTest
{
    public class ComputeEquivalentNumberOfSentenceTest
    {
        private readonly IComputeEquivalent _sut;
        private readonly IGrammarValidator _grammarValidator;
        
        public ComputeEquivalentNumberOfSentenceTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(AdditionOperand))).Returns(new AdditionOperand(new NameDomainLogic()));
            serviceProvider.Setup(x => x.GetService(typeof(SubtractionOperand))).Returns(new SubtractionOperand(new NameDomainLogic()));
            serviceProvider.Setup(x => x.GetService(typeof(MultiplicationOperand))).Returns(new MultiplicationOperand(new NameDomainLogic()));
            
            var xuluVerbs = new XuluVerbs(serviceProvider.Object);
            serviceProvider.Setup(x => x.GetService(typeof(XuluVerbs))).Returns(xuluVerbs);
            
            var verbValidator = new VerbValidator(serviceProvider.Object);
            var verbDomainLogic = new VerbDomainLogic(verbValidator, xuluVerbs);
                
            _sut = new ComputeEquivalent(
                new SentenceDomainLogic(new VerbDomainLogic(verbValidator, xuluVerbs)), 
                new VerbDomainLogic(verbValidator, xuluVerbs), 
                new MathematicalOperationFactory(serviceProvider.Object), 
                new NameValidator());
            _grammarValidator = new GrammarValidator(verbDomainLogic);
        }

        public static IEnumerable<object[]> EquivalentNumberOfSentences()
        {
            yield return new object[] {"abcd abcd aabbc ab a c ccd dede cccd cd", 861};
        }
        
        [Theory]
        [MemberData(nameof(EquivalentNumberOfSentences))]
        public void ComputeEquivalentNumberOfSentence(string str, int expected)
        {
            // Initial
            int actual = 0;
            
            // Action
            if (_grammarValidator.IsValid(str))
            {
                actual = _sut.ComputeSentenceEquivalentNumber(str);
            }
            
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}