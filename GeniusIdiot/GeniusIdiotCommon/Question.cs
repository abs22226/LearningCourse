namespace GeniusIdiotCommon
{
    public class Question
    {
        public string Text { get; set;  }
        public int Answer { get; set; }

        public static bool operator ==(Question questionOne, Question questionTwo)
        {
            return questionOne.Text == questionTwo.Text && questionOne.Answer == questionTwo.Answer;
        }

        public static bool operator !=(Question questionOne, Question questionTwo)
        {
            return questionOne.Text != questionTwo.Text || questionOne.Answer != questionTwo.Answer;
        }
    }
}
