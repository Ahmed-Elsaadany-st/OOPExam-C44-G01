using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class Answer
    {
        public int answerID {  get; set; }
        public string[] answerText {  get; set; }=new string[4];
        public Answer(string[] AnswerText)
        {
            
            answerText=AnswerText;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < answerText.Length; i++)
            {
                result += $" {i + 1}] {answerText[i]}\n";
            }
            return result;
        }

    }
}
