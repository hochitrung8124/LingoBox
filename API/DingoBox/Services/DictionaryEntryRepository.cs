using DingoBox.Data;
using DingoBox.Models;
using DingoBox.Services;
using System.Text.Json;

namespace API.Services
{
    public class DictionaryEntryRepository : IDictionaryEntry
    {
        public async Task<IEnumerable<DictionaryEntry>> GetWordAsync(string word)
        {
            string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}";
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<DictionaryEntry>();

            var json = await response.Content.ReadAsStringAsync();
            var entries = JsonSerializer.Deserialize<List<DictionaryEntry>>(json);

            var result = entries?.Select(e => new DictionaryEntry
            {
                word = e.word,
                phonetic = e.phonetic,
                phonetics = e.phonetics?
                    .Where(a =>
                        !string.IsNullOrEmpty(a.audio) &&
                        a.audio.Length >= 7 &&
                        a.audio.Substring(a.audio.Length - 6, 2)
                            .Equals("us", StringComparison.OrdinalIgnoreCase) ||
                        a.audio.EndsWith("uk", StringComparison.OrdinalIgnoreCase)
)
                    .ToList()
            });


            return result ?? Enumerable.Empty<DictionaryEntry>();
        } 


    }
}
