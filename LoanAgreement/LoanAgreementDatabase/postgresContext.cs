using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LoanAgreementDatabase.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanAgreementDatabase
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Chartofaccounts> Chartofaccounts { get; set; }
        public virtual DbSet<Counterpartylender> Counterpartylender { get; set; }
        public virtual DbSet<Loanagreement> Loanagreement { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<Postingjournal> Postingjournal { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=Ivan;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("agent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("fio")
                    .HasMaxLength(255);

                entity.Property(e => e.Post)
                    .IsRequired()
                    .HasColumnName("post")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Chartofaccounts>(entity =>
            {
                entity.ToTable("chartofaccounts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accountname)
                    .IsRequired()
                    .HasColumnName("accountname")
                    .HasMaxLength(255);

                entity.Property(e => e.Accountnumber).HasColumnName("accountnumber");

                entity.Property(e => e.Subconto1)
                    .HasColumnName("subconto1")
                    .HasMaxLength(255);

                entity.Property(e => e.Subconto2)
                    .HasColumnName("subconto2")
                    .HasMaxLength(255);

                entity.Property(e => e.Subconto3)
                    .HasColumnName("subconto3")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Counterpartylender>(entity =>
            {
                entity.ToTable("counterpartylender");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("fio")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Loanagreement>(entity =>
            {
                entity.ToTable("loanagreement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Agentid).HasColumnName("agentid");

                entity.Property(e => e.Counterpartylenderid).HasColumnName("counterpartylenderid");

                entity.Property(e => e.Dateofconclusion)
                    .HasColumnName("dateofconclusion")
                    .HasColumnType("date");

                entity.Property(e => e.Dateofmaturity)
                    .HasColumnName("dateofmaturity")
                    .HasColumnType("date");

                entity.Property(e => e.Percent1)
                    .HasColumnName("percent1")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.Percent2)
                    .HasColumnName("percent2")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.Remainingsumofloan)
                    .HasColumnName("remainingsumofloan")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.Sumofloan)
                    .HasColumnName("sumofloan")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Loanagreement)
                    .HasForeignKey(d => d.Agentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agent_fkey");

                entity.HasOne(d => d.Counterpartylender)
                    .WithMany(p => p.Loanagreement)
                    .HasForeignKey(d => d.Counterpartylenderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("counterpartylender_fkey");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("operation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateofoperation)
                    .HasColumnName("dateofoperation")
                    .HasColumnType("date");

                entity.Property(e => e.Loanagreementid).HasColumnName("loanagreementid");

                entity.Property(e => e.Operationtype)
                    .IsRequired()
                    .HasColumnName("operationtype")
                    .HasMaxLength(255);

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.Loanagreement)
                    .WithMany(p => p.Operation)
                    .HasForeignKey(d => d.Loanagreementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loanagreement_fkey");
            });

            modelBuilder.Entity<Postingjournal>(entity =>
            {
                entity.ToTable("postingjournal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255);

                entity.Property(e => e.Creditaccount).HasColumnName("creditaccount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Debitaccount).HasColumnName("debitaccount");

                entity.Property(e => e.Operationid).HasColumnName("operationid");

                entity.Property(e => e.Subcontocredit1)
                    .HasColumnName("subcontocredit1")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcontocredit2)
                    .HasColumnName("subcontocredit2")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcontocredit3)
                    .HasColumnName("subcontocredit3")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcontodebit1)
                    .HasColumnName("subcontodebit1")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcontodebit2)
                    .HasColumnName("subcontodebit2")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcontodebit3)
                    .HasColumnName("subcontodebit3")
                    .HasMaxLength(255);

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.CreditaccountNavigation)
                    .WithMany(p => p.PostingjournalCreditaccountNavigation)
                    .HasForeignKey(d => d.Creditaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("creditaccount_fkey");

                entity.HasOne(d => d.DebitaccountNavigation)
                    .WithMany(p => p.PostingjournalDebitaccountNavigation)
                    .HasForeignKey(d => d.Debitaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("debitaccount_fkey");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Postingjournal)
                    .HasForeignKey(d => d.Operationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("operation_fkey");
            });

            modelBuilder.HasSequence("applicantseq");

            modelBuilder.HasSequence("dealseq");

            modelBuilder.HasSequence("educationseq");

            modelBuilder.HasSequence("employerseq");

            modelBuilder.HasSequence("exchangeemployeeseq");

            modelBuilder.HasSequence("userseq");

            modelBuilder.HasSequence("vacancyseq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
