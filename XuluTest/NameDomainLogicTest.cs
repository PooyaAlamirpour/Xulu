using System.Collections.Generic;
using Xulu;
using Xulu.LanguageDomain.Abstracts.DomainLogics;
using Xulu.LanguageDomain.Abstracts.Validators;
using Xulu.LanguageDomain.Implementations.DomainLogics;
using Xulu.LanguageDomain.Implementations.Validators;
using Xunit;

namespace XuluTest
{
    public class NameDomainLogicTest
    {
        private readonly INameDomainLogic _sut;
        private readonly INameValidator _nameValidator;

        public NameDomainLogicTest()
        {
            _sut = new NameDomainLogic();
            _nameValidator = new NameValidator();
        }

        public static IEnumerable<object[]> RepeatedAlphabets()
        {
            yield return new object[] {"aabbcccca", new List<string>() {"aa", "bb", "cccc", "a"}};
            yield return new object[] {"aabbccccaa", new List<string>() {"aa", "bb", "cccc", "aa"}};
            yield return new object[] {"aabbccccaae", new List<string>() {"aa", "bb", "cccc", "aa", "e"}};
            yield return new object[] {"abcd", new List<string>() {"a", "b", "c", "d"}};
        }

        public static IEnumerable<object[]> EquivalentNumber()
        {
            yield return new object[] {new List<string>() {"aa", "bb", "cccc", "a"}, new List<int>() {2, 4, 12, 1}};
        }
        
        public static IEnumerable<object[]> Mod5()
        {
            yield return new object[] {new List<int>() {2, 4, 12, 1}, new List<int>() {2, 4, 2, 1}};
        }
        
        public static IEnumerable<object[]> SumOfSquare()
        {
            yield return new object[] {new List<int>() {2, 4, 2, 1}, 25};
        }
        
        [Theory]
        [InlineData("abcdea", true)]
        [InlineData("abxdea", false)]
        public void IsValidName_ShouldCheckAllAlphabetsForBeingValid_WhenGivesAString(string str, bool expected)
        {
            // Initial
            
            // Action
            var result = _nameValidator.IsValid(str);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(RepeatedAlphabets))]
        public void BreakRepeatedAlphabets_ShouldDetectRepeatedCharAndSplitThose_WhenGivesAString(string str, List<string> expected)
        {
            // Initial 
            
            // Action
            List<string> result = _sut.BreakRepeatedAlphabets(str);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(EquivalentNumber))]
        public void ComputeEquivalentNumber_ShouldPutEquivalentNumberForEachCharAndSumAllOfThose_WhenGivesAListOfAlphabets(List<string> alphabets , List<int> expected)
        {
            // Initial
            
            // Action
            var result = _sut.ComputeEquivalentNumber(alphabets);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Mod5))]
        public void ComputeMod5_ShouldComputeModOfEachSet_WhenGivesANumberList(List<int> numbers, List<int> expected)
        {
            // Initial 
            
            // Action
            var result = _sut.ComputeMod5(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SumOfSquare))]
        public void SumOfSquare_ShouldComputeSquareOfEachNumberAndSumAllOfThose_WhenGivesAListOfNumber(List<int> numbers, int expected)
        {
            // Initial 
            
            // Action
            var result = _sut.SumOfSquare(numbers);

            // Assert
            Assert.Equal(expected, result);
        }
    }    
}
