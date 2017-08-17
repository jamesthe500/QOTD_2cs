using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QOTD_2cs
{
    class Program
    {
        public static void Main(string[] args)
        {
            var answers = ProcessAnswers("AnswersDB.csv");
            AddAnswer(answers);
            CountAnswers(answers);
        }

        private static List<Answer> ProcessAnswers(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                        {
                            var columns = l.Split(',');
                            return new Answer
                            {
                                Answerer = columns[0],
                                Question = columns[1],
                                Day = int.Parse(columns[2]),
                                AnswerText = columns[3],
                                Index = int.Parse(columns[4]),
                            };
                        });
            return query.ToList();
        }

        private static void AddAnswer(List<Answer> answers)
        {
            answers.Add(new Answer { AnswerText = "Wouldn't you like to know?", Index = 4 });
            answers.Add(new Answer { AnswerText = "123-34-4300", Index = 4});
        }

        private static void CountAnswers(List<Answer> answerRepository)
        {
            Console.WriteLine(answerRepository.FindAll(e => e.Index >= 0).Count());
            foreach (var Answer in answerRepository)
            {
                Console.WriteLine(Answer.AnswerText);
            }
           
        }
    }
}

