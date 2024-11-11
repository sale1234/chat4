using Biblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class Server
    {
        private Socket serverSoket;
        private List<ClientHandler> clients = new List<ClientHandler>();
        private List<Korisnik> korisnici = Kontroler.Instanca.VratiKorisnike();
        internal void Start()
        {
            if (serverSoket == null)
            {
                serverSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000));
                serverSoket.Listen(5);
            }
        }

        internal void ObradaKlijenata()
        {
            try
            {
                while(true)
                {
                    Socket klijentSoket = serverSoket.Accept();
                    ClientHandler handler = new ClientHandler(klijentSoket, clients, korisnici);
                    handler.OdjavljeniKlijent += Handler_OdjavljeniKlijent;
                    clients.Add(handler);
                    Thread nit = new Thread(handler.ObradaZahteva);
                    nit.Start();
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Handler_OdjavljeniKlijent(object sender, EventArgs e)
        {
            clients.Remove((ClientHandler)sender);
        }

        internal void Close()
        {
            serverSoket?.Close();
            serverSoket = null;
            foreach (var klijent in clients.ToList())
            {
                klijent.CloseSoket();
            }
        }
    }
}
