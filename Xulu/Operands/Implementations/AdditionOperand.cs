using System.Collections.Generic;
using System.Linq;
using Xulu.LanguageDomain.Abstracts.DomainLogics;

namespace Xulu.Operands.Implementations
{
    public class AdditionOperand : IOperand
    {
        public string Sign => "abcd";
        private readonly INameDomainLogic _nameDomainLogic;
        public AdditionOperand(INameDomainLogic nameDomainLogic)
        {
            _nameDomainLogic = nameDomainLogic;
        }

        public int Calculate(List<string> names) =>
            (from name in names
                select _nameDomainLogic.BreakRepeatedAlphabets(name) into brokenRepeatedAlphabets
                select _nameDomainLogic.ComputeEquivalentNumber(brokenRepeatedAlphabets) into equivalentNumberList
                select _nameDomainLogic.ComputeMod5(equivalentNumberList) into mod5List
                select _nameDomainLogic.SumOfSquare(mod5List))
            .Sum();
    }
}