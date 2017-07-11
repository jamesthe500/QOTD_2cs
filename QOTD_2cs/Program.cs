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
        }

        private static void AddAnswer(IRepository<Answer> answerRepository)
        {
            answerRepository.Add(new Answer { AnswerText = "Wouldn't you like to know?"});
            answerRepository.Add(new Answer { AnswerText = "123-34-4300" });
        }

        private static void CountAnswers(IRepository<Answer> answerRepository)
        {
            Console.WriteLine(answerRepository.FindAll().Count());
        }
    }
}
