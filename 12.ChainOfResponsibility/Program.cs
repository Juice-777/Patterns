using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Receiver
    {
        public bool BankTransfer { get; set; }
        public bool MoneyTransfer { get; set; }
        public bool PayPalTransfer { get; set; }

        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }

    abstract class PaymantHandler
    {
        public PaymantHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver);
    }
}
