using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = System.DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverURL = "https....",
                        DateAdded = System.DateTime.Now
                    }, new Models.Book()
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead = false,
                        Rate = 3,
                        Genre = "Biography",
                        CoverURL = "https....",
                        DateAdded = System.DateTime.Now
                    }, new Models.Book()
                    {
                        Title = "3rd Book Title",
                        Description = "3rd Book Description",
                        IsRead = true,
                        DateRead = System.DateTime.Now.AddDays(-20),
                        Rate = 2,
                        Genre = "Wikipidia",
                        CoverURL = "https....",
                        DateAdded = System.DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
