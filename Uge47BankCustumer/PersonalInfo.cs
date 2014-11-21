using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uge47BankCustumer
{
    class PersonalInfo
    {
        private string navn;
        private string adresse;
        private string by;
        private int postNr;

        public PersonalInfo(string navn, string adresse, string by, int postNr)
        {
            this.navn = navn;
            this.adresse = adresse;
            this.by = by;
            this.postNr = postNr;
        }

        public string CustomerName
        {
            get
            {
                return navn;
            }
        }

        public override string ToString()
        {
            string s = "";

            s = "Navn: ".PadRight(10) + navn +
                "\n" + 
                "Adresse: ".PadRight(10) + adresse +
                "\n" + 
                "Postnr: ".PadRight(10) + postNr +
                "\n" + 
                "By: ".PadRight(10) + by;

            return s;
        }
    }
}
