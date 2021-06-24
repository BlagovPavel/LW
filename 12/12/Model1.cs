namespace _12
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Works_on> Works_on { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.DepartamentNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Works_on)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.EmpId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Works_on>()
                .Property(e => e.ProjectNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Works_on>()
                .Property(e => e.Job)
                .IsFixedLength();
        }
    }
}
