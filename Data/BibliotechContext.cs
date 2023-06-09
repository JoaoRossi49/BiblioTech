using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BiblioTech.Models;

namespace BiblioTech.Data;

public partial class BibliotechContext : DbContext
{
    public BibliotechContext()
    {
    }

    public BibliotechContext(DbContextOptions<BibliotechContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=bibliotech;Uid=root;Pwd=Saymyname002!;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<BiblioTech.Models.Livro> Livro { get; set; } = default!;

    public DbSet<BiblioTech.Models.Autor> Autor { get; set; } = default!;

    public DbSet<BiblioTech.Models.Genero> Genero { get; set; } = default!;
}
