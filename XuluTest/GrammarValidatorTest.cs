using System;
using System.Collections.Generic;
using Moq;
using Xulu;
using Xulu.LanguageDomain.Abstracts.Validators;
using Xulu.LanguageDomain.Implementations.DomainLogics;
using Xulu.LanguageDomain.Implementations.Validators;
using Xulu.LanguageDomain.Models;
using Xulu.Operands.Implementations;
using Xunit;

namespace XuluTest
{
    public class GrammarValidatorTest
    {
        
        private readonly IGrammarValidator _sut;
        
        public GrammarValidatorTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(AdditionOperand))).Returns(new AdditionOperand(new NameDomainLogic()));
            serviceProvider.Setup(x => x.GetService(typeof(SubtractionOperand))).Returns(new SubtractionOperand(new NameDomainLogic()));
            serviceProvider.Setup(x => x.GetService(typeof(MultiplicationOperand))).Returns(new MultiplicationOperand(new NameDomainLogic()));
            
            var xuluVerbs = new XuluVerbs(serviceProvider.Object);
            serviceProvider.Setup(x => x.GetService(typeof(XuluVerbs))).Returns(xuluVerbs);
            _sut = new GrammarValidator(new VerbDomainLogic(new VerbValidator(serviceProvider.Object), xuluVerbs));
        }
        
        public static IEnumerable<object[]> Sentences()
        {
            yield return new object[] {"abcd bcde ab ac abcd a b", true};
            yield return new object[] {"abcd abcd aabbc ab a c ccd dede cccd cd", true};
            yield return new object[] {"ccd abcd abcd aabbc ab a c dede cccd cd", false};
        }
        
        [Theory]
        [MemberData(nameof(Sentences))]
        public void HasValidGrammar_ShouldCheckTheGrammar_WhenGivesASentence(string str, bool expected)
        {
            // Initial 
            
            // Action
            bool actual = _sut.IsValid(str);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}