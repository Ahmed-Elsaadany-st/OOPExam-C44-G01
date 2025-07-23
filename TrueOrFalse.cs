using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class TrueOrFalse:Question
    {
        public required List<Answer> answerList { get; set; }
        public int rightAnswerId { get; set; }

        public static void CreateTrueOrFalseQuestion()
        {

        }
       
    }
}
