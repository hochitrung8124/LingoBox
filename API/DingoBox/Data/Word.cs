namespace DingoBox.Data
{
    public class Word
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public string ImagePath { get; set; }
        public string AudioPath { get; set; }
        public string ExampleSentence { get; set; }
        public DateTime LastReviewed { get; set; }
        public int ErrorCount { get; set; }

        // Quan hệ 1-n với Card
        public ICollection<Card> Cards { get; set; }


    }
}
