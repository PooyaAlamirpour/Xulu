// See https://aka.ms/new-console-template for more information

using System;
using Microsoft.Extensions.DependencyInjection;
using Xulu.LanguageDomain.Abstracts;
using Xulu.LanguageDomain.Abstracts.Validators;

namespace Xulu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = CreateServiceProvider();

            // Register dependencies
            var grammarValidator = serviceProvider?.GetService<IGrammarValidator>();
            var computeEquivalent = serviceProvider?.GetService<IComputeEquivalent>();

            // Getting sentence from user
            Console.Write("> Write Xulu sentence: ");
            var inputSentence = Console.ReadLine() ?? string.Empty;
            
            // Computing equivalent number of sentence 
            if (grammarValidator != null && grammarValidator.IsValid(inputSentence))
            {
                var equivalentNumber = computeEquivalent?.ComputeSentenceEquivalentNumber(inputSentence);
                Console.WriteLine($"Equivalent number of sentence: {equivalentNumber}");
            }
            else
            {
                Console.WriteLine("Check the grammar and try again.");
            }
        }

        private static ServiceProvider? CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new();
            startup.ConfigureService(services);
            return services.BuildServiceProvider();
        }
    }
}