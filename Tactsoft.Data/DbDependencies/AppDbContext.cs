using Tactsoft.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using Tactsoft.Service.DbDependencies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tactsoft.Core.Entities.Identity;

namespace Tactsoft.Data.DbDependencies
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        #region Properties
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<Attendence> Attendences { get; set; }
        public DbSet<AllowanceDeduction> AllowanceDeductions { get; set; }

        #endregion



        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.LogTo(message => WriteSqlQueryLog(message));
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        public const string DefaultSchemaName = "dbo";
        public string Schema { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.RelationConvetion();
            builder.DecimalConvention();
            builder.DateTimeConvention();

            builder.Seed();
        }

        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory = new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                //new ConsoleLoggerProvider((_, __) => true, true)
        });

        private void WriteSqlQueryLog(string query, StoreType storeType = StoreType.Output)
        {
            if (storeType == StoreType.Output)
                Debug.WriteLine(query);
            else if (storeType == StoreType.Db)
            {
                // store in db
            }
            else if (storeType == StoreType.File)
            {
                // store & append in file
                //new StreamWriter("mylog.txt", append: true);
            }

            //using (WebAppContext context = new WebAppContext())
            //{
            //    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //}

            //IQueryable queryable = from x in Blogs
            //                       where x.Id == 1
            //                       select x;

            //var sqlEf5 = ((System.Data.Objects.ObjectQuery)queryable).ToTraceString();
            //var sqlEf6 = ((System.Data.Entity.Core.Objects.ObjectQuery)queryable).ToTraceString();
            //var sql = queryable.ToString();

            // https://docs.microsoft.com/en-us/ef/ef6/fundamentals/logging-and-interception?redirectedfrom=MSDN
            // https://stackoverflow.com/questions/1412863/how-do-i-view-the-sql-generated-by-the-entity-framework
        }

        #endregion

        
    }

    public enum StoreType
    {
        Db,
        File,
        Output
    }
}
