using Backend_Dev_Encapsulatie_Polymorfisme.Models.BankRekeningen;

namespace Backend_Dev_Encapsulatie_Polymorfisme.Models.Personen
{
    public class Klant : Persoon
    {
        public List<Bankrekening> Rekeningen = new();

        public Klant(string voornaam, string achternaam)
        : base(voornaam, achternaam)
        {
        }
    }
}
