namespace DingoBox.Data
{
    public class Card
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Tags { get; set; }

    }
}
