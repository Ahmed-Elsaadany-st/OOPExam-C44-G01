using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal  class Exam
    {
       public static int ExamTime {  get; set; }
        public static int NumberOfQuestions { get; set; }  
        
      public static void CreatExam()
        { bool flag=false;
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
            NumberOfQuestions=numberOfQuestions;
            Console.WriteLine();
        }
       
        

        
      
    }
}
