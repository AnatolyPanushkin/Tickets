using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tickets
{
    public partial class TicketContext : DbContext
    {
        public TicketContext()
        {
        }

        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Segment> Segments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=Localhost;Port=5432;Database=Ticket;Username=postgres;Password=1234");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TicketNumber })
                    .HasName("segments_pkey");

                entity.ToTable("segments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TicketNumber).HasColumnName("ticket_number");

                entity.Property(e => e.ArrivePlace)
                    .IsRequired()
                    .HasColumnName("arrive_place");

                entity.Property(e => e.ArriveTime).HasColumnName("arrive_time");

                entity.Property(e => e.DepartPlace)
                    .IsRequired()
                    .HasColumnName("depart_place");

                entity.Property(e => e.DepartTime).HasColumnName("depart_time");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasColumnName("operation_type");
            });
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
