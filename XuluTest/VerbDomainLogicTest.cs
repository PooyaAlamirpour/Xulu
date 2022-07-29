using System;
using System.Collections.Generic;
using Moq;
using Xulu;
using Xulu.LanguageDomain.Abstracts.DomainLogics;
using Xulu.LanguageDomain.Abstracts.Validators;
using Xulu.LanguageDomain.Implementations.DomainLogics;
using Xulu.LanguageDomain.Implementations.Validators;
using Xulu.LanguageDomain.Models;
using Xulu.Operands.Implementations;
using Xulu.Operands.Models;
using Xunit;

namespace XuluTest
{
    public class VerbDomainLogicTest
    {
        private readonly IVerbDomainLogic _sut;
        private readonly IVerbValidator _verbValidator;
        
        public VerbDomainLogicTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(AdditionOperand))).Returns(new AdditionOperand(new NameDomainLogic()));
            serviceProvider.Setup(x => x.GetService(typeof(SubtractionOperand))).Returns(new SubtractionOperand(new NameDomainLogic()));
            serviceProvider.Setup(x => x.GetService(typeof(MultiplicationOperand))).Returns(new MultiplicationOperand(new NameDomainLogic()));
            
            var xuluVerbs = new XuluVerbs(serviceProvider.Object);
            
            serviceProvider.Setup(x => x.GetService(typeof(XuluVerbs))).Returns(xuluVerbs);
            _verbValidator = new VerbValidator(serviceProvider.Object);
            _sut = new VerbDomainLogic(_verbValidator, xuluVerbs);
        }

        public static IEnumerable<object[]> IndexOfVerbInSentences()
        {
            yield return new object[] {"abcd bcde ab ac abcd a b", new List<int>() {0, 1, 4}};
            yield return new object[] {"abcd abcd aabbc ab a c ccd dede cccd cd", new List<int>() {0, 1, 7}};
        }
        
        public static IEnumerable<object[]> TranslateVerbToMathematicalOperation()
        {
            yield return new object[] {"abcd", MathematicalOperationEnum.Addition};
            yield return new object[] {"bcde", MathematicalOperationEnum.Subtraction};
            yield return new object[] {"dede", MathematicalOperationEnum.Multiplication};
        }
        
        [Theory]
        [InlineData("abcd", true)]
        [InlineData("bcde", true)]
        [InlineData("dede", true)]
        [InlineData("acde", false)]
        public void IsVerb_ShouldDetectsAStringIsVerb_WhenGivesAString(string str, bool expected)
        {
            // Initial
            
            // Action
            var actual = _verbValidator.IsValid(str);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(IndexOfVerbInSentences))]
        public void GetSentenceStartIndex_ShouldReturnsIndexOfStartOfEachSentence_WhenGivesASentence(string str, List<int> expected)
        {
            // Initial 
            
            // Action
            List<int> actual = _sut.GetSentenceStartIndex(str);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TranslateVerbToMathematicalOperation))]
        public void TranslateVerbToMathematicalOperation_ShouldReturnsRelatedMathOperation_WhenGivesAVerb(string verb, MathematicalOperationEnum expected)
        {
            // Initial 
            
            // Action
            MathematicalOperationEnum actual = _sut.TranslateVerbToMathematicalOperation(verb);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}