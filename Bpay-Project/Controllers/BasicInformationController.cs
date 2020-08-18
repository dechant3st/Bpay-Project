using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bpay_Project.Controllers
{
    public class BasicInformationController : Controller
    {
        public IActionResult BasicInformation()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}