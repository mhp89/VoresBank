using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uge47BankCustumer
{
    class KreditKort
    {
        private int kortNr;
        private int kontoNr;
        private int pinKodeHash;
        public bool stjaalet = false;
        public KreditKort(int kortNr, Random rnd, int kontoNr)
        {
            this.kortNr = kortNr;
            GenererPinKode(rnd);
            this.kontoNr = kontoNr;
        }

        public int KortNr
        {
            get
            {
                return kortNr;
            }
        }

        public int PinKodeHash
        {
            get
            {
                return pinKodeHash;
            }
        }
        public int KontoNr
        {
            get
            {
                return kontoNr;
            }
        }
        public void GenererPinKode(Random rnd)
        {
            pinKodeHash = rnd.Next(1000, 9999);
        }
        public override string ToString()
        {
            return "Kortnr: " + kortNr + " Pinkode: " + pinKodeHash;
        }
    }
}
