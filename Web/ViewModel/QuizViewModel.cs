namespace Web.ViewModel
{
    public class QuizViewModel
    {
        public  int? QuizId { get; set; }
        public string QuizTitle { get; set; }
        public List<QuestionViewModel>? Questions { get; set; }
    }
}
