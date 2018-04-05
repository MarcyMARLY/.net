using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week11Lab7.Data;

namespace Week11Lab7.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserContext(
                serviceProvider.GetRequiredService<DbContextOptions<UserContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }
                context.SaveChanges();

            }
           
        }
    }
}
