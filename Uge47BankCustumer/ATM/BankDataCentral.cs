using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uge47BankCustumer
{
    class BankDataCentral
    {
        public BankCustomer[] kunder;
        public KreditKort[] kreditkorts;

        public KreditKort FindKreditKort(int kortnr)
        {
            for (int i = 0; i < kreditkorts.Length; i++)
            {
                if (kortnr == kreditkorts[i].KortNr)
                {
                    return kreditkorts[i];
                }
            }

            return null;
        }
        public bool ValiderKort(KreditKort kort)
        {
            if (kort.KortNr > 0)
            {
                
            }
            return false;
        }

        public BankAccount FindKonto(int kontoNr)
        {
            for (int i = 0; i < kunder.Length; i++)
            {
                if (kontoNr == kunder[i].nemKonto.KontoNr)
                {
                    return kunder[i].nemKonto;
                }
                if (kontoNr == kunder[i].opsparing.KontoNr)
                {
                    return kunder[i].opsparing;
                }
            }
            return null;
        }

        #region kunder

        public void OpretKunder(int antalKunder)
        {
            kunder = new BankCustomer[antalKunder];
            kreditkorts = new KreditKort[antalKunder];
            Random rnd = new Random();

            for (int i = 0; i < antalKunder; i++)
            {
                PersonalInfo p = new PersonalInfo(RandomFornavn(rnd) + " " + RandomEfternavn(rnd), "Vejlevej 1", "Vejle", 7100);
                BankAccount nemKonto = new BankAccount(1000 + i,rnd.Next(-10000,50000),0);
                BankAccount opsparingsKonto = new BankAccount(2000 + i,rnd.Next(100,1000000),0);
                KreditKort dankort = new KreditKort(3000+i,rnd,nemKonto.KontoNr);
                kunder[i] = new BankCustomer(10000+i,p, nemKonto, opsparingsKonto);
                kreditkorts[i] = dankort;
            }

        }
        public static string RandomFornavn(Random rnd)
        {
            string[] fornavne = { "Jonas", 
                                  "Mikkel", 
                                  "Mario",
                                  "Gorm", 
                                  "Stefan", 
                                  "André", 
                                  "Jeppe", 
                                  "Camilla", 
                                  "Patrick", 
                                  "Emil", 
                                  "Mads", 
                                  "Jamie", 
                                  "Jesper", 
                                  "Rune", 
                                  "Maja", 
                                  "Mathias", 
                                  "Carsten", 
                                  "Faraj", 
                                  "John", 
                                  "Dennis", 
                                  "Sido", 
                                  "René", 
                                  "Daniel", 
                                  "Marie" };
            string fornavn = fornavne[rnd.Next(0, fornavne.Length)];
            return fornavn;
        }
        public static string RandomEfternavn(Random rnd)
        {
            string[] efternavne = { "Bock", 
                                    "Christensen", 
                                    "Frederiksen", 
                                    "Garczewski", 
                                    "Hansen", 
                                    "Hasfeldt", 
                                    "Jefferson", 
                                    "Jensen", 
                                    "Jeppesen", 
                                    "Korsgaard", 
                                    "Laugesen", 
                                    "Lykkegård", 
                                    "Mathiasen", 
                                    "Murphy", 
                                    "Nielsen", 
                                    "Olesen", 
                                    "Olsen", 
                                    "Pedersen", 
                                    "Petersen", 
                                    "Poulsen", 
                                    "Rieper", 
                                    "Saied", 
                                    "Schubert", 
                                    "Schulskis", 
                                    "Shymon", 
                                    "Sørensen", 
                                    "Tamborra", 
                                    "Veigert" };
            string efternavn = efternavne[rnd.Next(0, efternavne.Length)];
            return efternavn;
        }
        #endregion
    }
}
