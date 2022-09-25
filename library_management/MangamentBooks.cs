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
        /// <summary>
        ///  This function is to add books to the database if it is empty
        /// </summary>
        /// <returns></returns>
        public static List<Book> fillbooks()
        {

            using (library_Db context = new library_Db())
            {
                var book = context.Books?.ToList();
                if (book?.Count == 0)
                {
                    context.Books?.AddRange(fillbooks());
                    context.SaveChanges();
                }
            }
            var book1 = new List<Book>
            {
                  new Book(){Title_Book="lern c#",Price=20,Count_Copes=5},
                new Book(){Title_Book="sql server",Price=15,Count_Copes=6},
                  new Book(){Title_Book="lern python",Price=10,Count_Copes=2}

            };
            return book1;
        }

        /// <summary>
        /// This function is to delete a specific book by its ID number
        /// </summary>
        /// <param name="id"></param>
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
        } /// <summary>
          /// This function is to modify the data of a specific book by the ID number it has been saved
          /// </summary>
          /// <param name="id"></param>
          /// <param name="title"></param>
          /// <param name="price"></param>
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
