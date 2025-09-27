using DingoBox.Models;
using DingoBox.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;

namespace DingoBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryEntryController : ControllerBase
    {
        private IDictionaryEntry _dictionaryEntry;

        public DictionaryEntryController(IDictionaryEntry dictionaryEntry) {
            _dictionaryEntry = dictionaryEntry;
        }
        [HttpGet]
        public async Task<IActionResult> GetWordAsync(string word)
        {
            try
            {
                var result = await _dictionaryEntry.GetWordAsync(word); 
                return Ok(result);
            }
            catch
            {
                return BadRequest("Lỗi khi gọi API.");
            }
        }

    }
}
