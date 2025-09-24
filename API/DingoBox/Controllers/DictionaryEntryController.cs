using DingoBox.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;

namespace DingoBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryEntryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWordAsync(string word)
        {
            try
            {
                string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}";
                using HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return NotFound("Từ không tồn tại hoặc API lỗi.");

                var json = await response.Content.ReadAsStringAsync();
                var entries = JsonSerializer.Deserialize<List<DictionaryEntry>>(json);

                // Chỉ lấy các trường cần thiết
                var result = entries.Select(e => new
                {
                    Word = e.word,
                    Phonetic = e.phonetic,
                    Phonetics = e.phonetics?
                    .FirstOrDefault(a =>
                        !string.IsNullOrEmpty(a.audio) &&
                        a.audio.Length >= 7 &&
                        a.audio.Substring(a.audio.Length - 6, 2)
                            .Equals("us", StringComparison.OrdinalIgnoreCase)
                    ),
                });

                return Ok(result);
            }
            catch
            {
                return BadRequest("Lỗi khi gọi API.");
            }
        }

    }
}
