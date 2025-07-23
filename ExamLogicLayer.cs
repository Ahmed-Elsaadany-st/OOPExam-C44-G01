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
        public static void StartCreating()
        {
            bool flag = false;
            int input;
            do
            {
                Console.Write("Please Enter the type of Exam (1 For Practical | 2 For Fianl) : ");
                flag = int.TryParse(Console.ReadLine(), out input);
            } while (!flag || !(input >= 1 && input <= 2));
            //--------------------
            Console.WriteLine();
            if (input == 1)
            {
                Exam.CreatExam();
                Console.Clear();
                PracticalExam.CreateQuesions();
            }

            if (input == 2)
            {
               Exam.CreatExam();
                Console.Clear();
                FinalExam.CreatQuestion();

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
    }
}
