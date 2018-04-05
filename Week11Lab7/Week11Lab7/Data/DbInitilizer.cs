using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week11Lab7.Data
{
    public class DbInitilizer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }
            context.SaveChanges();
        }
    }
}
