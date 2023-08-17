namespace Task4Project.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Questions { get; set; }
        public string Answer { get; set; }

    }

    public class UserAnswer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Answer { get; set; }

    }
}
