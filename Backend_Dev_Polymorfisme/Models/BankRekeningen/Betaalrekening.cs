using Backend_Dev_Encapsulatie_Polymorfisme.Models.Personen;

namespace Backend_Dev_Encapsulatie_Polymorfisme.Models.BankRekeningen
{
    public class Betaalrekening : Bankrekening
    {
        public decimal Krediet = -1000;

        public Betaalrekening(
        string rekeningnummer,
        Persoon rekeninghouder)
        : base(rekeningnummer, rekeninghouder)
        {
        }

        public override bool Opnemen(decimal bedrag)
        {
            if (Geblokkeerd)
            {
                return false;
            }

            if (bedrag > 0 &&
            (Saldo - bedrag) >= Krediet)
            {
                Saldo -= bedrag;

                Historie.Add(
                new Transactie(
                DateTime.Now,
                -bedrag,
                "Opname betaalrekening"));

                return true;
            }

            return false;
        }
    }
}
