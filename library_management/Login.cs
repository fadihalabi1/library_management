using Library_Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management
{
   public static class Login
    { 
      public  static bool Authintcation(string user_name, string password)
        {
            using (library_Db context = new library_Db())
            {

                var user = context.Users?.Where(u => u.Name == user_name && u.Password == password);
                if (user?.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;   
                }
              
            }

         
           }
    }
}
