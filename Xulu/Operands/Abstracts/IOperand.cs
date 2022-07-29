using System.Collections.Generic;

namespace Xulu.Operands.Abstracts
{
    public interface IOperand
    {
        string Sign { get; }
        int Calculate(List<string> names);
    }
}