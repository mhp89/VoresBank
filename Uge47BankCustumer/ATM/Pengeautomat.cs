using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uge47BankCustumer
{
    class Pengeautomat
    {
        BankDataCentral voresBank;
        KreditKort aktivKreditkort;
        BankAccount aktivKonto;
        private int automatNr;
        public enum SaldoFejl
        {
            IngenFejl,
            UgyldigtBeloeb,
            IngenDaekning
        }

        public Pengeautomat(BankDataCentral voresBank)
        {
            this.voresBank = voresBank;
            automatNr = new Random().Next(100,999);
        }
        public bool InsaetKort(KreditKort kort)
        {
            aktivKreditkort = kort;
            aktivKonto = voresBank.FindKonto(aktivKreditkort.KontoNr);
            return ValiderKort();
        }
        public bool ValiderKort()
        {
            return !aktivKreditkort.stjaalet;
        }
        public bool ValiderPinkode(int pinkode)
        {
            return (pinkode == aktivKreditkort.PinKodeHash);
        }

        public SaldoFejl ValiderSaldo(int beloeb)
        {
            if (beloeb < 0)
	        {
		        return SaldoFejl.UgyldigtBeloeb;
	        }
            else if (aktivKonto.Saldo < beloeb)
	        {
		        return SaldoFejl.IngenDaekning;
	        }
            return SaldoFejl.IngenFejl;
        }

        public void PrintKvittering(int beloeb)
        {
            Console.WriteLine("\n");
            Console.WriteLine("----------Kvittering----------");
            Console.WriteLine("- Dato: " + DateTime.Now.ToString().PadRight(21) + "-");
            Console.WriteLine("- Automatnummer: " + automatNr.ToString().PadRight(12) + "-");
            Console.WriteLine("------------------------------");
            Console.WriteLine("- Kontonummer: " + aktivKonto.KontoNr.ToString().PadRight(14) + "-");
            Console.WriteLine("- Kortnummer: " + aktivKreditkort.KortNr.ToString().PadRight(15) + "-");
            Console.WriteLine("------------------------------");
            Console.WriteLine("- Beløb hævet: " + beloeb.ToString("C").PadRight(14) + "-");
            Console.WriteLine("- Ny saldo: " + (aktivKonto.Saldo - beloeb).ToString("C").PadRight(17) + "-");
            Console.WriteLine("------------------------------");
        }

        public void UdleverKort()
        {
            aktivKreditkort = null;
            aktivKonto = null;
            Console.WriteLine("Kort skubbet ud");
        }

        public void HaevPenge(int beloeb)
        {
            aktivKonto.HaevPenge(beloeb);
        }
        public void UdleverPenge(int beloeb)
        {
            Console.WriteLine("{0:c} er udleveret", beloeb); 
        }
    }
    
}
