namespace Principal.Services
{
    public interface ICompteur
    {
        int Total { get; set; }

        int Visite();
    }
}