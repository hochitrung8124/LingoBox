namespace DingoBox.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int ProgressId { get; set; }
        public Progress Progress { get; set; }

        public ICollection<Word> FavoriteWords { get; set; }

    }
}
