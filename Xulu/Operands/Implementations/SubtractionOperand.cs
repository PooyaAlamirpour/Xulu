using System.Collections.Generic;
using System.Linq;
using Xulu.LanguageDomain.Abstracts.DomainLogics;

namespace Xulu.Operands.Implementations
{
    public class SubtractionOperand : IOperand
    {
        public string Sign => "bcde";
        private readonly INameDomainLogic _nameDomainLogic;
        public SubtractionOperand(INameDomainLogic nameDomainLogic)
        {
            _nameDomainLogic = nameDomainLogic;
        }

        public int Calculate(List<string> names) =>
            (from name in names
                select _nameDomainLogic.BreakRepeatedAlphabets(name) into breakRepeatedAlphabets
                select _nameDomainLogic.ComputeEquivalentNumber(breakRepeatedAlphabets) into equivalentNumberList
                select _nameDomainLogic.ComputeMod5(equivalentNumberList) into mod5List
                select _nameDomainLogic.SumOfSquare(mod5List))
            .Aggregate(1, (current, sumOfSquare) => current - sumOfSquare);
    }
}