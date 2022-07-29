using System;
using Xulu.LanguageDomain.Abstracts;
using Xulu.Operands.Abstracts;
using Xulu.Operands.Implementations;
using Xulu.Operands.Models;

namespace Xulu.Operands
{
    public class MathematicalOperationFactory : IMathematicalOperationFactory
    {
        private readonly IServiceProvider _serviceProvider;
        
        public MathematicalOperationFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public IOperand Create(MathematicalOperationEnum operand) => operand switch
        {
            MathematicalOperationEnum.Addition => (IOperand)_serviceProvider.GetService(typeof(AdditionOperand))!,
            MathematicalOperationEnum.Subtraction => (IOperand)_serviceProvider.GetService(typeof(SubtractionOperand))!,
            MathematicalOperationEnum.Multiplication => (IOperand)_serviceProvider.GetService(typeof(MultiplicationOperand))!,
            _ => throw new ArgumentOutOfRangeException(nameof(operand), operand, null)
        }?? throw new InvalidOperationException($"It is not possible to make an instance right now({nameof(MathematicalOperationFactory)})");
    }
}