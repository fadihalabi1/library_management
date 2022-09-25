using Library_Dbcontext;
using library_Domin;
using System.Text.Json;

namespace library_management
{
    public class Program
    {
        static void Main(string[] args)
        {  
            using (library_Db context = new library_Db())
            {
                var book = context.Books?.ToList();
                if (book?.Count == 0)
                {
                    context.Books?.AddRange(MangamentBooks.fillbooks());
                    context.SaveChanges();
                }
            }
            string conten = File.ReadAllText("user.json");
            var defalut_user = JsonSerializer.Deserialize<List<User>>(conten);
            using (library_Db context = new library_Db())
            {
                var user = context.Users?.ToList();
                if (user?.Count == 0 && defalut_user != null)
                {
                    context.Users?.AddRange(defalut_user);
                    context.SaveChanges();
                }
            }



            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("plese enter user name");
            //var user_name = Console.ReadLine();
            //Console.WriteLine("plese enter password");
            //var password = Console.ReadLine();

            if (Login.Authintcation("hadi", "1234"))
            {
                Console.WriteLine("You are logged in successfully" +
                    "");
                using (library_Db context = new library_Db())
                {
                    var book = context.Books?.ToList();
                 Console.WriteLine("the totalof number books is: ["+(book?.Count())+"]");
                }
                //Console.WriteLine("enter (1) for show information all books \n" +
                //                  "enter (2) View information for a specific book\n" +
                //                  "enter (3) for delete a specific book\n" +
                //                  "enter (4) for apdate title and price a specific book");
                //string? select = Console.ReadLine();
                string select = funcselect();
                
                if ( select != null)
                {
                    switch (select)
                    {
                        case "1":
                            Display.display_books();
                            break;
                        case "2":
                            Console.WriteLine("plese enter id book");
                            var id =  Console.ReadLine();
                            if (id != null)
                            {
                                if (int.TryParse(id, out int id1))
                                {
                                    Display.DisplayBookSpecefed(id1);
                                }
                            }
                            break;
                        case "3":
                            Console.WriteLine("plese enter id book  exampl(1,2,3..)");
                            var idbookforapdate = Console.ReadLine();
                            Console.WriteLine(" plese enter the new title example(somthink)");
                            string newtitle = Console.ReadLine();
                            Console.WriteLine(" plese enter the new price");
                            string newprice = Console.ReadLine();


                            if ((idbookforapdate != null) && (newtitle!= null)&& (newprice!=null))
                            {
                                if (int.TryParse(idbookforapdate, out int idapdate))
                                {
                                   if(int.TryParse(newprice,out int newprice1))
                                    {
                                        MangamentBooks.ApdateDataBook(idapdate, newtitle, newprice1);
                                        Display.DisplayBookSpecefed(idapdate);
                                    }
                                    else
                                    {
                                        Console.WriteLine("filed Enter the price again!!!");
                                    }
                                }
                                else { Console.WriteLine("filed Enter the id again!!!!"); }
                            }
                           
                            break; 

                        default:
                            Console.WriteLine("Re-enter the selection number again");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Try again. There may be an error in your username or password");
            }
          
         
        }

        private static string funcselect()
        {
            Console.WriteLine("enter (1) for show information all books \n" +
                                  "enter (2) View information for a specific book\n" +
                                  "enter (3) for delete a specific book\n" +
                                  "enter (4) for apdate title and price a specific book");
            string? select = Console.ReadLine();
            return select;
        }

      
        }
}