using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Application;
public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options){

    }
    public DbSet<Tareas> Tareas { get; set; }
}