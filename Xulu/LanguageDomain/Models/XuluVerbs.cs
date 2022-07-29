using System;
using System.Collections.Generic;
using Xulu.Operands;
using Xulu.Operands.Implementations;
using Xulu.Operands.Models;

namespace Xulu.LanguageDomain.Models
{
    public class XuluVerbs
    {
        private readonly IServiceProvider _serviceProvider;
        public XuluVerbs(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public Dictionary<string, MathematicalOperationEnum> List => new()
        {
            {((IOperand)_serviceProvider.GetService(typeof(AdditionOperand))).Sign, MathematicalOperationEnum.Addition},
            {((IOperand)_serviceProvider.GetService(typeof(SubtractionOperand))).Sign, MathematicalOperationEnum.Subtraction},
            {((IOperand)_serviceProvider.GetService(typeof(MultiplicationOperand))).Sign, MathematicalOperationEnum.Multiplication}
        };
    }
}