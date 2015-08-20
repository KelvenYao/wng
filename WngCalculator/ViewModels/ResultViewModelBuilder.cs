using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WngCalculator.Models;

namespace WngCalculator.ViewModels
{
    public class ResultViewModelBuilder : IResultViewModelBuilder
    {
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

        public Result GetResults(int integer)
        {
            Result result = new Result();
            GetNumber(integer, ref result);
            result.Fibonacci = GetFibonacci(integer);
            return result;
        }

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