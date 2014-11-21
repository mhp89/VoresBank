using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uge47BankCustumer
{
    class BankAccount
    {
        private int kontoNr;
        private double saldo;
        private double renteSats;
        private double renteBeloeb;

        public BankAccount(int kontoNr, double startSaldo, double renteSats)
        {
            this.kontoNr = kontoNr;
            this.saldo = startSaldo;
            this.renteSats = renteSats;
        }

        public void IndsaetPenge(double beloeb)
        {
            saldo += beloeb;
        }

        public void HaevPenge(double beloeb)
        {
            saldo -= beloeb;
        }

        public void TilfoejRenteBeloeb()
        {
            renteBeloeb = saldo * (renteSats / 100);
            saldo += renteBeloeb;
        }

        public int KontoNr
        {
            get
            {
                return kontoNr;
            }
        }
        public double Saldo
        {
            get
            {
                return saldo;
            }
        }

        public double RenteBeloeb
        {
            get
            {
                return renteBeloeb;
            }
        }

        public override string ToString()
        {
            return "Kontonr: " + KontoNr + " Saldo: " + Saldo.ToString().PadRight(6);
        }
        
    }
}
