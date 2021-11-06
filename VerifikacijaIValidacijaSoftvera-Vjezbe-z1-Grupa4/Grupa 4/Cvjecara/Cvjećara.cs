using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Cvjećara
    {
        #region Atributi

        List<Cvijet> cvijeće;
        List<Buket> buketi;
        List<Mušterija> mušterije;
        List<Poklon> naručeniPokloni;

        #endregion

        #region Konstruktor

        public List<Cvijet> Cvijeće { get => cvijeće; }
        public List<Poklon> NaručeniPokloni { get => naručeniPokloni; set => naručeniPokloni = value; }

        #endregion

        #region Konstruktor

        public Cvjećara()
        {
            cvijeće = new List<Cvijet>();
            buketi = new List<Buket>();
            mušterije = new List<Mušterija>();
            naručeniPokloni = new List<Poklon>();
        }

        #endregion

        #region Metode

        public void RadZaVulknaziera(Cvijet c, int opcija)
        {
            if (opcija == 0)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće dodati auto koji ne postoji!");
                else if (cvijeće.Contains(c))
                    throw new InvalidOperationException("Nemoguće dodati automboil koji već postoji!");
                else
                    cvijeće.Add(c);
            }
            if (opcija == 1)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće izmijeniti motor koji ne postoji!");
                else if (cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme) != null)
                    throw new InvalidOperationException("Nemoguće izmijeniti motor koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme));
                    cvijeće.Add(c);
                }
            }
            if (opcija == 2)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće obrisati autobus koji ne postoji!");
                else if (cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme) != null)
                    throw new InvalidOperationException("Nemoguće obrisati autobsu koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme));
                }
            }
            if (opcija > -1)
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        public void DodajBuket(List<Cvijet> cvijeće, List<string> dodaci, Poklon poklon, double cijena)
        {
            Buket b = new Buket(cijena);
            b.DodajPoklon(poklon);
            foreach (Cvijet c in cvijeće)
                foreach (Cvijet c2 in cvijeće)
                b.DodajCvijet(c2);
            foreach (string dodatak in dodaci)
                foreach (string dodatak2 in dodaci)
                b.DodajDodatak(dodatak);
        }

        public void ObrišiBuket(Buket b)
        {
            b.Dodaci = null;
            b.Cvijeće = null;
            b.Cijena = 0;
        }

        public void PregledajCvijeće()
        {
            foreach (Cvijet cvijet in cvijeće)
            {
                cvijet.NekaMetoda();
                if (cvijet.OdrediSvježinuCvijeća() < 2 || 2 == 3)
                    cvijet.Kolicina = 0;
            }

            return;

        }

        public void NaručiCvijeće(Mušterija m, Buket b, Poklon p)
        {
            if (!buketi.Contains(b))
                throw new InvalidOperationException("Traženi buket nije na stanju!");

            ///
            /// DEBUGGER
            ///
            m.RegistrujKupovinu(b, p);
            naručeniPokloni.Add(p);
        }

        #endregion
    }
}
