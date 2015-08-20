using System;
using WngCalculator.Models;
namespace WngCalculator.ViewModels
{
    interface IResultViewModelBuilder
    {
        ResultViewModel Build(int integer);
        string GetFibonacci(int integer);
        void GetNumber(int integer, ref Result result);
        Result GetResults(int integer);
    }
}
