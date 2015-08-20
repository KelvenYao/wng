using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WngCalculator.Models;
using WngCalculator.ViewModels;

namespace WngCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(InputData inputData)
        {
            ResultViewModelBuilder resultViewModelBuilder = new ResultViewModelBuilder();
            ResultViewModel resultViewModel = resultViewModelBuilder.Build(inputData.Number);

            return View(resultViewModel);
        }
    }
}