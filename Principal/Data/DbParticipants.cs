using Microsoft.EntityFrameworkCore;
using Principal.Models;

namespace Principal.Data
{
    public class DbParticipants : DbContext
    {
        public DbParticipants(DbContextOptions<DbParticipants> options) : base(options)
        {
            //reconfigurer le connection string au besoin
        }


        //pour gérer le problème des types nulls en C# moderne
        public DbSet<Participant> Participants => Set<Participant>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>().HasData(
                 new Participant() { ParticipantID = 1, Prenom = "jf", Nom = "Lessard", Province = "Qc", Courriel = "JF@nter.com" },
                 new Participant() { ParticipantID = 2, Prenom = "Stéphane", Nom = "Laforce", Province = "Qc", Courriel = "stephane@nter.com" }
             );
        }

    }
}
