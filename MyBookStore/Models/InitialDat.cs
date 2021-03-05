using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MyBookStore.Models
{
    public class InitialDat
    {
        public static void DataPopulated(IApplicationBuilder app)
        {
            MBS_DBContext context = app.ApplicationServices
                                    .CreateScope().ServiceProvider
                                    .GetRequiredService<MBS_DBContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                new Book
                {
                    Name = "How Computer Works",
                    Description = "Overview of how everything in your computer works",
                    Category = "General Computer Knowledge",
                    Price = 45
                },
                new Book
                {
                    Name = "Upgrading and Repairing PCs",
                    Description = "In depth overview of computers and computer hardware",
                    Category = "General Computer Knowledge",
                    Price = 50.15M
                },
                new Book
                {
                    Name = "CompTIA A+ Certification All in One Exam",
                    Description = "Everything asked in the A+ Certification test",
                    Category = "A plus Certification",
                    Price = 70
                },
                new Book
                {
                    Name = "Ghost in the Wires",
                    Description = "One of the best known hackers in history",
                Category = "Hacking and computer security",
                    Price = 55
                },
                new Book
                {
                    Name = "Hacking Exposed",
                    Description = "Great series of books that covers all types of computer security related topics",
                    Category = "Hacking and computer security",
                    Price = 40
                },
                new Book
                {
                    Name = "Design Patterns: Elements of Reusable Object Oriented Software",
                    Description = "A great source of information on object oriented design theory",
                    Category = "Computer Programming",
                    Price = 110
                },
                new Book
                {
                    Name = "Don't Make Me Think!",
                    Description = "A beautiful and well designed book that covers all the basics of HTML and CSS used for web design",
                    Category = "Web Design",
                    Price = 35
                },
                new Book
                 {
                    Name = "Getting Started in Electronics",
                    Description = "Beginner's electronics book containing hand drawn diagrams of each of the circuits",
                    Category = "Electronics",
                    Price = 85
                });

                context.SaveChanges();
            }
        }
    }
}
