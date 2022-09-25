using Library_Dbcontext;
using library_Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace library_management
{
    public  static class AddUserDefalut
    {    /// <summary>
         /// This function for add users to the database by default if no user in data base
         /// </summary>
        public static void Adduserdefalut()
        {
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
        }

    }
}
