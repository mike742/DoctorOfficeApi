using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { set; get; }
    public DbSet<Patient> Patients { set; get; }
    public DbSet<IntakeForm> IntakeForms { set; get; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(@"server=localhost;user=root;password=1234;database=DoctorsOffice",
            ServerVersion.Parse("8.0.24-mysql")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = 1,
                Name = "Dr. Jack Smith"
            },
            new Doctor
            {
                Id = 2,
                Name = "Dr. Adam West"
            },
            new Doctor
            {
                Id = 3,
                Name = "Dr. Rachel Green"
            }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = 1,
                HealthNumber = 12301,
                Name = "Patient Mark",
                Address = "123, Main St., Winnipeg",
                DateOfBirth = new DateTime(1997, 07, 12),
                PhoneNumber = "204 123-4567"
            }
        );
    }
}