using InvestmentExercise.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InvestmentExercise.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InvestmentExerciseContext context)
        {
            // DB has been seed
            if (context.Oportunities.Any()) { return; }

            var pass = "$2a$12$5p.IJb39rhzqb0rZanG2Cu659YxY/sl36iWuf54HLj/rZi4K.SeOi";
            var rate = 0.16f;

            var users = new User[]
            {
                new User
                {
                    ID = 1,
                    Name = "Jacob Meneses",
                    Email = "jaykobyou@gmail.com",
                    Password = pass,
                    Balance = 10000.00f,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                },
                new User
                {
                    ID = 2,
                    Name = "Not enough",
                    Email = "not_enough@example.com",
                    Password = pass,
                    Balance = 0.00f,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                },
                new User
                {
                    ID = 3,
                    Name = "Exceeds",
                    Email = "exceeds@example.com",
                    Password = pass,
                    Balance = 10000.00f,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                },
                new User
                {
                    ID = 4,
                    Name = "Other",
                    Email = "other@example.com",
                    Password = pass,
                    Balance = 10000.00f,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                },
            };

            context.Users.AddRange(users);

            context.SaveChanges();

            var user1 = context.Users.Where(u => u.Email == "other@example.com").First();
            var user2 = context.Users.Where(u => u.Email == "exceeds@example.com").First();


            var oportunities = new Oportunity[]
            {
                new Oportunity
                {
                    ID = 1,
                    Total = 1000.00f,
                    Rate = rate,
                    CreatedAt = DateTime.Now,
                },
                new Oportunity 
                {
                    ID = 2,
                    Total = 1000.00f,
                    Rate = rate,
                    CreatedAt = DateTime.Now,
                    Investments = new Investment[]
                    {
                        new Investment
                        {
                            Total = 500.00f,
                            CreatedAt = DateTime.Now,
                            User = user1,
                        }
                    }
                },
                new Oportunity
                {
                    ID = 3,
                    Total = 2000.00f,
                    Rate = rate,
                    CreatedAt = DateTime.Now,
                    Investments = new Investment[]
                    {
                        new Investment
                        {
                            Total = 500.00f,
                            CreatedAt = DateTime.Now,
                            User = user1,
                        },
                        new Investment
                        {
                            Total = 500.00f,
                            CreatedAt = DateTime.Now,
                            User = user2,
                        }
                    }
                }
            };

            context.Oportunities.AddRange(oportunities);

            context.SaveChanges();


        }
    }
}
