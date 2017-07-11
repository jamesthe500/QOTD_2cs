using System;
namespace QOTD_2cs
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public string Answerer { get; set; }
        public string Question { get; set; }
        public int Day { get; set; }
        public int Index { get; set; }
    }
}
