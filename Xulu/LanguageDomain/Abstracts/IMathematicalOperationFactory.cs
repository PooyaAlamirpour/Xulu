using Xulu.Operands;
using Xulu.Operands.Models;

namespace Xulu.LanguageDomain.Abstracts
{
    public interface IMathematicalOperationFactory
    {
        IOperand Create(MathematicalOperationEnum operand);
    }
}