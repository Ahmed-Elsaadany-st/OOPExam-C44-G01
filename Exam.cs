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
        public static List<int>WrongAnsIds { get; set; } =new List<int>();

        //public static int ExamFullMark = 0;
        public static int examFullMark = 0;

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
            #endregion 
        }

        public static void showExam()
        {

            showMCQ();
            showTorF();
        }
        public static void showMCQ()
        {
            Console.WriteLine("MCQ Questions");
            Console.WriteLine();
            for (int i = 0; i < MCQ.mcqQuestions.Count; i++)
            {

                Console.WriteLine($" {i + 1}]: {MCQ.mcqQuestions[i]}");
                for (int j = i; j < i+1; j++)
                {
                    Console.WriteLine($"{MCQ.mcqAnswerList[j]}");
                }
                //Recive the chosen ans
                bool isParsed = false;
                int chosenAns;
                do
                {
                    Console.Write($"Your Answer(1:4): ");
                    isParsed = int.TryParse(Console.ReadLine(), out chosenAns);
                } while (!isParsed || chosenAns < 1 || chosenAns > 4);
                ChosenAnswers.Add(chosenAns);
                MCQ.mcqChoosenAnsIds.Add(chosenAns); // new
                Console.WriteLine();
            }
           
        }
        public static void showTorF()
        {
            //Console.WriteLine("True Or False Questions");

            for (int i = 0; i < TrueOrFalse.TorFQuestions.Count; i++)
            {
                Console.WriteLine($" {i + 1}]: {TrueOrFalse.TorFQuestions[i]}");
                Console.WriteLine($"{TrueOrFalse.TorFChoices}");
                //recive the choice
                bool isParsed = false;
                int chosenAns;
                do
                {
                    Console.Write($"Your Answer(1 or 2): ");
                    isParsed = int.TryParse(Console.ReadLine(), out chosenAns);
                } while (!isParsed || chosenAns < 1 || chosenAns > 4);
                ChosenAnswers.Add(chosenAns);
                TrueOrFalse.TorFChoosenAnsIds.Add((chosenAns)); // new
                Console.WriteLine();


            }
        }
        #region Parts that  have Logical errors in some cases so i replaced it.
        //public static int CheckAnswer(List<int> chosenAnswer)
        //{
        //    int examMarks = 0;
        //    for (int i = 0; i < chosenAnswer.Count;i++)
        //    {
        //        ExamFullMark += AllMarks[i];
        //        if (chosenAnswer[i] == CorrectAnswerIds[i])
        //        {
        //            examMarks += AllMarks[i];
        //        }
        //        else
        //        {
        //            WrongAnsIds.Add(i); // index of the question that you choosed a wrong ans in.
        //        }

        //    }
        //    return examMarks;
        //}
        //public static string ShowMark()
        //{
        //    return $" Your Mark Is {CheckAnswer(ChosenAnswers)} Out Of {ExamFullMark}";
        //} 

        #endregion

        //new
        public static string showMark()
        {
            return $" Your Mark Is {MCQ.CheckAnswer(MCQ.mcqChoosenAnsIds,MCQ.mcqCorrectAnsIds)+TrueOrFalse.CheckAnswer(TrueOrFalse.TorFChoosenAnsIds,TrueOrFalse.TorFCorrectAnsIds)} Out Of {examFullMark}";

        }
        // new
        public static void mcqWrongQuestions()
        {
            Console.WriteLine("Worng MCQ Questions");
            for (int i = 0; i < MCQ.WrongAnsIds.Count; i++)
            {
                Console.WriteLine($" {i + 1}]: {MCQ.mcqQuestions[MCQ.WrongAnsIds[i]]}");
                for (int j = i; j < i + 1; j++)
                {
                    Console.WriteLine($"{MCQ.mcqAnswerList[MCQ.WrongAnsIds[i]]}");
                }
                Console.WriteLine($"Your Ans was ==> {MCQ.mcqChoosenAnsIds[MCQ.WrongAnsIds[i]]}");
                Console.WriteLine($"The Correct Ans is==> {MCQ.mcqCorrectAnsIds[MCQ.WrongAnsIds[i]]}");
            }

        }
        //new
        public static void TorFWrongQuestions()
        {
            Console.WriteLine("True Or False Wrong False");
            for (int i = 0; i < TrueOrFalse.WrongAnsIds.Count; i++)
            {
                Console.WriteLine($" {i + 1}]: {TrueOrFalse.TorFQuestions[TrueOrFalse.WrongAnsIds[i]]}");
                Console.WriteLine($"{TrueOrFalse.TorFChoices}");
                Console.WriteLine($"Your Ans Was==>{TrueOrFalse.TorFChoosenAnsIds[TrueOrFalse.WrongAnsIds[i]]}");
                Console.WriteLine($"The Correct Ans Was==>{TrueOrFalse.TorFCorrectAnsIds[TrueOrFalse.WrongAnsIds[i]]}");


            }

        }




    }
}
