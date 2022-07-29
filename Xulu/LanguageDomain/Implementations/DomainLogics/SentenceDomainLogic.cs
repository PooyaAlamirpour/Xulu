using System.Collections.Generic;
using System.Linq;
using Xulu.LanguageDomain.Abstracts.DomainLogics;

namespace Xulu.LanguageDomain.Implementations.DomainLogics
{
    public class SentenceDomainLogic : ISentenceDomainLogic
    {
        private readonly IVerbDomainLogic _verbDomainLogic;
        
        public SentenceDomainLogic(IVerbDomainLogic verbDomainLogic)
        {
            _verbDomainLogic = verbDomainLogic;
        }
        
        public List<string> SeparateSentences(string sentences)
        {
            List<string> separateSentences = new();
            var sentenceStartIndexList = _verbDomainLogic.GetSentenceStartIndex(sentences);
            var splitSentence = sentences.Split(' ');
            
            for (int i = 0; i < sentenceStartIndexList.Count - 1; i++)
            {
                int startIndex = sentenceStartIndexList[i];
                int endIndex = sentenceStartIndexList[i + 1];

                var newSentenceList = splitSentence.Where((x, index) => index >= startIndex && index < endIndex).ToList();
                string newSentence = string.Join(' ', newSentenceList);
                separateSentences.Add(newSentence);
            }

            if (separateSentences.Count < sentenceStartIndexList.Count)
            {
                int lastSentenceIndex = sentenceStartIndexList.Last();
                var lastSentenceList = splitSentence.Where((x, index) => index >= lastSentenceIndex).ToList();
                string newSentence = string.Join(' ', lastSentenceList);
                separateSentences.Add(newSentence);
            }

            return separateSentences;
        }
    }
}