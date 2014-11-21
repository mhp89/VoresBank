using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uge47BankCustumer
{
    class Program
    {
        static BankDataCentral voresBank = new BankDataCentral();
        static void Main(string[] args)
        {
            voresBank.OpretKunder(5);

            Console.WriteLine("Kunder:");

            for (int i = 0; i < voresBank.kunder.Length; i++)
            {
                Console.WriteLine(voresBank.kunder[i].ToString() + " - " + voresBank.kreditkorts[i]);
            }
            Console.WriteLine();

            Console.Write("Indtast kortnr: ");
            int kortnr = Convert.ToInt32(Console.ReadLine());
            KreditKort kort = voresBank.FindKreditKort(kortnr);

            Pengeautomat atm = new Pengeautomat(voresBank);
            bool resultat;// = atm.InsaetKort(kort);

            if (atm.InsaetKort(kort))
            {
                byte forsoegTilbage = 3;
                Console.Write("Indtast pinkode: ");
                do
                {
                    int pinkode = Convert.ToInt32(Console.ReadLine());
                    resultat = atm.ValiderPinkode(pinkode);
                    forsoegTilbage--;
                    if (!resultat && forsoegTilbage > 0)
                    {
                        Console.Write("Forkert pinkode, {0} forsøg tilbage: ",forsoegTilbage);
                    }
                } while (!resultat && forsoegTilbage > 0);

                if (!resultat)
                {
                    Console.WriteLine("\nDu har tastet forkert 3 gange, nu tager vi dit kort.");
                }               
                else
                {
                    Console.Write("Hvor mange penge vil du hæve?: ");
                    int beloeb = Convert.ToInt32(Console.ReadLine());
                    Pengeautomat.SaldoFejl fejl = atm.ValiderSaldo(beloeb);
                    
                    if (fejl == Pengeautomat.SaldoFejl.IngenFejl)
                    {
                        Console.Write("Ønskes kvitering? J/N: ");
                        ConsoleKeyInfo cki = Console.ReadKey(true);;
                        if (cki.Key == ConsoleKey.J)
                        {
                            atm.PrintKvittering(beloeb);
                        }
                        Console.WriteLine();
                        atm.HaevPenge(beloeb);
                        atm.UdleverKort();
                        atm.UdleverPenge(beloeb);
                    }
                    else if (fejl == Pengeautomat.SaldoFejl.UgyldigtBeloeb)
                    {
                        Console.WriteLine("Ugyldigt beløb");
                        atm.UdleverKort();
                    }
                    else
                    {
                        Console.WriteLine("Der er ikke dækning på kontoen!");
                        atm.UdleverKort();
                    }

                }

            }
            

            Console.WriteLine();
            
            //Console.WriteLine(b.Balance);
            //Console.WriteLine(b.Interest);
            Console.ReadKey();
        }
    }
}
