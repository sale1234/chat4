using Biblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class ClientHandler
    {
        private Socket klijentSoket;
        private List<ClientHandler> clients;
        private List<Korisnik> korisnici;
        private CommunicationHelper helper;

        public ClientHandler(Socket klijentSoket, List<ClientHandler> clients, List<Korisnik> korisnici)
        {
            this.klijentSoket = klijentSoket;
            this.clients = clients;
            this.korisnici = korisnici;
            helper = new CommunicationHelper(klijentSoket);
        }

        internal void ObradaZahteva()
        {
            try
            {
                while(!kraj)
                {
                    Poruka poruka = helper.CitajPoruku<Poruka>();
                    switch (poruka.Operacija)
                    {
                        case Operacija.Login:
                            Login(poruka);
                            break;
                        case Operacija.SaljiSvima:
                            SaljiSvima(poruka);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if(klijentSoket != null)
                {
                    CloseSoket();
                }
            }
        }

        public Korisnik UlogovaniKorisnik { get; set; }
        private void Login(Poruka poruka)
        {
            bool ulogovan = false;
            foreach (var korisnik in korisnici)
            {
                if(poruka.Posiljalac.Email == korisnik.Email && poruka.Posiljalac.Sifra == korisnik.Sifra)
                {
                    ulogovan = true;
                    UlogovaniKorisnik = korisnik;
                }
            }
            if(ulogovan)
            {
                korisnici.Remove(UlogovaniKorisnik);
                Kontroler.Instanca.DodajUlogovane(UlogovaniKorisnik);
                Poruka odgovor = new Poruka
                {
                    Uspesno = true,
                    Primalac = UlogovaniKorisnik
                };
                helper.SaljiPoruku(odgovor);
                Poruka zaSve = new Poruka
                {
                    UlogovaniKorisnici = Kontroler.Instanca.VratiUlogovane(),
                    Poruke = Kontroler.Instanca.VratiPoruke()
                };
                SaljiSvima(zaSve);
            }
            else
            {
                Poruka odgovor = new Poruka
                {
                    Uspesno = false
                };
                helper.SaljiPoruku(odgovor);
            }
        }

        private void SaljiSvima(Poruka poruka)
        {
            poruka.Posiljalac = UlogovaniKorisnik;
            Kontroler.Instanca.DodajPoruku(poruka);
            foreach (var klijent in clients)
            {
                if (klijent.UlogovaniKorisnik != null) klijent.helper.SaljiPoruku(poruka);
            }
        }


        private bool kraj = false;
        private object lockObject = new object();
        public EventHandler OdjavljeniKlijent;
        internal void CloseSoket()
        {
            try
            {
                lock(lockObject)
                {
                    if(klijentSoket != null)
                    {
                        kraj = true;
                        klijentSoket.Shutdown(SocketShutdown.Both);
                        klijentSoket.Close();
                        klijentSoket = null;
                        OdjavljeniKlijent?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (SerializationException ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
            }
        }
    }
}
