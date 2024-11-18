namespace GeniusIdiotConsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] questions = new string[5];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";

            int[] rightAnswers = new int[5];
            rightAnswers[0] = 6;
            rightAnswers[1] = 9;
            rightAnswers[2] = 25;
            rightAnswers[3] = 60;
            rightAnswers[4] = 2;
        }
    }
}
