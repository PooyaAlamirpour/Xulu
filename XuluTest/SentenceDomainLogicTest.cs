using System;
using System.Collections.Generic;
using Moq;
using Xulu;
using Xulu.LanguageDomain.Abstracts.DomainLogics;
using Xulu.LanguageDomain.Implementations.DomainLogics;
using Xulu.LanguageDomain.Implementations.Validators;
using Xulu.LanguageDomain.Models;
using Xulu.Operands.Implementations;
using Xunit;

namespace XuluTest
{
    public class SentenceDomainLogicTest
    {
        private readonly ISentenceDomainLogic _sut;
        
        public SentenceDomainLogicTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(AdditionOperand))).Returns(new AdditionOperand(new NameDomainLogic()));
            serviceProvider.Setup(x => x.GetService(typeof(SubtractionOperand))).Returns(new SubtractionOperand(new NameDomainLogic()));
            serviceProvider.Setup(x => x.GetService(typeof(MultiplicationOperand))).Returns(new MultiplicationOperand(new NameDomainLogic()));
            
            var xuluVerbs = new XuluVerbs(serviceProvider.Object);
            serviceProvider.Setup(x => x.GetService(typeof(XuluVerbs))).Returns(xuluVerbs);
            _sut = new SentenceDomainLogic(new VerbDomainLogic(new VerbValidator(serviceProvider.Object), xuluVerbs));
        }
        
        public static IEnumerable<object[]> SeperatedSentences()
        {
            yield return new object[] {"abcd bcde ab ac abcd a b", new List<string>() {"abcd", "bcde ab ac", "abcd a b"} };
            yield return new object[] {"abcd abcd aabbc ab a c ccd dede cccd cd", new List<string>() {"abcd", "abcd aabbc ab a c ccd", "dede cccd cd"} };
        }
        
        [Theory]
        [MemberData(nameof(SeperatedSentences))]
        public void SeparateSentences_ShouldSeparateTheGivenSentence_WhenGivesSentences(string sentences, List<string> expected)
        {
            // Initial 
            
            // Action
            List<string> actual = _sut.SeparateSentences(sentences);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}