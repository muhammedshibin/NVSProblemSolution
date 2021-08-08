using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.Controllers
{
    public class FallbackController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public FallbackController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            var path = Path.Combine(_env.WebRootPath, "Index.html");
            return PhysicalFile(path, "text/html");
        }
    }
}
