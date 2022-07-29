using System.Collections.Generic;

namespace Xulu.Operands
{
    public interface IOperand
    {
        string Sign { get; }
        int Calculate(List<string> names);
    }
}