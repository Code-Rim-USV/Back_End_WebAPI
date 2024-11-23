using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Back_End_WebAPI.Models;

namespace Back_End_WebAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Seed Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            FirstName = "Ovidiu",
                            LastName = "Gherman",
                            Password = "OG12345",
                            Email = "ovidiug@eed.usv.ro"
                        },
                        new User
                        {
                            FirstName = "Simona-Anda",
                            LastName = "Tcaciuc",
                            Password = "ST12345",
                            Email = "tcaciuc.anda@usm.ro"
                        },
                        new User
                        {
                            FirstName = "Ionel",
                            LastName = "Zagan",
                            Password = "IZ12345",
                            Email = "zagan@eed.usv.ro"
                        },
                        new User
                        {
                            FirstName = "Catalin",
                            LastName = "Beguni",
                            Password = "CB12345",
                            Email = "catalin.beguni@usm.ro"
                        },
                         new User
                         {
                             FirstName = "Andrei",
                             LastName = "Diaconu",
                             Password = "AD12345",
                             Email = "andrei.diaconu@usm.ro"
                         } /// Asistanti
                    );
                    context.SaveChanges();
                }

                // Seed HasRoles
                if (!context.HasRoles.Any())
                {
                    var userJohn = context.Users.FirstOrDefault(u => u.Email == "john.pork@gmail.com");
                    var userJack = context.Users.FirstOrDefault(u => u.Email == "smith9023@gmail.com");
                    Console.WriteLine("id " + userJohn.UserID);
                    if (userJohn != null && userJack != null)
                    {
                        context.HasRoles.AddRange(
                            new HasRole
                            {
                                UserID = userJohn.UserID,

                                Role = "Professor"
                                //,User = userJohn

                            },
                            new HasRole
                            {
                                UserID = userJack.UserID,
                                Role = "Student"
                                //,User = userJack
                            }
                        );
                        context.SaveChanges();
                    }
                }

                // Seed StudentGroups
                if (!context.StudentGroups.Any())
                {
                    var userJack = context.Users.FirstOrDefault(u => u.Email == "smith9023@gmail.com");

                    if (userJack != null)
                    {
                        context.StudentGroups.Add(
                            new StudentGroup
                            {
                                UserID = userJack.UserID,
                                Group = 101
                                //,User = userJack
                            }
                        );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}