namespace DingoBox.Data
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }


    }
}
