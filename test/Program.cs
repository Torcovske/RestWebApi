using Data;
using Data.Entities;
using System;
using System.Linq;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestMethod();
            void TestMethod()
            {
                var context = new DataContext();
                var author1 = context.Authors.FirstOrDefault(x => x.LastName == "Пушкин");

                var books2 = new Books() { Id = new Guid(), Name = "Золотой петушок", Cost = 666 };
                context.Books.Add(books2);
                //var Author1 = new Authors() { Id = new Guid(), FirstName = "Александр", LastName = "Пушкин", MiddleName = "Сергеевич" };
                //var Author2 = new Authors() { Id = new Guid(), FirstName = "Сергей", LastName = "Есенин", MiddleName = "Александрович" };
                var conn = new AuthorsBooks() { Authors = author1, Books = books2 };
            
                context.AuthorsBooks.Add(conn);
                context.SaveChanges();

                //context.Authors.Add(Author1);
                //context.Authors.Add(Author2);
                //context.Books.Add(book1);
                //context.SaveChanges();
            }
        }
    }
}
