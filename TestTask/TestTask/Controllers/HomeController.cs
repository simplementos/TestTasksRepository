using BLL;
using BLL.ExpressionValidationTask;
using BLL.SubArrayTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {          
            return View();
        }

        public ActionResult SubArrayTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubArrayTask(string inputArray)
        {
            int[] array;
            try
            {
                array = inputArray.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            }
            catch (Exception)
            {
                array = null;
                ModelState.AddModelError("inputArray", "Incorrect input. Input array with \',\' as a delimiter");
                return View();
            }

            int[] array2 = { 10, -5, 1, 10, -20, 9, 1 };
            int[] array3 = { -4, 15, -6, 18, 2, -20 };


            var data = SubArrayWithMaxSum.GetSubArrayWithMaxSum(array);

            ViewBag.Array = array;
            ViewBag.SubArray = data.Item1;
            ViewBag.Sum = data.Item2;

            return View();
        }

        public ActionResult ExpressionValidatorTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExpressionValidatorTask(string input)
        {
            ExpressionValidator validator = new ExpressionValidator(input);

            var failedRules = validator.GetFailedRules();
            if (failedRules.Count == 0)
            {
               ViewBag.Result = "Yes";
            }
            else
            {
                ViewBag.Result = "No";
                foreach (var item in failedRules)
                {
                   ModelState.AddModelError("input", item.Value.ErrorMessage);
                }
            }
            TempData["Input"] = input;

            return View();
        }
    }
}