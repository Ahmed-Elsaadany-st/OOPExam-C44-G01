using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class FinalExam : Exam
    {
        
        MCQ mcq=new MCQ();

        TrueOrFalse TorF=new TrueOrFalse();

       
        public MCQ mcqQuestion { get; set; }
        public TrueOrFalse TrueOrFalseQustion { get; set; }

        
        public  void CreatQuestion()
        {
            bool flag=false;
            int input;
            do
            {
                Console.Write("Enter the type of Question( 1 for MCQ Quesion | 2 for True of False Question)  : ");
                flag=int.TryParse(Console.ReadLine(), out input);

            } while (!flag || input < 1 || input > 2);
            Console.WriteLine();
            if (input == 1)
            {
              
                    mcq.CreateMcqQuesion();
            }
            if (input == 2)
            {
                
                    TorF.CreateTrueOrFalseQuestion(); // needs to be built
                
            }

        }

    }
}
