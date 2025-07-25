namespace OOPExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExamLogicLayer examLogicLayer = new ExamLogicLayer();
          examLogicLayer.StartCreating();
            Console.Clear();
           ExamLogicLayer.StartExam();
            ExamLogicLayer.ShowYourMark();
        }
    }
}
