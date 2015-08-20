using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WngCalculator.Models
{
    public class InputData
    {
        [Required]
        [Range(1, Int32.MaxValue), RegularExpression("([0-9]+)", ErrorMessage = "The value must be a positive integer.")]
        [Display(Name="Number")]

        public int Number { get; set; }
    }
}