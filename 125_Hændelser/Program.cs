using System;

namespace _125_Hændelser
{
    class Program
    {
        static void Main(string[] args)
        {
            Terning t = new Terning();
            t.ErSekser += (s, e) =>
            {
                Console.WriteLine("SEKSER!!!!");
                Console.Beep();
            };

            for (int i = 0; i < 10; i++)
            {
                t.Ryst();
                t.Skriv();
            }

        }
    }

    public class Terning
    {
        private System.Random rnd = new Random();
        public event EventHandler ErSekser;

        public int Værdi { get; private set; }

        public Terning()
        {
            this.Ryst();
        }

        public void Ryst()
        {
            this.Værdi = rnd.Next(1, 7);
            if (this.Værdi == 6)
            {
                ErSekser?.Invoke(this, new EventArgs());
            }
        }

        public void Skriv()
        {
            Console.WriteLine($"[{this.Værdi}]");
        }
    }
}