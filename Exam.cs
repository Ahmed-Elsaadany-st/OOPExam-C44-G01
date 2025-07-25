using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal  class Exam
    {
       public static int ExamTime {  get; set; }
        public static int NumberOfQuestions { get; set; }
        public static List<int> CorrectAnswerIds { get; set; } = new List<int>();
        // Storing the Correct answers in an array so i can compare them with the choesn answers array and give the mark


        public static List<int> ChosenAnswers { get; set; }=new List<int>();
        //Stores the chosen answers so i can compare them with the correct answers and give mark.
        public static List<int> AllMarks { get; set; } = new List<int>();

        // storing the marks so i can give full mark when i compare correct ans with choesn ans and find it true.


        public static int ExamFullMark = 0;
        public static int ExamMarks = 0;





        public static void CreatExam()
        {
            #region Determine Time And Number Of Questions
            bool flag = false;
            int examTime;
            do
            {
                Console.Write("Please Enter the time for exam (Chosse a time betweem 30:180 ) : ");
                flag = int.TryParse(Console.ReadLine(), out examTime);

            } while (!flag || examTime < 30 || examTime > 180);
            ExamTime = examTime;
            Console.WriteLine();
            int numberOfQuestions;
            do
            {
                Console.Write("Enter the number of questions (1:20) : ");
                flag = int.TryParse(Console.ReadLine(), out numberOfQuestions);
            } while (!flag || numberOfQuestions < 1 || numberOfQuestions > 20);
            NumberOfQuestions = numberOfQuestions;
            Console.WriteLine();
        }
            #endregion        

        public static void showExam()
        {

            showMCQ();
        }
        public static void showMCQ()
        {
            Console.WriteLine("MCQ Questions");
            Console.WriteLine();
            for (int i = 0; i < MCQ.mcqQuestions.Count; i++)
            {

                Console.WriteLine($" {i + 1}]: {MCQ.mcqQuestions[i]}");
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($"{MCQ.mcqAnswerList[j]}");
                }
                //Recive the chosen ans
                bool isParsed = false;
                int chosenAns;
                do
                {
                    Console.Write($"Your Answer: ");
                    isParsed = int.TryParse(Console.ReadLine(), out chosenAns);
                } while (!isParsed || chosenAns < 1 || chosenAns > 4);
                ChosenAnswers.Add(chosenAns);
                Console.WriteLine();
            }
        }
        public static int CheckAnswer(List<int> chosenAnswer)
        {
            int examMarks = 0;
            for (int i = 0; i < chosenAnswer.Count;i++)
            {
                ExamFullMark += AllMarks[i];
                if (chosenAnswer[i] == CorrectAnswerIds[i])
                {
                    examMarks += AllMarks[i];
                }

            }
            return examMarks;
        }
        public static string ShowMark()
        {
            return $" Your Mark Is {CheckAnswer(ChosenAnswers)} Out Of {ExamFullMark}";
        }




    }
}
