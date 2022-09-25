using Library_Dbcontext;
using library_Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management
{
    public static class MangamentBooks
    {

        public  static List<Book> fillbooks()
        {
            var book = new List<Book>
            {
                  new Book(){Title_Book="lern c#",Price=20,Count_Copes=5},
                new Book(){Title_Book="sql server",Price=15,Count_Copes=6},
                  new Book(){Title_Book="lern python",Price=10,Count_Copes=2}

            };
            return book;
        }


        public static void RemoveBook(int id)
        {
            using (library_Db context = new library_Db())
            {
                var book = context.Books?.Where(i => i.Id == id).FirstOrDefault();
               if(book != null)
                {
                    context.Books?.Remove(book);
                    context.SaveChanges();
                }
                Display.display_books();
                 
            }
        }
        public static void ApdateDataBook(int id,string title,int price)
        {

            using (library_Db context = new library_Db())
            {
                var book = context.Books?.Where(i => i.Id == id).FirstOrDefault();
                if (book != null)
                {
                    book.Title_Book = title;
                    book.Price = price;
                    context.SaveChanges();
                    Console.WriteLine("The book information has been successfully updated ");
                }
                Display.display_books();

            }
        }
    }
}
