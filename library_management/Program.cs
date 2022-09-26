using Library_Dbcontext;
using library_Domin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;
using System.Text.Json;

namespace library_management
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Note: There are hints about the function of each function.
            //To see them,
            //just hover your mouse pointer over the function
            
            var user_name = "";
            var password="" ;

            AddUserDefalut.Adduserdefalut();  

            MangamentBooks.fillbooks();
            bool Auth = false;
            while (Auth != true)
            {

                Console.WriteLine("Hello, World!");

                Console.WriteLine("plese enter user name");
                user_name = Console.ReadLine();
                Console.WriteLine("plese enter password");
                password = Console.ReadLine();
                if (user_name != null && password != null)
                {
                    Auth = Login.Authintcation(user_name, password);
                    Console.WriteLine("You are logged in successfully");
                    Console.WriteLine("---------------------------" +
                              "-------------------------------------");

                    Display.totalcountbooks();
                  
                }
                else
                {
                    Console.WriteLine(" Error:Try again. " +
                        "There may be an error in your username or password");

                }
            }

            while (Auth!=false)
            {
                
                string select = Display.checklistfunction();

                if (select != null)
                {
                    switch (select)
                    {
                        case "1":
                            Display.display_books();

                            break;

                        case "2":
                            Console.WriteLine("plese enter id book");
                            var id = Console.ReadLine();
                            if (id != null)
                            {
                                if (int.TryParse(id, out int id1))
                                {
                                    Display.DisplayBookSpecefed(id1);
                                }
                            }
                            break;
                        case "3":
                            Console.WriteLine("plese enter id book");
                            var idbooktoremove = Console.ReadLine();
                            if (idbooktoremove != null)
                            {
                                if (int.TryParse(idbooktoremove, out int idremov))
                                {
                                   MangamentBooks.RemoveBook(idremov);
                                    Console.WriteLine("The book has been successfully deleted");

                                    Console.WriteLine("---------------------------" +
                                             "-------------------------------------");
                                }
                            }
                            break;
                        case "4":
                            Console.WriteLine("plese enter id book  exampl(1,2,3..)");
                            var idbookforapdate = Console.ReadLine();
                            Console.WriteLine(" plese enter the new title example(somthink)");
                            string? newtitle = Console.ReadLine();

                            Console.WriteLine(" plese enter the new price");
                            string? newprice = Console.ReadLine();


                            if ((idbookforapdate != null) && (newtitle != null) && (newprice != null))
                            {
                                if (int.TryParse(idbookforapdate, out int idapdate))
                                {
                                    if (int.TryParse(newprice, out int newprice1))
                                    {
                                        MangamentBooks.ApdateDataBook(idapdate, newtitle, newprice1);
                                        Display.DisplayBookSpecefed(idapdate);
                                    }
                                    else
                                    {
                                        Console.WriteLine(" Error:filed Enter the price again!!!");
                                    }
                                }
                                else { Console.WriteLine("Error:filed Enter the id again!!!!"); }
                            }

                            break;
                            case"5":
                                Auth=false;
                            break;

                        default:
                            Console.WriteLine("Re-enter the selection number again");
                            break;
                    }


                }
                else
                {
                    Console.WriteLine("error:You are entering an empty value " +
                                      "plese try agin must by number");
                }

            } 
            
            
        
            Console.ReadKey();
        }
       
       

      
    }
}