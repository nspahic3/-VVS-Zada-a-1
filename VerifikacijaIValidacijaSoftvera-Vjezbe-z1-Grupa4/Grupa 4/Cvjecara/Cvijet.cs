﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Cvijet
    {
        // vrsta
        Vrsta vrsta;
        // imena
        string latinskoIme, boja;
        /* datum */
        DateTime datumBranja;
        /* sezona */
        bool sezonsko;
        int količina;



        public Vrsta Vrsta { get => vrsta; set => vrsta = value; }
        public string LatinskoIme 
        { 
            get => latinskoIme; 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new FormatException("Latinsko ime ne može biti prazan string!");
                latinskoIme = value;
                
            }
        }
        public string Boja 
        { 
            get => boja;
            set
            {
                List<string> boje = new List<string>()
                { "Žuta", "Crvena", "Bijela", "Roza", "Narandžasta" };

                if (!boje.Contains(value))
                    throw new FormatException("Unijeli ste nepostojeću boju!");
                boja = value;
            }
        }
        public DateTime DatumBranja 
        { 
            get => datumBranja;
            set
            {
                if (value > DateTime.Now)
                    throw new FormatException("Datum branja ne može biti u budućnosti!");
                datumBranja = value;
            }
        }
        public bool Sezonsko { get => sezonsko; set => sezonsko = value; }
        public int Kolicina { get => količina; set => količina = value; }


        public Cvijet(Vrsta vrsta, string ime, string boja, DateTime datumBranja, int kol)
        {
            Vrsta = vrsta;
            LatinskoIme = boja;
            Boja = boja;
            DatumBranja = datumBranja;
            List<string> sezonskeVrste = new List<string>()
            { "Neven", "Margareta", "Ljiljan" };
            Sezonsko = sezonskeVrste.Contains(vrsta.ToString());
            Kolicina = kol;
        }



        public void NekaMetoda()
        {
            if (!sezonsko)
                return;

            int pocetakMjesec = 3,
                krajMjesec = 9;

            int mjesec = DateTime.Now.Month;

            if (mjesec < pocetakMjesec || mjesec > krajMjesec || mjesec == pocetakMjesec || mjesec == krajMjesec)
                količina = 0;
        }

        public double OdrediSvježinuCvijeća()
        {
            return (DateTime.Now - datumBranja).TotalDays / 30;
        }

    }
}