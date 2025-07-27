using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class TrueOrFalse:Question
    {
        #region Some new Modifications
        public static List<int> TorFCorrectAnsIds = new List<int>();
        public static List<int> TorFChoosenAnsIds = new List<int>();
        public static List<int> TorFMarks = new List<int>();
        public static List<int> WrongAnsIds = new List<int>();
        // there is a comment called // new in every part i use these parts

        #endregion
        public static List<Question> TorFQuestions { get; set; } = new List<Question>();
        //public static List<Answer> TorFanswerList { get; set; } // No need they are only two answers for all questions
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
            TorFMarks.Add(mark); // new


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
            TorFCorrectAnsIds.Add(CorrAns); // new



            #endregion


        }
        // new
        public static int CheckAnswer(List<int> chosenAnswer, List<int> corrAns)
        {
            int examMarks = 0;
            for (int i = 0; i < chosenAnswer.Count; i++)
            {
                Exam.examFullMark += TorFMarks[i];
                if (chosenAnswer[i] == corrAns[i])
                {
                    examMarks += TorFMarks[i];
                }
                else
                {
                    WrongAnsIds.Add(i); // index of the question that you choosed a wrong ans in.
                }

            }
            return examMarks;
        }


    }
}
