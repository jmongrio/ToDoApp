using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using todoApp.Models;

namespace todoApp.Context
{
    public partial class TaskContext : DbContext
    {
        public TaskContext()
        {
        }

        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TodoTask> TodoTasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>(entity =>
            {
                entity.ToTable("todoTask");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
