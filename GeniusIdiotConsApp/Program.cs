namespace GeniusIdiotConsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int questionsCount = 5;
            string[] questions = GetQuestions(questionsCount);
            int[] rightAnswers = GetRightAnswers(questionsCount);

            int correctUserAnswersCount = 0;

            Random random = new Random();

            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));

                int randomQuestionIndex = random.Next(0, questionsCount);
                Console.WriteLine(questions[randomQuestionIndex]);

                int userAnswer = Convert.ToInt32(Console.ReadLine());

                int rightAnswer = rightAnswers[randomQuestionIndex];

                if (userAnswer == rightAnswer)
                {
                    correctUserAnswersCount++;
                }
            }

            Console.WriteLine("Количество правильных ответов: " + correctUserAnswersCount);

            string[] diagnoses = new string[6];
            diagnoses[0] = "идиот";
            diagnoses[1] = "кретин";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";

            Console.WriteLine("Ваш диагноз:" + diagnoses[correctUserAnswersCount]);
        }

        static string[] GetQuestions(int questionsCount)
        {
            string[] questions = new string[questionsCount];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }

        static int[] GetRightAnswers(int questionsCount)
        {
            int[] rightAnswers = new int[questionsCount];
            rightAnswers[0] = 6;
            rightAnswers[1] = 9;
            rightAnswers[2] = 25;
            rightAnswers[3] = 60;
            rightAnswers[4] = 2;
            return rightAnswers;
        }
    }
}
