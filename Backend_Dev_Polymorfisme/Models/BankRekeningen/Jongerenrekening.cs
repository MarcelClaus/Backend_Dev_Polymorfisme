using Backend_Dev_Encapsulatie_Polymorfisme.Models.Personen;

namespace Backend_Dev_Encapsulatie_Polymorfisme.Models.BankRekeningen
{
    public class Jongerenrekening : Bankrekening
    {
        public decimal MaxOpnameBedrag = 50;

        public Jongerenrekening(
        string rekeningnummer,
        Persoon rekeninghouder)
        : base(rekeningnummer, rekeninghouder)
        {
        }

        public override bool Opnemen(decimal bedrag)
        {
            if (bedrag > MaxOpnameBedrag)
            {
                Console.WriteLine(
                    $"Opname geweigerd: op een jongerenrekening mag maximaal €{MaxOpnameBedrag} per keer worden opgenomen.");

                return false;
            }

            return base.Opnemen(bedrag);
        }
    }
}
