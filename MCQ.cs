using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class MCQ:Question
    {
        #region Some new Modifications
        public static List<int> mcqCorrectAnsIds = new List<int>();
        public static List<int> mcqChoosenAnsIds = new List<int>();
        public static List<int> mcqMarks = new List<int>();
        public  static List<int>WrongAnsIds = new List<int>();
        // there is a comment called // new in every part i use these parts

        #endregion
        public static List<Question> mcqQuestions { get; set; } = new List<Question>();
        public static List<Answer> mcqAnswerList { get; set; } = new List<Answer>();
        public static string[] mcqChoices { get; set; } = new string[4];



        public void CreateMcqQuesion() 
        { 
            string header = "MCQ Quesion";
            
          
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
            mcqMarks.Add(mark); // new
            
            Console.WriteLine();
            #endregion
           mcqQuestions.Add(new(header,body,mark)); // works properly do not touch 
            #region Take Question Choices 
            Console.WriteLine("Enter the Choices:");
            string choice;
            for (int i = 0; i <4; i++)
            {
                do
                {
                    Console.Write($"Enter Choice number {i + 1}: ");
                    choice = Console.ReadLine();

                    isValid = !string.IsNullOrWhiteSpace(choice) &&
                              choice.Any(char.IsLetter);

                    if (!isValid)
                        Console.WriteLine("Choice must contain at least one letter and cannot be empty or only numbers.");

                } while (!isValid);

                mcqChoices[i] = choice;
                
            }
            mcqAnswerList.Add(new Answer(mcqChoices)); // problem (The latest object override the old one (cause the array is ref type which affects the old data when you recive new data on it)?)
            mcqChoices = new string[4]; // this line solved the previous by making a new ref

            #endregion
            // works properly , do not touch it
            #region Determine The CorrectAnsId

            int CorrAns;
                bool isParsed = false;
                
                do
                {
                    Console.WriteLine("Enter the Correct AnswerId (1:4) : ");
                    isParsed = int.TryParse(Console.ReadLine(), out CorrAns);
                } while (!isParsed || CorrAns < 1 || CorrAns > 4);
                Exam.CorrectAnswerIds.Add(CorrAns);
                mcqCorrectAnsIds.Add(CorrAns); //new

            
            #endregion

        }
        // new
        public static int CheckAnswer(List<int> chosenAnswer,List<int>corrAns)
        {
            int examMarks = 0;
            for (int i = 0; i < chosenAnswer.Count; i++)
            {
                Exam.examFullMark += mcqMarks[i];
                if (chosenAnswer[i] == corrAns[i])
                {
                    examMarks += mcqMarks[i];
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
