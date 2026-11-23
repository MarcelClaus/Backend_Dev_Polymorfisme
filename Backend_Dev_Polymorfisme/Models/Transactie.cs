namespace Backend_Dev_Encapsulatie_Polymorfisme.Models
{
    public class Transactie
    {
        public DateTime Datum;
        public decimal Bedrag;
        public string Omschrijving;

        public Transactie(
        DateTime datum,
        decimal bedrag,
        string omschrijving)
        {
            Datum = datum;
            Bedrag = bedrag;
            Omschrijving = omschrijving;
        }
    }
}
