namespace Solving_Select_Everything_Problem
{
    using System.Data.Entity;

    public partial class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext()
            : base("name=SoftUni")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ManagedEmployees)
                .WithOptional(e => e.Manager)
                .HasForeignKey(e => e.ManagerID);
        }
    }
}
