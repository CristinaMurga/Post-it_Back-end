using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Posti_it_web.Repository.Models;

namespace Posti_it_web.Repository;

public partial class PostItDbContext : DbContext
{
    public PostItDbContext()
    {
    }

    public PostItDbContext(DbContextOptions<PostItDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PostIt> PostIts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostIt>(entity =>
        {
            entity.Property(e => e.Color).IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.PasswordSalt).IsFixedLength();
            entity.Property(e => e.PasswordHash).IsFixedLength();
            entity.Property(e => e.Username).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<Posti_it_web.Repository.Models.Color> Color { get; set; } = default!;
}
