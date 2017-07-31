using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QOTD_2cs
{
    class Program
    {
        public static void Main(string[] args)
        {
            var answers = new List<Answer>
            {
                new Answer { Id = 0, Answerer = "Jim", Question = "Ever danced by the pale moon light?", Day = 0, AnswerText = "Not lately.", Index = 1},
                new Answer { Id = 1, Answerer = "Jellybean", Question = "Ever danced by the pale moon light?", Day = 0, AnswerText = "Every chance I get!", Index = 1},
                new Answer { Id = 2, Answerer = "Jim", Question = "What's your favorite admonishment?", Day = 1, AnswerText = "You should know better!", Index = 2},
                new Answer { Id = 3, Answerer = "Jellybean", Question = "What's your favorite admonishment?", Day = 1, AnswerText = "I doth protest too much!", Index = 2},
                new Answer { Id = 4, Answerer = "Jim", Question = "Who is your crush today?", Day = 2, AnswerText = "Jellybean.", Index = 3},
                new Answer { Id = 5, Answerer = "Jellybean", Question = "Who is your crush today?", Day = 2, AnswerText = "Jim.", Index = 3}
            };
            AddAnswer(answers);
            CountAnswers(answers);
        }

        private static void AddAnswer(List<Answer> answerRepository)
        {
            answerRepository.Add(new Answer { AnswerText = "Wouldn't you like to know?"});
            answerRepository.Add(new Answer { AnswerText = "123-34-4300" });
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

/*
             * This block based on some instructions that require SQL Server. Not at my disposal just yet.
             * it was in the main loop
        // sets it up so that every time the app runs it is okay to drop and recreate the DB, simpler
        Database.SetInitializer(new DropCreateDatabaseAlways<AnswersDb>());

            // answerRepository allows us to work with the answer Db
            // a SqlRepository requires a DbContext instance. Give enough info to create proper DbScheme
            // wrapped in a using clause because it is disposable.
            using (IRepository<Answer> answerRepository = new SqlRepository<Answer>(new AnswersDb()))
            {
                AddAnswer(answerRepository);
                CountAnswers(answerRepository);
                
            }
            //  using (IRepository<Answer> )
            */
