using Backend_Dev_Encapsulatie_Polymorfisme.Models.Personen;

namespace Backend_Dev_Encapsulatie_Polymorfisme.Models.BankRekeningen
{
    public class Bankrekening
    {
        public string Rekeningnummer;
        public Persoon Rekeninghouder;

        protected decimal Saldo;

        public bool Geblokkeerd;

        public List<Transactie> Historie = new();

        public Bankrekening(
        string rekeningnummer,
        Persoon rekeninghouder)
        {
            Rekeningnummer = rekeningnummer;
            Rekeninghouder = rekeninghouder;
        }

        public void Storten(decimal bedrag)
        {
            if (Geblokkeerd)
            {
                return;
            }

            if (bedrag > 0)
            {
                Saldo += bedrag;

                Historie.Add(
                new Transactie(
                DateTime.Now,
                bedrag,
                "Storting"));
            }
        }

        public virtual bool Opnemen(decimal bedrag)
        {
            if (Geblokkeerd)
            {
                return false;
            }

            if (bedrag > 0 && Saldo >= bedrag)
            {
                Saldo -= bedrag;

                Historie.Add(
                new Transactie(
                DateTime.Now,
                -bedrag,
                "Opname"));

                return true;
            }

            return false;
        }

        public decimal ToonSaldo()
        {
            return Saldo;
        }

        public bool OverschrijvenNaar(
        Bankrekening ontvanger,
        decimal bedrag)
        {
            if (Opnemen(bedrag))
            {
                ontvanger.Storten(bedrag);

                Historie.Add(
                new Transactie(
                DateTime.Now,
                -bedrag,
                $"Overboeking naar {ontvanger.Rekeningnummer}"));

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{ToonType()} - {Rekeningnummer} - {Rekeninghouder}";
        }

        public virtual string ToonType()
        {
            return this.GetType().Name;
        }
    }

}
