using static System.Formats.Asn1.AsnWriter;

namespace GeniusIdiotCommon
{
    public class Quiz
    {
        private readonly User user;
        private readonly List<Question> questions;
        public int Length { get; }
        private int correctAnswersCount;
        public Question CurrentQuestion { get; private set; }
        public int CurrentQuestionNumber { get; private set; }
        public bool IsEnded { get { return questions.Count == 0; } }

        public Quiz(User user)
        {
            this.user = user;
            questions = QuestionsStorage.GetAll();
            Length = questions.Count;
        }

        public void RandomizeCurrentQuestion()
        {
            var random = new Random();
            var index = random.Next(0, questions.Count);
            CurrentQuestion = questions[index];
            CurrentQuestionNumber++;
        }

        public void AcceptUserAnswer(int? userAnswer)
        {
            if (userAnswer == CurrentQuestion.Answer)
            {
                correctAnswersCount++;
            }
            questions.Remove(CurrentQuestion);
        }

        public void SetUserScore()
        {
            user.Score = $"{correctAnswersCount}/{Length}";
        }

        public void ResetUserResult()
        {
            user.Score = string.Empty;
            user.Diagnosis = string.Empty;
        }

        public void SetUserDiagnosis()
        {
            var correctAnswersPercentage = (double)correctAnswersCount / Length * 100;
            switch (correctAnswersPercentage)
            {
                case < 20: user.Diagnosis = "идиот"; break;
                case < 40: user.Diagnosis = "кретин"; break;
                case < 60: user.Diagnosis = "дурак"; break;
                case < 80: user.Diagnosis = "нормальный"; break;
                case < 100: user.Diagnosis = "талант"; break;
                default: user.Diagnosis = "гений"; break;
            }
        }
    }
}
