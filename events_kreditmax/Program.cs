﻿using System;

namespace events_kreditmax
{

    class Program

    {

        static void Main(string[] args)

        {

            Kunde k = new Kunde() { KreditMax = -500 };

            k.KreditOverskredet += (s, e) =>

            {

                Console.WriteLine("Kredit overskredet");

            };

            k.Køb(100);

            k.Køb(75);
            k.Køb(75);
            k.Køb(75);
            k.Køb(75);
            k.Køb(75);
            k.Køb(75);
            k.Køb(75);
            k.Køb(75);
            k.Køb(75);
            k.Køb(75);



            // Hold console åben ved debug (kun nødvendigt ved .NET Framework - ikke .NET Core)

            if (System.Diagnostics.Debugger.IsAttached)

            {

                Console.Write("Press any key to continue . . . ");

                Console.ReadKey();

            }

        }

    }





    public class Kunde

    {

        public event EventHandler KreditOverskredet;

        public string Navn { get; set; }

        public int Saldo { get; set; }

        public int KreditMax { get; set; }

        public void Køb(int værdi)

        {

            Console.WriteLine($"Kunde {Navn} køber for {værdi}");

            this.Saldo -= værdi;

            if (Saldo < KreditMax)

            {

                if (KreditOverskredet != null)

                    KreditOverskredet(this, new EventArgs());

            }

        }

    }

}