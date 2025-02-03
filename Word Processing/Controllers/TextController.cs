
using BusinessService;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace Boxes_Problem.Controllers
{
    public class TextController : Controller
    {
        private readonly IWordService _wordService;

        public TextController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [HttpPost("process")]
        public IActionResult ProcessWords([FromBody] List<Word> words)
        {
            try
            {
                if (words == null || words.Count == 0)
                    return BadRequest("Invalid input");
                List<string> result = _wordService.ProcessWords(words);

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
