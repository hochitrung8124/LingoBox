using DingoBox.Models;

namespace DingoBox.Services
{
    public interface IDictionaryEntry
    {
        public Task<IEnumerable<DictionaryEntry>> GetWordAsync(string word);
    }
}
