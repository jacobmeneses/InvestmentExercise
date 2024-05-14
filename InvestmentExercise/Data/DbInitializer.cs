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

            var companies = new Company[]
            {
                new Company
                {
                    ID = 1,
                    Name = "Company One",
                    CreatedAt = DateTime.Now,
                },
                new Company
                {
                    ID = 2,
                    Name = "Company Two",
                    CreatedAt = DateTime.Now,
                },
                new Company
                {
                    ID = 3,
                    Name = "Company Three",
                    CreatedAt = DateTime.Now,
                }
            };

            context.Companies.AddRange(companies);

            context.SaveChanges();

            var company1 = context.Companies.Where(c => c.Name == "Company One").First();
            var company2 = context.Companies.Where(c => c.Name == "Company Two").First();
            var company3 = context.Companies.Where(c => c.Name == "Company Three").First();

            var oportunities = new Oportunity[]
            {
                new Oportunity
                {
                    ID = 1,
                    Total = 1000.00f,
                    Rate = rate,
                    DaysLimit = 30,
                    Company = company1,
                    CreatedAt = DateTime.Now,
                },
                new Oportunity 
                {
                    ID = 2,
                    Total = 1000.00f,
                    Rate = rate,
                    DaysLimit = 60,
                    Company = company2,
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
                    DaysLimit = 90,
                    Company = company3,
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
                },
                new Oportunity
                {
                    ID = 4,
                    Total = 4000.50f,
                    Rate = 0.17f,
                    DaysLimit = 60,
                    Company = company2,
                    CreatedAt = DateTime.Now,
                },
                new Oportunity
                {
                    ID = 5,
                    Total = 5500.50f,
                    Rate = 0.17f,
                    DaysLimit = 45,
                    Company = company1,
                    CreatedAt = DateTime.Now,
                },
                new Oportunity
                {
                    ID = 6,
                    Total = 10000.00f,
                    Rate = 0.20f,
                    DaysLimit = 90,
                    Company = company3,
                    CreatedAt = DateTime.Now,
                }
            };

            context.Oportunities.AddRange(oportunities);

            context.SaveChanges();


        }
    }
}
