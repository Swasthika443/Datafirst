using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DFA_KT.Models;

public partial class CoreMvcContext : DbContext
{
    public CoreMvcContext()
    {
    }

    public CoreMvcContext(DbContextOptions<CoreMvcContext> options)
        : base(options)
    {
    }

    

    public virtual DbSet<Trainee> Trainees { get; set; }

   //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
   //    => optionsBuilder.UseSqlServer("Server=ELW5339;Database=CoreMvc;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK_Trainee");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
