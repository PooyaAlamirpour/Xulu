using System.Collections.Generic;

namespace Xulu.LanguageDomain.Abstracts.DomainLogics
{
    public interface ISentenceDomainLogic
    {
        List<string> SeparateSentences(string sentences);
    }
}