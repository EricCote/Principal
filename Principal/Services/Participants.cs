using Principal.Models;

namespace Principal.Services
{
    public class Participants :  IParticipants
    {
        public List<Participant> Liste { get; set; } = new List<Participant>()
        {
            new Participant() { ParticipantID = 1,Prenom = "jf", Nom = "Lessard", Province = "Qc",Courriel = "JF@nter.com"},
            new Participant() { ParticipantID = 2,Prenom = "Stéphane", Nom = "Laforce",Province = "Qc",Courriel = "stephane@nter.com" }
        };


    }


}
