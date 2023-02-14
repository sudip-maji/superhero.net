using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Superhero.Models;

public partial class SudipContext : DbContext
{
    public SudipContext()
    {
    }

    public SudipContext(DbContextOptions<SudipContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<New> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-R5BEUBA\\SQLEXPRESS;Database=SUDIP;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentCode).HasName("PK__AGENTS__843A8BBA175889ED");

            entity.ToTable("AGENTS");

            entity.Property(e => e.AgentCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGENT_CODE");
            entity.Property(e => e.AgentName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGENT_NAME");
            entity.Property(e => e.Commission).HasColumnName("COMMISSION");
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONE_NO");
            entity.Property(e => e.WorkingArea)
                .HasMaxLength(35)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("WORKING_AREA");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustCode).HasName("PK__CUSTOMER__8393C4A1A5E13920");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CUST_CODE");
            entity.Property(e => e.AgentCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGENT_CODE");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.CustCity)
                .HasMaxLength(35)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CUST_CITY");
            entity.Property(e => e.CustName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CUST_NAME");
            entity.Property(e => e.Grade)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("GRADE");
            entity.Property(e => e.OpeningAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("OPENING_AMT");
            entity.Property(e => e.OutstandingAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("OUTSTANDING_AMT");
            entity.Property(e => e.PaymentAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("PAYMENT_AMT");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("PHONE_NO");
            entity.Property(e => e.ReceiveAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("RECEIVE_AMT");
            entity.Property(e => e.WorkingArea)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("WORKING_AREA");

            entity.HasOne(d => d.AgentCodeNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AgentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CUSTOMER__AGENT___71D1E811");
        });

        modelBuilder.Entity<New>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("new");

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("amount");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdNum).HasName("PK__ORDERS__27AB607C45065A09");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrdNum)
                .HasColumnType("decimal(6, 0)")
                .HasColumnName("ORD_NUM");
            entity.Property(e => e.AdvanceAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("ADVANCE_AMOUNT");
            entity.Property(e => e.AgentCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGENT_CODE");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.CustCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CUST_CODE");
            entity.Property(e => e.OrdDate)
                .HasColumnType("date")
                .HasColumnName("ORD_DATE");
            entity.Property(e => e.OrdDescription)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ORD_DESCRIPTION");

            entity.HasOne(d => d.AgentCodeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AgentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS__AGENT_CO__797309D9");

            entity.HasOne(d => d.CustCodeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS__CUST_COD__787EE5A0");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("students");

            entity.Property(e => e.Branch)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("branch");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StuId).HasColumnName("stu_id");
            entity.Property(e => e.StuRoll).HasColumnName("stu_roll");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
