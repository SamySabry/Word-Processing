using BusinessService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewModel;
using WebFront.Models;

namespace WebFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWordService _wordService;

        public HomeController(ILogger<HomeController> logger, IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessWords([FromBody] List<Word> words)
        {
            try
            {
                var result = _wordService.ProcessWords(words);
                return Json(result);
            }

            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
