using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.DbDependencies
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Bangladesh",
                    Code = "BD",
                    Currency = "BDT",
                    Flag = "bd",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                },
                new Country
                {
                    Id = 2,
                    Name = "United States",
                    Code = "USA",
                    Currency = "USD",
                    Flag = "us",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                },
                new Country
                {
                    Id = 3,
                    Name = "United Kingdom",
                    Code = "UK",
                    Currency = "GBP",
                    Flag = "gb",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                });

            modelBuilder.Entity<State>().HasData(
            new State
            {
                Id = 1,
                CountryId = 1,
                Name = "Dhaka",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 2,
                CountryId = 1,
                Name = "Rajshahi",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 3,
                CountryId = 2,
                Name = "New York",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 4,
                CountryId = 2,
                Name = "Alabama",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });

            modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                StateId = 1,
                Name = "Mohammadpur",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 2,
                StateId = 1,
                Name = "Dhanmondi",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 3,
                StateId = 2,
                Name = "Nator",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 4,
                StateId = 2,
                Name = "Sirajganj",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 5,
                StateId = 3,
                Name = "New York City",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 6,
                StateId = 3,
                Name = "Buffalo",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 7,
                StateId = 4,
                Name = "Huntsville",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 8,
                StateId = 4,
                Name = "Montgomery",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "Hasan",
                Gender="Male",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                DepartmentId = 1,
                Address = "Dhanmondi",
                Picture= "avatar2.png",
                CountryId= 1,
                StateId= 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 2,
                Name = "Rubel",
                Gender = "Male",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                Address = "Dhanmondi",
                DepartmentId = 1,
                Picture = "avatar2.png",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 3,
                Name = "Sobuj",
                Gender = "Male",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                DepartmentId = 1,
                Address = "Dhanmondi",
                Picture = "avatar5.png",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 4,
                Name = "Mamun",
                Gender = "Male",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                Address = "Dhanmondi",
                DepartmentId = 1,
                Picture = "avatar4.png",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 5,
                Name = "Kalam",
                Gender = "Male",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                Address = "Dhanmondi",
                DepartmentId = 1,
                Picture = "avatar2.png",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 6,
                Name = "Khurshed",
                Gender = "Male",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                Address = "Dhanmondi",
                Picture = "avatar5.png",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });

            modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                StudentName="Rahman",
                StudentEmail="rahman@gmail.com",
                StudentPhone="0170000000",
                DateOfBirth= DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc= true,
                Hsc= true,
                Bsc= true,
                GenderId= Core.Gender.Male,
                Picture = "avatar.png",
                Address ="Mohammadpur",
                CountryId = 1,
                StateId= 2,
                CityId= 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Student
            {
                Id = 2,
                StudentName = "Rahman",
                StudentEmail = "rahman@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Core.Gender.Male,
                Picture = "avatar4.png",
                Address = "Mohammadpur",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Student
            {
                Id = 3,
                StudentName = "Rahman",
                StudentEmail = "rahman@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Core.Gender.Male,
                Picture = "avatar5.png",
                Address = "Mohammadpur",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Student
            {
                Id = 4,
                StudentName = "Rahman",
                StudentEmail = "rahman@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Core.Gender.Male,
                Picture = "avatar.png",
                Address = "Mohammadpur",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Student
            {
                Id = 5,
                StudentName = "Rahman",
                StudentEmail = "rahman@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Core.Gender.Male,
                Picture = "avatar4.png",
                Address = "Mohammadpur",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Student
            {
                Id = 6,
                StudentName = "Rahman",
                StudentEmail = "rahman@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Core.Gender.Male,
                Picture = "avatar4.png",
                Address = "Mohammadpur",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                DepartmentName = "IT",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
        }

    }
}
