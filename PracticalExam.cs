using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class PracticalExam : Exam
    {
        public MCQ mcqQuestion { get; set; }

        

       public static void CreateQuesions()
        {
            Console.WriteLine("In Pracical Exam there is only MCQ Quesions");
            int counter = 1;
            do
            {
                MCQ.CreateMcqQuesion();
                counter++;
            } while (counter <= Exam.NumberOfQuestions);

        }
    }
}
