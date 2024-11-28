namespace GeniusIdiotConsApp
{
    public class User
    {
        public string Name { get; }
        public string Score { get; private set; }
        public string Diagnosis { get; private set; }
        public bool IsReady { get; set; }

        public User(string name)
        {
            Name = name;
            Score = string.Empty;
            Diagnosis = string.Empty;
        }

        public User(string name, string score, string diagnosis)
        {
            Name = name;
            Score = score;
            Diagnosis = diagnosis;
        }

        public void SetScore(int rightAnswersCount, int startingQuestionsCount)
        {
            Score = $"{rightAnswersCount}/{startingQuestionsCount}";
        }

        public void ResetResult()
        {
            Score = string.Empty;
            Diagnosis = string.Empty;
        }

        public void SetDiagnosis(int rightAnswersCount, int startingQuestionsCount)
        {
            var rightAnswersPercentage = (double)rightAnswersCount / startingQuestionsCount * 100;
            switch (rightAnswersPercentage)
            {
                case < 20: Diagnosis = "идиот"; break;
                case < 40: Diagnosis = "кретин"; break;
                case < 60: Diagnosis = "дурак"; break;
                case < 80: Diagnosis = "нормальный"; break;
                case < 100: Diagnosis = "талант"; break;
                default: Diagnosis = "гений"; break;
            }
        }
    }
}
