using iPractice.DataAccess.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace iPractice.DataAccess.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PsychologistEntity> Psychologists { get; set; }
        public DbSet<PsychologistAvailabilityEntity> PsychologistAvailabilities { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ClientBookedTimeSlotEntity> ClientsBookedTimeSlots { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PsychologistEntity>().HasKey(psychologist => psychologist.Id);
            modelBuilder.Entity<ClientEntity>().HasKey(client => client.Id);
            modelBuilder.Entity<PsychologistEntity>().HasMany(p => p.Clients).WithMany(b => b.Psychologists);
            modelBuilder.Entity<ClientEntity>().HasMany(p => p.Psychologists).WithMany(b => b.Clients);
            modelBuilder.Entity<PsychologistAvailabilityEntity>().HasOne(p => p.Psychologist);
            modelBuilder.Entity<ClientBookedTimeSlotEntity>().HasOne(p => p.Client);
        }
    }
}
