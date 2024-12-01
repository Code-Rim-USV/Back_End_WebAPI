using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Back_End_WebAPI.Models;

namespace Back_End_WebAPI.Data
{
    public static class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
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
                            FirstName = "Aurelia",
                            LastName = "Pascut",
                            Password = "AP12345",
                            Email = "aurelia@usm.ro"
                        },
                         new User
                         {
                             FirstName = "Andrei",
                             LastName = "Diaconu",
                             Password = "AD12345",
                             Email = "andrei.diaconu@usm.ro"
                         }, /// Asistanti
                         new User
                         {
                             FirstName = "Sorin",
                             LastName = "Pohoata",
                             Password = "SP12345",
                             Email = "sorinp@eed.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Marius",
                             LastName = "Prelipceanu",
                             Password = "MP12345",
                             Email = "marius.prelipceanu@usm.ro"
                         },
                         new User
                         {
                             FirstName = "Aurelian",
                             LastName = "Rotaru",
                             Password = "AR12345",
                             Email = "rotaru@eed.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Bianca",
                             LastName = "Satco",
                             Password = "BS12345",
                             Email = "bisatco@eed.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Eugen",
                             LastName = "Hopulele",
                             Password = "EH12345",
                             Email = "eugenh@eed.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Radu Dumitru",
                             LastName = "Pentiuc",
                             Password = "RP12345",
                             Email = "radup@eed.usv.ro"
                         }, // Studenti
                         new User
                         {
                             FirstName = "Stefan",
                             LastName = "Ilculesei-Meglei",
                             Password = "SI12345",
                             Email = "stefan.ilculesei@student.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Stefan",
                             LastName = "Rosca",
                             Password = "SR12345",
                             Email = "stefan.rosca@student.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Alexandru",
                             LastName = "Munteanu",
                             Password = "AM12345",
                             Email = "alexandru.munteanu6@student.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Alexandra",
                             LastName = "Joroveanu",
                             Password = "AJ12345",
                             Email = "alexandra.joroveanu@student.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Mert",
                             LastName = "Aydogan",
                             Password = "MA12345",
                             Email = "aydogan.mert@student.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Bogdan",
                             LastName = "Tibuleac",
                             Password = "BT12345",
                             Email = "bogdan.tibuleac@student.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Andrei",
                             LastName = "Aluculesei",
                             Password = "BT12345",
                             Email = "andrei.aluculesei@student.usv.ro"
                         },
                         new User
                         {
                             FirstName = "Timotei",
                             LastName = "Moscaliuc",
                             Password = "TM12345",
                             Email = "timotei.moscaliuc@student.usv.ro"
                         }
                    );
                    context.SaveChanges();
                }
                // Seed Locations
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(
                        new Location
                        {
                            LocationName = "C201"
                        }, new Location
                        {
                            LocationName = "C202"
                        },
                        new Location
                        {
                            LocationName = "C203"
                        },
                        new Location
                        {
                            LocationName = "C204"
                        },
                        new Location
                        {
                            LocationName = "C301"
                        },
                        new Location
                        {
                            LocationName = "C303"
                        }, new Location
                        {
                            LocationName = "Amfiteatrul Dimitrie Hurmuzescu"
                        },
                        new Location
                        {
                            LocationName = "Amfiteatrul Remus Radulet"
                        }
                        );
                }
                    // Seed HasRoles
                    if (!context.HasRoles.Any())
                {
                    var userGherman = context.Users.Where(u => u.Email == "ovidiug@eed.usv.ro").First();
                    var userTcaciuc = context.Users.FirstOrDefault(u => u.Email == "tcaciuc.anda@usm.ro");
                    var userZagan = context.Users.FirstOrDefault(u => u.Email == "zagan@eed.usv.ro");
                    var userBeguni = context.Users.FirstOrDefault(u => u.Email == "catalin.beguni@usm.ro");
                    var userAurelia = context.Users.FirstOrDefault(u => u.Email == "aurelia@usm.ro");
                    var userDiaconu = context.Users.FirstOrDefault(u => u.Email == "andrei.diaconu@usm.ro");
                    var userPohoata = context.Users.FirstOrDefault(u => u.Email == "sorinp@eed.usv.ro");
                    var userPrelipceanu = context.Users.FirstOrDefault(u => u.Email == "marius.prelipceanu@usm.ro");
                    var userRotaru = context.Users.FirstOrDefault(u => u.Email == "rotaru@eed.usv.ro");
                    var userSatco = context.Users.FirstOrDefault(u => u.Email == "bisatco@eed.usv.ro");
                    var userHopulele = context.Users.FirstOrDefault(u => u.Email == "eugenh@eed.usv.ro");
                    var userPentiuc = context.Users.FirstOrDefault(u => u.Email == "radup@eed.usv.ro");
                    var userMeglei = context.Users.FirstOrDefault(u => u.Email == "stefan.ilculesei@student.usv.ro");
                    var userRosca = context.Users.FirstOrDefault(u => u.Email == "stefan.rosca@student.usv.ro");
                    var userMunteanu = context.Users.FirstOrDefault(u => u.Email == "alexandru.munteanu6@student.usv.ro");
                    var userJoroveanu = context.Users.FirstOrDefault(u => u.Email == "alexandra.joroveanu@student.usv.ro");
                    var userAydogan = context.Users.FirstOrDefault(u => u.Email == "aydogan.mert@student.usv.ro");
                    var userTibuleac = context.Users.FirstOrDefault(u => u.Email == "bogdan.tibuleac@student.usv.ro");
                    var userAluculesei = context.Users.FirstOrDefault(u => u.Email == "andrei.aluculesei@student.usv.ro");
                    var userMoscaliuc = context.Users.FirstOrDefault(u => u.Email == "timotei.moscaliuc@student.usv.ro");

                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userGherman.UserID,
                            Role = "Professor"
                        }
                        );
                    
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userTcaciuc.UserID,
                            Role = "Professor"
                        }
                        );
                   
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userZagan.UserID,
                            Role = "Professor"
                        }
                        );
                   
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userBeguni.UserID,
                            Role = "Professor"
                        }
                        );
                   
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userAurelia.UserID,
                            Role = "Professor"
                        }
                        );
                    
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userDiaconu.UserID,
                            Role = "Professor"
                        }
                        );
                   
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userPohoata.UserID,
                            Role = "Assistant"
                        }
                        );
                 
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userPrelipceanu.UserID,
                            Role = "Assistant"
                        }
                        );
                   
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userRotaru.UserID,
                            Role = "Assistant"
                        }
                        );
                    
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userSatco.UserID,
                            Role = "Assistant"
                        }
                        );
                  
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userHopulele.UserID,
                            Role = "Assistant"
                        }
                        );
                 
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userPentiuc.UserID,
                            Role = "Assistant"
                        }
                        );
                    
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userMeglei.UserID,
                            Role = "Student"
                        }
                        );
                    
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userMunteanu.UserID,
                            Role = "Student"
                        }
                        );
                   
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userJoroveanu.UserID,
                            Role = "Student"
                        }
                        );
                  
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userAydogan.UserID,
                            Role = "Student"
                        }
                        );
                    
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userAluculesei.UserID,
                            Role = "Student"
                        }
                        );
                    
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userMoscaliuc.UserID,
                            Role = "Student"
                        }
                        );
                   
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userRosca.UserID,
                            Role = "GroupLeader"
                        }
                        );
                   
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userTibuleac.UserID,
                            Role = "GroupLeader"
                        }
                        );
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userTibuleac.UserID,
                            Role = "Student"
                        }
                        );
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userRosca.UserID,
                            Role = "Student"
                        }
                        );
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userPrelipceanu.UserID,
                            Role = "Professor"
                        }
                        );
                    await context.HasRoles.AddAsync(
                        new HasRole
                        {
                            UserID = userSatco.UserID,
                            Role = "Professor"
                        }
                        );
                    context.SaveChanges();
                    
                }

                // Seed StudentGroups
                if (!context.StudentGroups.Any())
                {
                    var userMeglei = context.Users.FirstOrDefault(u => u.Email == "stefan.ilculesei@student.usv.ro");
                    var userRosca = context.Users.FirstOrDefault(u => u.Email == "stefan.rosca@student.usv.ro");
                    var userMunteanu = context.Users.FirstOrDefault(u => u.Email == "alexandru.munteanu6@student.usv.ro");
                    var userJoroveanu = context.Users.FirstOrDefault(u => u.Email == "alexandra.joroveanu@student.usv.ro");
                    var userAydogan = context.Users.FirstOrDefault(u => u.Email == "aydogan.mert@student.usv.ro");
                    var userTibuleac = context.Users.FirstOrDefault(u => u.Email == "bogdan.tibuleac@student.usv.ro");
                    var userAluculesei = context.Users.FirstOrDefault(u => u.Email == "andrei.aluculesei@student.usv.ro");
                    var userMoscaliuc = context.Users.FirstOrDefault(u => u.Email == "timotei.moscaliuc@student.usv.ro");
                    context.StudentGroups.AddRange(
                        new StudentGroup
                        {
                            UserID = userMeglei.UserID,
                            Group = 3141
                        },
                        new StudentGroup
                        {
                            UserID = userRosca.UserID,
                            Group = 3141
                        },
                        new StudentGroup
                        {
                            UserID = userMunteanu.UserID,
                            Group = 3141
                        },
                        new StudentGroup
                        {
                            UserID = userJoroveanu.UserID,
                            Group = 3141
                        },
                        new StudentGroup
                        {
                            UserID = userAydogan.UserID,
                            Group = 3141
                        },
                        new StudentGroup
                        {
                            UserID = userTibuleac.UserID,
                            Group = 3143
                        },
                        new StudentGroup
                        {
                            UserID = userAluculesei.UserID,
                            Group = 3143
                        },
                        new StudentGroup
                        {
                            UserID = userMoscaliuc.UserID,
                            Group = 3143
                        }
                        );
                    context.SaveChanges();
                }

                if (!context.Subjects.Any())
                {
                    var userGherman = context.Users.FirstOrDefault(u => u.Email == "ovidiug@eed.usv.ro");
                    var userPrelipceanu = context.Users.FirstOrDefault(u => u.Email == "marius.prelipceanu@usm.ro");
                    var userZagan = context.Users.FirstOrDefault(u => u.Email == "zagan@eed.usv.ro");
                    var userDiaconu = context.Users.FirstOrDefault(u => u.Email == "andrei.diaconu@usm.ro");
                    var userSatco = context.Users.FirstOrDefault(u => u.Email == "bisatco@eed.usv.ro");
                    context.Subjects.AddRange(
                        new Subject
                        {
                            ProfessorID = (int)userGherman.UserID,
                            SubjectName = "Proiectarea Translatoarelor"
                        },
                        new Subject
                        {
                            ProfessorID = (int)userPrelipceanu.UserID,
                            SubjectName = "Metode Numerice"
                        },
                        new Subject
                        {
                            ProfessorID = (int)userZagan.UserID,
                            SubjectName = "Protocoale de comunicații"
                        },
                        new Subject
                        {
                            ProfessorID = (int)userDiaconu.UserID,
                            SubjectName = "Fizică 2"
                        },
                        new Subject
                        {
                            ProfessorID = (int)userSatco.UserID,
                            SubjectName = "Matematici speciale"
                        }

                        );
                    context.SaveChanges();

                }

                if (!context.Requests.Any())
                {
                    var userGherman = context.Users.FirstOrDefault(u => u.Email == "ovidiug@eed.usv.ro");
                    var userPrelipceanu = context.Users.FirstOrDefault(u => u.Email == "marius.prelipceanu@usm.ro");
                    

                    var sub1 = context.Subjects.FirstOrDefault(u => u.SubjectName == "Proiectarea Translatoarelor");
                    var sub2 = context.Subjects.FirstOrDefault(u => u.SubjectName == "Metode Numerice");

                    context.Requests.AddRange(
                        new Request
                        {
                            SubjectID = (int)sub1.SubjectID,
                            ProfessorID = (int)userGherman.UserID,
                            Group = 3141,
                            Date = DateOnly.Parse("2025-03-14"),
                            Status = "Pending"

                        },
                        new Request
                        {
                            SubjectID = (int)sub2.SubjectID,
                            ProfessorID = (int)userPrelipceanu.UserID,
                            Group = 3141,
                            Date = DateOnly.Parse("2025-03-17"),
                            Status = "Pending"

                        },
                        new Request
                        {
                            SubjectID = (int)sub2.SubjectID,
                            ProfessorID = (int)userPrelipceanu.UserID,
                            Group = 3143,
                            Date = DateOnly.Parse("2025-03-20"),
                            Status = "Pending"

                        }

                        );
                    context.SaveChanges();
                }

                if (!context.Exams.Any())
                {
                    var userGherman = context.Users.FirstOrDefault(u => u.Email == "ovidiug@eed.usv.ro");
                    var userPrelipceanu = context.Users.FirstOrDefault(u => u.Email == "marius.prelipceanu@usm.ro");
                    var userBeguni = context.Users.FirstOrDefault(u => u.Email == "catalin.beguni@usm.ro");
                    var userPohoata = context.Users.FirstOrDefault(u => u.Email == "sorinp@eed.usv.ro");

                    var sub1 = context.Subjects.FirstOrDefault(u => u.SubjectName == "Proiectarea Translatoarelor");
                    var sub2 = context.Subjects.FirstOrDefault(u => u.SubjectName == "Metode Numerice");


                    var loc1 = context.Locations.FirstOrDefault(u => u.LocationName == "C201");
                    var loc2 = context.Locations.FirstOrDefault(l => l.LocationName == "C301");
                    var loc3 = context.Locations.FirstOrDefault(u => u.LocationName == "C202");
                    context.Exams.AddRange(
                        new Exam
                        {
                            Group = 3141,
                            SubjectID = (int)sub1.SubjectID,
                            ProfessorID = (int)userGherman.UserID,
                            AssistantID = (int)userBeguni.UserID,
                            Date = DateOnly.Parse("2025-03-20"),
                            Start_Time = "12:00PM",
                            LocationID = (int)loc1.LocationID
                        },
                        new Exam
                        {
                            Group = 3141,
                            SubjectID = (int)sub2.SubjectID,
                            ProfessorID = (int)userPrelipceanu.UserID,
                            AssistantID = (int)userPohoata.UserID,
                            Date = DateOnly.Parse("2025-03-22"),
                            Start_Time = "16:00PM",
                            LocationID = (int)loc2.LocationID
                        },
                        new Exam
                        {
                            Group = 3143,
                            SubjectID = (int)sub1.SubjectID,
                            ProfessorID = (int)userGherman.UserID,
                            AssistantID = (int)userBeguni.UserID,
                            Date = DateOnly.Parse("2025-03-15"),
                            Start_Time = "8:00AM",
                            LocationID = (int)loc3.LocationID
                        }
                        );

                    context.SaveChanges();
                }

            }
        }
    }
}
