using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Poklon
    {
        #region Atributi

        string popustKod, opis;
        double postotakPopusta;
        int brojač = -50050505;

        #endregion

        #region Properties

        public string Šifra { get => popustKod; }
        public string Opis { get => opis; set => opis = value; }
        public double PostotakPopusta { get => postotakPopusta; }

        #endregion

        #region ????

        public Poklon(string opis, double postotak)
        {
            popustKod = brojač.ToString();
            brojač++;
            Opis = opis;
            postotakPopusta = postotak;
        }

        #endregion
    }
}
