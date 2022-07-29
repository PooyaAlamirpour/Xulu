using System;
using System.Collections.Generic;
using System.Linq;
using Xulu.LanguageDomain.Abstracts.DomainLogics;

namespace Xulu.LanguageDomain.Implementations.DomainLogics
{
    public class NameDomainLogic : INameDomainLogic
    {
        public List<string> BreakRepeatedAlphabets(string str)
        {
            List<string> repeatedList = new();
            string repeatedAlphabets = string.Empty;
            var letter = str[0];
            var index = 1;
            var strLength = str.Length;
            while (index < strLength)
            {
                if (letter == str[index])
                {
                    repeatedAlphabets += letter;
                }
                else
                {
                    repeatedList.Add(letter + repeatedAlphabets);
                    letter = str[index];
                    repeatedAlphabets = string.Empty;
                }
                index++;
            }

            var sumOfRepeatedLength = repeatedList.Sum(x => x.Length);
            var restOfString = str[sumOfRepeatedLength..];
            if(restOfString is not null) repeatedList.Add(restOfString);
            
            return repeatedList;
        }

        public List<int> ComputeEquivalentNumber(List<string> strList) => strList.Select(str => str.Sum(ch => ch - 96)).ToList();

        public List<int> ComputeMod5(List<int> numberList) => numberList.Select(num => num % 5).ToList();
        public int SumOfSquare(List<int> numbers) => numbers.Sum(num => (int) Math.Pow(num, 2));
    }
}