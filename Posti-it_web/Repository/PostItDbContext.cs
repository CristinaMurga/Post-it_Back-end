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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=Post-it_Web;Integrated Security=True;Trust Server Certificate=True");

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
}
