using System;
using System.Collections.Generic;

namespace Test5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Chain ch = new Chain(10, 5);
            Console.WriteLine(ch.beads[0]);
            ch.Len = 20;
            Console.WriteLine(ch.beads[0]);
            ch.NN = 20;
            Console.WriteLine(ch.beads[0]);
            Console.ReadKey();
        }
    }
    class Bead
    {
        double r;
        public double R
        {
            get { return r; }
            set { r = value; }
        }
        public Bead(double r)
        {
            if (r <= 0) throw new ArgumentOutOfRangeException();
            this.r = r;
        }
        public void OnChainLenChangedHandler(double rad)
        {
            R = rad;
        }
        public override string ToString()
        {
            return string.Format("[Bead]" + r);
        }
    }

    class Chain
    {
        public delegate void ChainLenChangedDel(double rad);
        public event ChainLenChangedDel ChainLenChanged;
        protected virtual void OnChainLenChanged(double rad)
        {
            if (ChainLenChanged != null)
                ChainLenChanged(rad);
        }
        public List<Bead> beads;
        double N;
        double len;
        public double NN
        {
            get
            {
                return N;
            }
            set
            {
                N = value;
                OnChainLenChanged(len / N);
            }
        }
        public double Len
        {
            get
            {
                return len;
            }
            set
            {
                len = value;
                OnChainLenChanged(len / N);
            }
        }
        public Chain(double len, int N)
        {
            this.N = N;
            Len = len;
            CreateBeads();
        }
        void CreateBeads()
        {
            beads = new List<Bead>();
            double r = len / N;
            for (int i = 0; i < N; i++)
            {
                Bead b = new Bead(r);
                ChainLenChanged += b.OnChainLenChangedHandler;
                beads.Add(b);
            }
        }
    }
}