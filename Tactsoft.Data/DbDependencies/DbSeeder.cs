using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Defaults;
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
                    CountryName = "Bangladesh",
                    CountryCode = "BD",
                    CountryCurrency = "BDT",
                    CountryFlag = "bd",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                },
                new Country
                {
                    Id = 2,
                    CountryName = "United States",
                    CountryCode = "USA",
                    CountryCurrency = "USD",
                    CountryFlag = "us",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                },
                new Country
                {
                    Id = 3,
                    CountryName = "United Kingdom",
                    CountryCode = "UK",
                    CountryCurrency = "GBP",
                    CountryFlag = "gb",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                });

            modelBuilder.Entity<State>().HasData(
            new State
            {
                Id = 1,
                CountryId = 1,
                StateName = "Dhaka",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 2,
                CountryId = 1,
                StateName = "Rajshahi",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 3,
                CountryId = 2,
                StateName = "New York",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 4,
                CountryId = 2,
                StateName = "Alabama",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });

            modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                StateId = 1,
                CityName = "Mohammadpur",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 2,
                StateId = 1,
                CityName = "Dhanmondi",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 3,
                StateId = 2,
                CityName = "Nator",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 4,
                StateId = 2,
                CityName = "Sirajganj",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 5,
                StateId = 3,
                CityName = "New York City",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 6,
                StateId = 3,
                CityName = "Buffalo",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 7,
                StateId = 4,
                CityName = "Huntsville",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 8,
                StateId = 4,
                CityName = "Montgomery",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                EmployeeName = "Hasan",
                Gender="Male",
                IdNumber = "IT-2310001",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                DepartmentId = 1,
                EmployeeAddress = "Dhanmondi",
                Picture= "avatar2.png",
                CountryId= 1,
                StateId= 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 2,
                EmployeeName = "Rubel",
                Gender = "Male",
                IdNumber = "HR-2310001",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                EmployeeAddress = "Dhanmondi",
                DepartmentId = 2,
                Picture = "avatar2.png",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 3,
                EmployeeName = "Sobuj",
                Gender = "Male",
                IdNumber = "CS-2310001",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                DepartmentId = 3,
                EmployeeAddress = "Dhanmondi",
                Picture = "avatar5.png",
                CountryId = 2,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 4,
                EmployeeName = "Mamun",
                Gender = "Male",
                IdNumber = "IT-2310002",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                EmployeeAddress = "Dhanmondi",
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
                EmployeeName = "Kalam",
                Gender = "Male",
                IdNumber = "HR-2310002",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                EmployeeAddress = "Dhanmondi",
                DepartmentId = 2,
                Picture = "avatar2.png",
                CountryId = 1,
                StateId = 2,
                CityId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Employee
            {
                Id = 6,
                EmployeeName = "Khurshed",
                Gender = "Male",
                IdNumber = "CS-2310002",
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                Msc = true,
                EmployeeAddress = "Dhanmondi",
                Picture = "avatar5.png",
                DepartmentId = 3,
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
                GenderId= Gender.Male,
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
                StudentName = "Korim",
                StudentEmail = "korim@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Gender.Male,
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
                StudentName = "Sumi",
                StudentEmail = "sumi@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Gender.Female,
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
                StudentName = "Mahabub",
                StudentEmail = "mahabub@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Gender.Male,
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
                StudentName = "Salim",
                StudentEmail = "salim@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Gender.Male,
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
                StudentName = "Kobir",
                StudentEmail = "kobir@gmail.com",
                StudentPhone = "0170000000",
                DateOfBirth = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                Ssc = true,
                Hsc = true,
                Bsc = true,
                GenderId = Gender.Male,
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

            }, new Department
            {
                Id = 2,
                DepartmentName = "HR",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Department
            {
                Id = 3,
                DepartmentName = "CS",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
        }

    }
}
