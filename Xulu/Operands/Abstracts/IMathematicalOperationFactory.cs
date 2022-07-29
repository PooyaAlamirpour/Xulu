using Xulu.Operands.Models;

namespace Xulu.Operands.Abstracts
{
    public interface IMathematicalOperationFactory
    {
        IOperand Create(MathematicalOperationEnum operand);
    }
}