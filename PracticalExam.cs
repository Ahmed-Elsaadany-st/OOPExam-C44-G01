using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class PracticalExam : Exam
    {
         MCQ mcq =new MCQ();

        

       public  void CreateQuesion()
        {
            mcq.CreateMcqQuesion();
            

        }
    }
}
