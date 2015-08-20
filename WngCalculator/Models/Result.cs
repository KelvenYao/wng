using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WngCalculator.Models
{
    public class Result
    {
        [Display(Name = "All numbers")]
        public string AllNumbers { get; set; }
        [Display(Name = "Odd numbers")]
        public string OddNumbers { get; set; }
        [Display(Name = "Even numbers")]
        public string EvenNumbers { get; set; }
        [Display(Name = "CEZ Numbers")]
        public string CezNumbers { get; set; }
        [Display(Name = "Fibonacci")]
        public string Fibonacci { get; set; }
    }
}