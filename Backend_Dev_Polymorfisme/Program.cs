using Backend_Dev_Encapsulatie_Polymorfisme.Models.BankRekeningen;
using Backend_Dev_Encapsulatie_Polymorfisme.Models.Personen;

namespace Backend_Dev_Encapsulatie_Polymorfisme
{
    internal class Program
    {
        static void ToonAlleRekeningen(Klant klant)
        {
            Console.WriteLine();
            Console.WriteLine("OVERZICHT REKENINGEN");

            foreach (Bankrekening rekening in klant.Rekeningen)
            {
                Console.WriteLine(
                    $"{rekening} | Saldo: {rekening.ToonSaldo():N2} €");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Klant jan = new Klant("Jan", "Jansen");

            Betaalrekening betaal =
                new Betaalrekening("NL01-BETAAL", jan);

            Spaarrekening spaar =
                new Spaarrekening("NL02-SPAAR", jan);

            Jongerenrekening jongeren =
                new Jongerenrekening("NL03-JONGEREN", jan);

            jan.Rekeningen.Add(betaal);
            jan.Rekeningen.Add(spaar);
            jan.Rekeningen.Add(jongeren);

            Console.WriteLine("=== GELD STORTEN ===");

            Console.WriteLine("€ 100 storten op betaalrekening...");
            betaal.Storten(100);

            Console.WriteLine("€ 500 storten op spaarrekening...");
            spaar.Storten(500);

            Console.WriteLine("€ 75 storten op jongerenrekening...");
            jongeren.Storten(75);

            ToonAlleRekeningen(jan);

            Console.WriteLine();
            Console.WriteLine("=== OPNAME VANAF BETAALREKENING ===");

            bool gelukt = betaal.Opnemen(500);

            Console.WriteLine(
                gelukt
                    ? "Opname van €500 gelukt."
                    : "Opname van €500 mislukt.");

            ToonAlleRekeningen(jan);

            Console.WriteLine();
            Console.WriteLine("=== POLYMORFISME ===");

            foreach (Bankrekening rekening in jan.Rekeningen)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Probeer €100 op te nemen van {rekening}");

                bool opnameGelukt = rekening.Opnemen(100);

                Console.WriteLine(
                    opnameGelukt
                        ? "Opname geslaagd."
                        : "Opname mislukt.");

                Console.WriteLine(
                    $"Nieuw saldo: {rekening.ToonSaldo():N2} €");
            }
        }
    }

}