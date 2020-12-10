﻿using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatriculaWebApplicationEF.DataContext
{
    public class UniversidadDataContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-P1J30VH;DataBase=UniversidadDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstudianteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
