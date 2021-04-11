using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DoubletConceptProject.Controllers
{
    public class Fashion : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
