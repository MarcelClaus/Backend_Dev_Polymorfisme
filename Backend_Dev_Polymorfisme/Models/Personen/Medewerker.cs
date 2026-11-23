using Backend_Dev_Encapsulatie_Polymorfisme.Models.BankRekeningen;

namespace Backend_Dev_Encapsulatie_Polymorfisme.Models.Personen
{
    public class Medewerker : Persoon
    {
        public Medewerker(string voornaam, string achternaam)
        : base(voornaam, achternaam)
        {
        }

        public Betaalrekening OpenRekening(
        Klant klant,
        string rekeningnummer)
        {
            Betaalrekening rekening =
            new Betaalrekening(rekeningnummer, klant);

            klant.Rekeningen.Add(rekening);

            return rekening;
        }

        public void BlokkeerRekening(
        Bankrekening rekening)
        {
            rekening.Geblokkeerd = true;
        }

        public bool VerhoogKrediet(
        Betaalrekening rekening,
        decimal nieuwKrediet)
        {
            if (nieuwKrediet > 0)
            {
                rekening.Krediet = -nieuwKrediet;
                return true;
            }

            return false;
        }

        public List<Transactie> ToonHistorie(
        Bankrekening rekening)
        {
            return rekening.Historie;
        }

        public bool SluitRekening(
        Klant klant,
        Bankrekening rekening)
        {
            return klant.Rekeningen.Remove(rekening);
        }
    }
}
