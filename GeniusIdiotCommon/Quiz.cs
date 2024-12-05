namespace GeniusIdiotCommon
{
    public class Quiz
    {
        public User User { get; }
        public List<Question> Questions { get; }
        public int Length { get; }
        public int CorrectAnswersCount { get; set; }
        public Question CurrentQuestion { get; private set; }
        public int CurrentQuestionNumber { get; private set; }
        public bool IsEnded { get { return Questions.Count == 0; } }

        public Quiz(User user)
        {
            User = user;
            Questions = QuestionsStorage.GetAll();
            Length = Questions.Count;
        }

        public void RandomizeCurrentQuestion()
        {
            var random = new Random();
            var index = random.Next(0, Questions.Count);
            CurrentQuestion = Questions[index];
            CurrentQuestionNumber++;
        }

        public void AcceptUserAnswer(int? userAnswer)
        {
            if (userAnswer == CurrentQuestion.Answer)
            {
                CorrectAnswersCount++;
            }

            Questions.Remove(CurrentQuestion);
        }

        public void SetUserScore()
        {
            User.SetScore(CorrectAnswersCount, Length);
        }

        public void SetUserDiagnosis()
        {
            User.SetDiagnosis(CorrectAnswersCount, Length);
        }
    }
}
