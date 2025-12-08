using Microsoft.EntityFrameworkCore;
using CounselFlow.Domain.Entities;

namespace CounselFlow.Infrastructure;

public class AppDbContext : DbContext  // DbContext 상속
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Agent> Agents { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Consult> Consults { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<ConsultTag> ConsultTags { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // agent
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.ToTable("agent"); // 테이블 이름 지정
            entity.HasKey(a => a.AgentId); // 기본키 지정

            entity.Property(a => a.AgentId).HasColumnName("agentId"); // 컬럼 매핑
            entity.Property(a => a.Password).IsRequired(); // not null
            entity.Property(a => a.Name).IsRequired();
            entity.Property(a => a.Team).IsRequired();
            entity.Property(a => a.Region).IsRequired();
            entity.Property(a => a.Role).IsRequired();
            entity.Property(a => a.ActiveYn).IsRequired();
            entity.Property(a => a.CrdDate);
            entity.Property(a => a.UpdDate);
        });

        // customer
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");
            entity.HasKey(c => c.CustomerId);

            entity.Property(c => c.CustomerId).HasColumnName("customerId");
            entity.Property(c => c.Name).IsRequired();
            entity.Property(c => c.Phone).IsRequired();
        });

        // consult
        modelBuilder.Entity<Consult>(entity =>
        {
            entity.ToTable("consult");
            entity.HasKey(c => c.ConsultId);

            entity.Property(c => c.ConsultId).HasColumnName("consultId");
            entity.Property(c => c.AgentId).IsRequired();
            entity.Property(c => c.CustomerId).IsRequired();
            entity.Property(c => c.Status).IsRequired();
            entity.Property(c => c.Title).IsRequired();
            entity.Property(c => c.Summary).IsRequired();

            entity.HasOne(c => c.Agent) // 1 대
                  .WithMany(a => a.Consults) // N
                  .HasForeignKey(c => c.AgentId); // 외래키 설정

            entity.HasOne(c => c.Customer)
                  .WithMany(cu => cu.Consults)
                  .HasForeignKey(c => c.CustomerId);
        });

        // tag
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("tag");
            entity.HasKey(t => t.TagId);

            entity.Property(t => t.TagId).HasColumnName("tagId");
            entity.Property(t => t.Name).IsRequired();
        });

        // consultTag
        modelBuilder.Entity<ConsultTag>(entity =>
        {
            entity.ToTable("consultTag");
            entity.HasKey(ct => new { ct.ConsultId, ct.TagId }); // 복합키

            entity.Property(ct => ct.ConsultId).HasColumnName("consultId");
            entity.Property(ct => ct.TagId).HasColumnName("tagId");

            entity.HasOne(ct => ct.Consult)
                  .WithMany(c => c.ConsultTags)
                  .HasForeignKey(ct => ct.ConsultId);

            entity.HasOne(ct => ct.Tag)
                  .WithMany(t => t.ConsultTags)
                  .HasForeignKey(ct => ct.TagId);
        });
    }
}
