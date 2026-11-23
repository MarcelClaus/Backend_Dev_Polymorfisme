using Backend_Dev_Encapsulatie_Polymorfisme.Models.Personen;

namespace Backend_Dev_Encapsulatie_Polymorfisme.Models.BankRekeningen
{
    public class Spaarrekening : Bankrekening
    {
        public decimal RentePercentage = 2.5m;

        public Spaarrekening(
        string rekeningnummer,
        Persoon rekeninghouder)
        : base(rekeningnummer, rekeninghouder)
        {
        }

        public void VoegRenteToe()
        {
            decimal rente =
            Saldo * (RentePercentage / 100);

            Saldo += rente;

            Historie.Add(
            new Transactie(
            DateTime.Now,
            rente,
            "Rentebijschrijving"));
        }
    }
}
