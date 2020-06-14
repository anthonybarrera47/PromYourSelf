using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Contexto : DbContext
    {
        public DbSet<Citas> Citas { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Etiquetas> Etiquetas { get; set; }
        public DbSet<FotosProductos> FotosProductos { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Mensajes> Mensaje { get; set; }
        public DbSet<Negocios> Negocios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }


        public Contexto(DbContextOptions<Contexto> options)
    : base(options)
        { }
    }
}
