using Microsoft.EntityFrameworkCore;
using StaffManagement1.Models;

namespace StaffManagement1.DataAccess;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {

    }
    public DbSet<Staff> Staffs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Staff>().HasData
                (
                new Staff() { Id = 1, FirstName = "Ro'zimurod", LastName = "Abdunazarov", Email = "Ruzimurodabdunazarov@mail.ru", Department = Departments.Administrator },
                new Staff() { Id = 2, FirstName = "Bob", LastName = "Struard", Email = "Bob_tristand@mail.ru", Department = Departments.Production },
                new Staff() { Id = 3, FirstName = "Shoxob", LastName = "Choriyev", Email = "Choriyev2006@mail.ru", Department = Departments.RnD },
                new Staff() { Id = 4, FirstName = "Nigina", LastName = "Shomurodova", Email = "Niginochka@mail.ru", Department = Departments.Operator }
                );
    }
}

