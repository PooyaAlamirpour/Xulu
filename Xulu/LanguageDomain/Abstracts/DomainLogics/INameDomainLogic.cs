using System.Collections.Generic;

namespace Xulu.LanguageDomain.Abstracts.DomainLogics
{
    public interface INameDomainLogic
    {
        List<string> BreakRepeatedAlphabets(string str);
        List<int> ComputeEquivalentNumber(List<string> strList);
        List<int> ComputeMod5(List<int> numberList);
        int SumOfSquare(List<int> numbers);
    }
}