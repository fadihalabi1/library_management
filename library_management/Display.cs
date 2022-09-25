using Library_Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management
{
    public static class Display
    {
       public static void display_books()
        {
            using (library_Db context = new library_Db())
            {
                var books  = context.Books?.ToList();
                if (books?.Count != 0 )
                {
                    foreach (var book in books )
                    {
                        Console.WriteLine($"id book: {book.Id}," +
                            $" name book: {book.Title_Book}," +
                            $" number copes:{book.Count_Copes} " );
                    }
                    Console.WriteLine("total of copes for books=" +
                                    books.Sum(c => c.Count_Copes));
                } 
            }
        }

        public static void DisplayBookSpecefed(int id)
        {
            using (library_Db context = new library_Db())
            {
                var book = context.Books?.Where(i => i.Id == id).FirstOrDefault();
                if (book!= null)
                {
                        Console.WriteLine($"id book:[{book.Id}]," +
                            $" name book: [{book.Title_Book}]," +
                            $" number copes:[{book.Count_Copes}] ");
               
                }
            }
        }
    }
}
