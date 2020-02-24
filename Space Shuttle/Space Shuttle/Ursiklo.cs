using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shuttle
{
    class Ursiklo
    {
        public string KulddetesKodja;
        public DateTime KilovesDatum;
        public string UrsikloNeve;
        public int NapokSzáma;
        public int OrakSzama;
        public string KuldetesVegHelyszin;
        public int Legenyseg;

        public Ursiklo (string sor)
        {
            var dbok = sor.Split(';');
            this.KulddetesKodja= dbok[0];
            this.KilovesDatum=DateTime.Parse(dbok[1]);
            this.UrsikloNeve=dbok[2];
            this.NapokSzáma=int.Parse(dbok[3]);
            this.OrakSzama= int.Parse(dbok[4]);
            this.KuldetesVegHelyszin = dbok[5];
            this.Legenyseg = int.Parse(dbok[6]);
        }

    }
}
