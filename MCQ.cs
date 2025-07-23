using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class MCQ:Question
    {
       
        public static Answer[] answerList { get; set; }=new Answer[4];
        public int CorrectAnswerId { get; set; }

        public static void CreateMcqQuesion()
        {
            Header = "MCQ Quesion";
            Console.WriteLine(Header);
            #region Take Body as an input
            bool isValid = false;
            string body;
            do
            {
                Console.WriteLine("Enter Question body: ");
                body = Console.ReadLine();
                isValid = !string.IsNullOrWhiteSpace(body) &&
             body.Any(char.IsLetter);

                if (!isValid)
                    Console.WriteLine("Question body must contain letters and cannot be empty or numbers only.");

            }
            while (!isValid);
            Body = body;
            Console.WriteLine();
            #endregion

            #region Take Mark as an input
            bool flag = false;
            int mark = 0;
            do
            {
                Console.WriteLine("Enter the mark (1:5) ");
                flag = int.TryParse(Console.ReadLine(), out mark);
            } while (!flag || mark > 5 || mark < 1);
            Mark = mark;
            Console.WriteLine();
            #endregion

            #region Take Choices
            Console.WriteLine("Enter the Choices:");
            string choice = "";
            for (int i = 0; i < answerList.Length; i++)
            {
                do
                {
                    Console.Write($"Enter Choice number {i + 1}: ");
                    choice = Console.ReadLine();

                    isValid = !string.IsNullOrWhiteSpace(choice) &&
                              choice.Any(char.IsLetter);

                    if (!isValid)
                        Console.WriteLine("Choice must contain at least one letter and cannot be empty or only numbers.");

                } while (!isValid);

                answerList[i] = new Answer() { answerText = choice, answerID = (i + 1) };

            }
            #endregion

            #region Determine The CorrectAnsId
            int CorrAns;
            bool isParsed= false;
            do
            {
                Console.WriteLine("Enter the Correct AnswerId (1:4) : ");
                isParsed=int.TryParse(Console.ReadLine(),out CorrAns);
            } while (!isParsed || CorrAns <=1 ||CorrAns >=4 );

            #endregion


        }

    }

}
