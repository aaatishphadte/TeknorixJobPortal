using TeknorixAPI.Data;
using TeknorixAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Megalon
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DataContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                           if (!appContext.Jobs.Any())
                        {
                            SeedData(appContext);
                        }
                    
                            //appContext.Database.Migrate();
                        
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return webApp;
        }
        public static void SeedData(DataContext context)
        {
            var department1 = new Department()
            {
              //  DepartmentID = 201,
                Title = "Project Management"
                //Description = "Smith",
                //DOB =Convert.ToDateTime("1/1/1987 00:00:00")
            };

            var department2 = new Department()
            {
              //  DepartmentID = 2085,
                Title = "Software Development",
                //LastName = "Smith",
                //DOB = Convert.ToDateTime("12/12/1986 00:00:00")
            };

            var location1 =
               new Location()
               {
                  // OrderID = 1,
              //    LocationID = 10030,
                   Title = "US Head Office",
                   City = "Baltimore",
                   State ="MD",
                   Country= "United States",
                   Zip = 21202
                   //// CustomerID = customer1.CustomerID,
                   //Customer = customer1,
               };
            var location2 =
                new Location()
                {
                    // OrderID = 1,
                   // LocationID = 101,
                    Title = "India Office",
                    City = "Verna",
                    State = "Goa",
                    Country = "India",
                    Zip = 403722
                    //// CustomerID = customer1.CustomerID,
                    //Customer = customer1,
                };
            var job1 = new Job()
            {
                Code = Guid.NewGuid(),
                Title = "Software Developer",
                Description = "Job description here...",
                Location = location1,
                Department = department2,
                PostedDate = Convert.ToDateTime("2021-08-30T18:43:31.877Z"),
                ClosedDate = Convert.ToDateTime("2021-08-30T18:43:31.877Z")
                
            };
            var job2 = new Job()
            {
                Code = Guid.NewGuid(),
                Title = "Project Manager",
                Description = "Job description here...",
                Location = location2,
                Department = department1,
                PostedDate = Convert.ToDateTime("2021-07-30T18:43:31.877Z"),
                ClosedDate = Convert.ToDateTime("2021-07-30T18:43:31.877Z")

            };

            // Add the entities to the context
            context.Locations.AddRange(location1, location2);
            context.SaveChanges();
            context.Departments.AddRange(department2, department1);
            context.SaveChanges();
            context.Jobs.AddRange(job1, job2);

            context.SaveChanges();
        }
    }
}
