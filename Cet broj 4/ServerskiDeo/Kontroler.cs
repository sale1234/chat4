using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class Kontroler
    {
        private static Kontroler instanca;

        private Kontroler()
        {

        }

        public static Kontroler Instanca 
        { 
            get
            {
                if (instanca == null) instanca = new Kontroler();
                return instanca;
            }
        }

        private Broker broker = new Broker();

        internal List<Korisnik> VratiKorisnike()
        {
            try
            {
                broker.OpenConnection();
                return broker.VratiKorisnike();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        private List<Korisnik> ulogovaniKorisnici = new List<Korisnik>();
        internal void DodajUlogovane(Korisnik ulogovaniKorisnik)
        {
            ulogovaniKorisnici.Add(ulogovaniKorisnik);
        }

        internal List<Korisnik> VratiUlogovane()
        {
            return ulogovaniKorisnici;
        }

        private List<Poruka> poruke = new List<Poruka>();

        internal List<Poruka> VratiPoruke()
        {
            try
            {
                broker.OpenConnection();
                return broker.VratiPoruke();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        internal void DodajPoruku(Poruka poruka)
        {
            try
            {
                broker.OpenConnection();
                if (poruka.Tekst != null)
                {
                    broker.DodajPoruku(poruka);
                }
            }
            finally
            {
                broker.CloseConnection();
            }
            
        }
    }
}
