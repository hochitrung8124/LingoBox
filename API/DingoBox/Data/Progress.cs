namespace DingoBox.Data
{
    public class Progress
    {
        public int Id { get; set; }
        public int TotalWordsLearned { get; set; }
        public float AverageScore { get; set; }
        public DateTime LastActive { get; set; }

    }
}
