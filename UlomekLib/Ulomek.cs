using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UlomekLib
{
    public class Ulomek
    {
        private int st, im;
        private static int stUlomkov;

        public int Stevec
        {
            get { return st; }
            set { st = value; }
        }
        public int Imenovalec
        {
            get { return im; }
            set
            {
                if (value == 0) im = 1;
                else im = value;
            }
        }
        public Ulomek()
        {
            st = 1;
            im = 1;
            stUlomkov++;
        }

        public Ulomek(int st, int im)
        {
            this.st = st;
            if (im == 0) this.im = 1;
            else this.im = im;
            stUlomkov++;
        }

        public Ulomek(Ulomek other)
        {
            this.st = other.st;
            this.im = other.im;
            stUlomkov++;
        }
        ~Ulomek()
        {
            stUlomkov--;
        }

        public override string ToString()
        {
            return st + "/" + im;
        }

        public void Izpisi()
        {
            if (im == 1 || st == 0)
            {
                Console.WriteLine("{0}", st);
                return;
            }
            Console.WriteLine("{0}/{1}", st, im);
        }

        public void Okrajsaj()
        {
            int deljitelj = NajvecjiDeljitelj(this.st, this.im);
            this.st = st / deljitelj;
            this.im = im / deljitelj;
        }

        public int NajvecjiDeljitelj(int a, int b)
        {
            if (b == 0) return a;
            return NajvecjiDeljitelj(b, a % b);
        }

        public static int SteviloUlomkov()
        {
            return stUlomkov;
        }

        public static Ulomek operator ++(Ulomek u)
        {
            return new Ulomek(u.st + u.im, u.im);
        }
        public static Ulomek operator --(Ulomek u)
        {
            return new Ulomek(u.st - u.im, u.im);
        }
        public static Ulomek operator +(Ulomek u1, Ulomek u2)
        {
            return new Ulomek(u1.st * u2.im + u2.st * u1.im, u1.im * u2.im);
        }
        public static Ulomek operator -(Ulomek u1, Ulomek u2)
        {
            return new Ulomek(u1.st * u2.im - u2.st * u1.im, u1.im * u2.im);
        }
        public static Ulomek operator -(Ulomek u)
        {
            return new Ulomek(-u.st, u.im);
        }
        public static Ulomek operator *(Ulomek u1, Ulomek u2)
        {
            return new Ulomek(u1.st * u2.st, u1.im * u2.im);
        }
        public static Ulomek operator /(Ulomek u1, Ulomek u2)
        {
            return new Ulomek(u1.st * u2.im, u1.im * u2.st);
        }
        public static bool operator ==(Ulomek u1, Ulomek u2)
        {
            return (u1.st * u2.im == u2.st * u1.im);
        }
        public static bool operator !=(Ulomek u1, Ulomek u2)
        {
            return !(u1 == u2);
        }
        public static bool operator <(Ulomek u1, Ulomek u2)
        {
            return (u1.st * u2.im < u2.st * u1.im);
        }
        public static bool operator >(Ulomek u1, Ulomek u2)
        {
            return (u1.st * u2.im > u2.st * u1.im);
        }
        public static bool operator <=(Ulomek u1, Ulomek u2)
        {
            return (u1 < u2 || u1 == u2);
        }
        public static bool operator >=(Ulomek u1, Ulomek u2)
        {
            return (u1 > u2 || u1 == u2);
        }

        public static implicit operator Ulomek(int x)
        {
            return new Ulomek(x, 1);
        }

        public static implicit operator float(Ulomek u)
        {
            return (float)u.st / u.im;
        }

        public static implicit operator Ulomek(float x)
        {
            int im = 10000;
            int st = (int)(x * im);
            Ulomek u = new Ulomek(st, im);
            u.Okrajsaj();
            return u;
        }

        public static explicit operator int(Ulomek u)
        {
            return u.st / u.im;
        }
    }
}