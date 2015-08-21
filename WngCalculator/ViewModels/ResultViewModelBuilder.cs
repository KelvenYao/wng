using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WngCalculator.Models;

namespace WngCalculator.ViewModels
{
    public class ResultViewModelBuilder : IResultViewModelBuilder
    {
        /// <summary>
        /// This function builds the result viewModel according to the input integer
        /// </summary>
        /// <param name="integer">Input integer</param>
        /// <returns>ResultViewModel</returns>
        public ResultViewModel Build(int integer)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            InputData inputData = new InputData()
            {
                Number = integer
            };
            Result result = GetResults(integer);
            return new ResultViewModel()
            {
                InputData = inputData,
                Result = result
            };
        }
        /// <summary>
        /// This function returns the result strings
        /// </summary>
        /// <param name="integer">Input integer</param>
        /// <returns>Result</returns>
        public Result GetResults(int integer)
        {
            Result result = new Result();
            GetNumber(integer, ref result);
            result.Fibonacci = GetFibonacci(integer);
            return result;
        }
        /// <summary>
        /// This function returns Fibonacci string
        /// </summary>
        /// <param name="integer">Input integer</param>
        /// <returns>string type of Fibonacci</returns>
        public string GetFibonacci(int integer)
        {
            if (integer == 0)
            {
                return "";
            }
            string fibonacci = "";
            int p = 1;
            int q = 1;
            int temp = 0;
            do
            {
                fibonacci += q + ",";
                temp = q;
                q = p + q;
                p = temp;
            }
            while (q <= integer);
            return fibonacci;
        }

        /// <summary>
        /// This function builds 4 strings in one loop using ref param
        /// </summary>
        /// <param name="integer">Input integer</param>
        /// <param name="result">Result</param>
        public void GetNumber(int integer, ref Result result)
        {
            for (int i = 1; i <= integer; ++i)
            {
                result.AllNumbers += i + ",";
                if (i % 2 == 0)
                {
                    result.EvenNumbers += i + ",";
                }
                else
                {
                    result.OddNumbers += i + ",";
                }

                if (i % 3 == 0 && i % 5 == 0)
                {
                    result.CezNumbers += "Z" + ",";
                }
                else if (i % 3 == 0)
                {
                    result.CezNumbers += "C" + ",";
                }
                else if (i % 5 == 0)
                {
                    result.CezNumbers += "E" + ",";
                }
                else
                {
                    result.CezNumbers += i + ",";
                }
            }
        }
    }
}