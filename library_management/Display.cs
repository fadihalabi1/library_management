using Library_Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management
{
    public static class Display
    {  /// <summary>
       ///This function displays the information of the books in the library
       /// </summary>
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

                        Console.WriteLine("---------------------------" +
                        "-------------------------------------");
                    }
                    Console.WriteLine("total of copes for books=" +
                                    books.Sum(c => c.Count_Copes));
                    Console.WriteLine("---------------------------" +
                        "-------------------------------------");
                } 
            }
        }
        /// <summary>
        /// This function is to display the information of a book specified by the identifier
        /// </summary>
        /// <param name="id"></param>
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

                       Console.WriteLine("---------------------------" +
                            "-------------------------------------");
                }
            }
        }
        /// <summary>
        /// This function displays the total number of books in the store
        /// </summary>
        public static void totalcountbooks()
        {
            using (library_Db context = new library_Db())
            {
                var book = context.Books?.ToList();
                Console.WriteLine("The total number of books in stock is: ["
                                  + (book?.Count()) + "]");

                Console.WriteLine("---------------------------" +
                          "-------------------------------------");
            }
        }
        /// <summary>
        /// This function shows the user a list of available options
        /// </summary>
        /// <returns></returns>
        public static string checklistfunction()
        {

            Console.WriteLine("enter (1) for show information all books \n" +
                              "enter (2) View information for a specific book\n" +
                              "enter (3) for delete a specific book\n" +
                              "enter (4) for apdate title and price a specific book\n"+
                              "enter (5) To log out of the application");
            Console.WriteLine("----------------------------------------------------------");
            string? select = Console.ReadLine();


            return select;
        }
    }
}
