using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class TrueOrFalse:Question
    {
        public static List<Question> TorFQuestions { get; set; } = new List<Question>();

        //public static List<Answer> TorFanswerList { get; set; }
        public static string[] TorFchoices = new string[2] {"1 for true ","2 for false" };
        public static string TorFChoices = $"1- True \n2- False";

        public int rightAnswerId { get; set; }

        public  void CreateTrueOrFalseQuestion()
        {
            string header = "True Or False";

            #region Take Body as an input
            bool isValid = false;
            string body;
            do
            {
                Console.WriteLine("Enter Question body: ");
                body = Console.ReadLine();
                isValid = !string.IsNullOrWhiteSpace(body) &&
             body.Any(char.IsLetter);

                if (!isValid)
                    Console.WriteLine("Question body must contain letters and cannot be empty or numbers only.");

            }
            while (!isValid);

            Console.WriteLine();
            #endregion

            #region Take Mark as an input

            bool flag = false;
            int mark = 0;
            do
            {
                Console.WriteLine("Enter the mark (1:5) ");
                flag = int.TryParse(Console.ReadLine(), out mark);
            } while (!flag || mark > 5 || mark < 1);
            Exam.AllMarks.Add(mark);


            Console.WriteLine();
            #endregion
            TorFQuestions.Add(new Question(header,body,mark));
            #region Determine The CorrectAnsId

            int CorrAns;
            bool isParsed = false;

            do
            {
                Console.WriteLine("Enter the Correct AnswerId (1 For True | 2 For False) : ");
                isParsed = int.TryParse(Console.ReadLine(), out CorrAns);
            } while (!isParsed || CorrAns < 1 || CorrAns > 2);
            Exam.CorrectAnswerIds.Add(CorrAns);



            #endregion


        }

    }
}
