using System;
using System.Collections.Generic;
using System.Text;

namespace Backend_Dev_Encapsulatie_Polymorfisme.Models.Personen
{
    public class Persoon
    {
        public string Voornaam;
        public string Achternaam;

        public Persoon(string voornaam, string achternaam)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
        }

        public override string ToString()
        {
            return $"{Voornaam} {Achternaam}";
        }
    }
}
