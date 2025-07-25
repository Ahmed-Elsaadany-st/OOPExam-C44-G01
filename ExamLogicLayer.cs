using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class ExamLogicLayer
    {
        PracticalExam practicalExam =new PracticalExam();
        FinalExam finalExam =new FinalExam();
        public  void StartCreating()
        {
            #region Determine the type of exam final or practical
            bool flag = false;
            int input;
            do
            {
                Console.Write("Please Enter the type of Exam (1 For Practical | 2 For Fianl) : ");
                flag = int.TryParse(Console.ReadLine(), out input);
            } while (!flag || !(input >= 1 && input <= 2));

            #endregion            //--------------------
            Console.WriteLine();
            if (input == 1)
            {
                Exam.CreatExam();
                Console.Clear();
                int counter = 0;
                do
                {
                    Console.WriteLine($"Create Question Number : {counter+1}");
                    Console.WriteLine();
                    practicalExam.CreateQuesion ();
                    counter++;
                } while (counter < Exam.NumberOfQuestions);

            }

            if (input == 2)
            {
               Exam.CreatExam();
                Console.Clear();
                int counter = 0;
                do
                {
                    Console.WriteLine($"Create Question Number : {counter +1}");
                    Console.WriteLine();

                    finalExam.CreatQuestion();
                    counter++;
                } while (counter < Exam.NumberOfQuestions);

            }
        }
        public static void StartExam()
        {
            string YesOrNo;
            bool isValid = false;

            do
            {
                Console.WriteLine("Do you want to start the Exam now? (yes or no): ");
                YesOrNo = Console.ReadLine()?.Trim().ToLower();

                isValid = YesOrNo == "yes" || YesOrNo == "no";

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }

            } while (!isValid);
            if (YesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Exam.showExam();
            }

        }
        public static void ShowYourMark()
        {
            string YesOrNo;
            bool isValid = false;

            do
            {
                Console.WriteLine("Do you want to Show your Mark ? (yes or no): ");
                YesOrNo = Console.ReadLine()?.Trim().ToLower();

                isValid = YesOrNo == "yes" || YesOrNo == "no";

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }

            } while (!isValid);
            if (YesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(Exam.ShowMark());
            }
        }
    }
}
