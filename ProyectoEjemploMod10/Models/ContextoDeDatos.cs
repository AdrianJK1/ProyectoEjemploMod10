using Microsoft.EntityFrameworkCore;

namespace ProyectoEjemploMod10.Models
{
    public class ContextoDeDatos : DbContext
    {

        public ContextoDeDatos(DbContextOptions opciones) : base(opciones)
            {
            }
        public DbSet<Departamento> Departamentos { get; set; }

    }

}
