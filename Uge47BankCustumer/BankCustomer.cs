using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uge47BankCustumer
{
    class BankCustomer
    {
        public int kundeNr;
        public PersonalInfo info;
        public BankAccount nemKonto
        { 
            get; 
            private set; 
        }
        public BankAccount opsparing
        { 
            get; 
            private set; 
        }

        public BankCustomer(int kundeNr,PersonalInfo info, BankAccount nemKonto, BankAccount opsparing)
        {
            this.kundeNr = kundeNr;
            this.info = info;
            this.nemKonto = nemKonto;
            this.opsparing = opsparing;
        }

        public override string ToString()
        {
            return info.CustomerName.PadRight(19) + " - " + nemKonto.ToString();
        }
    }
}
