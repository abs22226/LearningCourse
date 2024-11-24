namespace GeniusIdiotConsApp
{
    public class User
    {
        public string Name { get; }
        public string Score { get; private set; }
        public string Diagnosis { get; set; }

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
    }
}
