using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazi5
{
    class Program
    {
        class Elem<T>
        {
            public Elem<T> elozo;
            public T tartalom;
            public Elem<T> kovetkezo;

            public Elem(Elem<T> elozo, T tartalom, Elem<T> kovetkezo)
            {
                this.elozo = elozo;
                this.tartalom = tartalom;
                this.kovetkezo = kovetkezo;
            }

            public Elem()
            {
                this.elozo = this;
                this.kovetkezo = this;
            }

            public Elem(Elem<T> kijelolt, T tartalom)
            {
                this.tartalom = tartalom;
                Elem<T> uj = this;
                uj.elozo = kijelolt;
                uj.kovetkezo = kijelolt.kovetkezo;
                kijelolt.kovetkezo.elozo = uj;
                kijelolt.kovetkezo = uj;
            }

            public void Delete()
            {
                this.kovetkezo.elozo = this.elozo;
                this.elozo.kovetkezo = this.kovetkezo;
            }
        }

        class Kalap<T>
        {
            public void Push(T elem)
            {
                new Elem<T>(fejelem.elozo, elem);
                Count++;
            }

            public T Pop()
            {
                Random r = new Random();
                int random = r.Next(Count);

                int i = 0;
                Elem<T> aktelem = fejelem.kovetkezo;
                while (i < random)
                {
                    i++;
                    aktelem = aktelem.kovetkezo;
                }

                T ertek = aktelem.tartalom;
                aktelem.Delete();
                Count--;

                return ertek;
            }

            public T Peek()
            {
                Random r = new Random();
                int random = r.Next(Count);

                int i = 0;
                Elem<T> aktelem = fejelem.kovetkezo;
                while (i < random)
                {
                    i++;
                    aktelem = aktelem.kovetkezo;
                }

                T ertek = aktelem.tartalom;

                return ertek;
            }

            public bool Empty()
            {
                return Count == 0;
            }

            public int Count;
            Elem<T> fejelem;

            public Kalap()
            {
                Count = 0;
                fejelem = new Elem<T>();
            }
        }
        static void Main(string[] args)
        {
            Kalap<int> kalap = new Kalap<int>();
            kalap.Push(1);
            kalap.Push(6);
            kalap.Push(2);
            kalap.Push(5);
            kalap.Push(9);
            kalap.Push(2);
            kalap.Push(4);

            Console.WriteLine(kalap.Pop());
            Console.WriteLine(kalap.Peek());
            Console.WriteLine(kalap.Empty());
            Console.WriteLine(kalap.Count);
        }
    }
}