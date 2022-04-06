namespace Principal.Services
{
    public class Compteur : ICompteur
    {
        public int Total { get; set; } = 0;

        public int Visite()
        {
            Total += 1;
            return Total;
        }

    }
}
