using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Real_Time_Chat_Application_Backend.Database;

public partial class AccountDbContext : DbContext
{
    public AccountDbContext()
    {
    }

    public AccountDbContext(DbContextOptions<AccountDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-CNVSH31R\\SQLEXPRESS01;Database=Chat_ApplicationDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_userRegistaration");

            entity.ToTable("userRegistration");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Nickname).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
