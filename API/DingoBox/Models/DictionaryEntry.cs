namespace DingoBox.Models
{
    public class DictionaryEntry
    {
        public string word { get; set; }
        public string phonetic { get; set; }
        public List<Phonetic> phonetics { get; set; }
    }
}
