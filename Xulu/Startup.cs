using System;
using Microsoft.Extensions.DependencyInjection;
using Xulu.LanguageDomain.Abstracts;
using Xulu.LanguageDomain.Abstracts.DomainLogics;
using Xulu.LanguageDomain.Abstracts.Validators;
using Xulu.LanguageDomain.Implementations;
using Xulu.LanguageDomain.Implementations.DomainLogics;
using Xulu.LanguageDomain.Implementations.Validators;
using Xulu.LanguageDomain.Models;
using Xulu.Operands;
using Xulu.Operands.Abstracts;
using Xulu.Operands.Implementations;

namespace Xulu
{
    public class Startup
    {
        public void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<INameDomainLogic, NameDomainLogic>();
            services.AddTransient<IVerbDomainLogic, VerbDomainLogic>();
            services.AddTransient<ISentenceDomainLogic, SentenceDomainLogic>();
            
            services.AddTransient<INameValidator, NameValidator>();
            services.AddTransient<IVerbValidator, VerbValidator>();
            services.AddTransient<IGrammarValidator, GrammarValidator>();
            
            services.AddTransient<IComputeEquivalent, ComputeEquivalent>();
            services.AddTransient<IMathematicalOperationFactory, MathematicalOperationFactory>();
            services.AddTransient<XuluVerbs>();
            
            services.AddScoped<AdditionOperand>()
                .AddScoped<IOperand, AdditionOperand>(x => 
                    x.GetService<AdditionOperand>() ?? 
                    throw new InvalidOperationException($"There is an issue in making an instance for {nameof(AdditionOperand)}"));
            
            services.AddScoped<SubtractionOperand>()
                .AddScoped<IOperand, SubtractionOperand>(x => 
                    x.GetService<SubtractionOperand>() ?? 
                    throw new InvalidOperationException($"There is an issue in making an instance for {nameof(SubtractionOperand)}"));
            
            services.AddScoped<MultiplicationOperand>()
                .AddScoped<IOperand, MultiplicationOperand>(x => 
                    x.GetService<MultiplicationOperand>() ?? 
                    throw new InvalidOperationException($"There is an issue in making an instance for {nameof(MultiplicationOperand)}"));
        }
    }
}