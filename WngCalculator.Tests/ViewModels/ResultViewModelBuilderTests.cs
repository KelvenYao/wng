using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WngCalculator.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WngCalculator.Models;

namespace WngCalculator.ViewModels.Tests
{
    [TestClass()]
    public class ResultViewModelBuilderTests
    {
        int inputNumber;
        ResultViewModelBuilder resultViewModelBuilder;

        [TestInitialize]
        public void SetupTesting()
        {
            inputNumber = 9;
            resultViewModelBuilder
                   = new ViewModels.ResultViewModelBuilder();
        }

        [TestMethod()]
        public void BuildTest()
        {
            ResultViewModel resultViewModel = resultViewModelBuilder.Build(inputNumber);
            Assert.IsNotNull(resultViewModel);
            Assert.IsNotNull(resultViewModel.InputData);
            Assert.IsNotNull(resultViewModel.Result);
        }

        [TestMethod()]
        public void GetResultsTest()
        {
            Result result = resultViewModelBuilder.GetResults(inputNumber);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetFibonacciTest()
        {
            string fibonacci = resultViewModelBuilder.GetFibonacci(inputNumber);
            string expectedValueFibonacci = "1,2,3,5,8,";

            Assert.AreEqual(expectedValueFibonacci, fibonacci);
        }

        [TestMethod()]
        public void GetNumberTest()
        {
            Result result = new Result();
            resultViewModelBuilder.GetNumber(inputNumber, ref result);
            string expectedValueAllNumbers = "1,2,3,4,5,6,7,8,9,";
            string expectedValueOddNumbers = "1,3,5,7,9,";
            string expectedValueEvenNumbers = "2,4,6,8,";
            string expectedValueCezNumbers = "1,2,C,4,E,C,7,8,C,";
            
            Assert.AreEqual(expectedValueAllNumbers, result.AllNumbers);
            Assert.AreEqual(expectedValueOddNumbers, result.OddNumbers);
            Assert.AreEqual(expectedValueEvenNumbers, result.EvenNumbers);
            Assert.AreEqual(expectedValueCezNumbers, result.CezNumbers);
        }
    }
}
