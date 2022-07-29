using System.Collections.Generic;
using Xulu.Operands.Models;

namespace Xulu.LanguageDomain.Abstracts.DomainLogics
{
    public interface IVerbDomainLogic
    {
        List<int> GetSentenceStartIndex(string sentence);
        MathematicalOperationEnum TranslateVerbToMathematicalOperation(string verb);
    }
}