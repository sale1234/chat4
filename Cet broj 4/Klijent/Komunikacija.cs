using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instanca;

        private Komunikacija()
        {

        }

        public static Komunikacija Instanca
        {
            get
            {
                if (instanca == null) instanca = new Komunikacija();
                return instanca;
            }
        }

        private Socket soket;
        private CommunicationHelper helper;
        internal void Connect()
        {
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soket.Connect("127.0.0.1", 9000);
            helper = new CommunicationHelper(soket);
        }

        public void SaljiPoruku(Poruka poruka)
        {
            helper.SaljiPoruku(poruka);
        }

        public Poruka CitajPoruku()
        {
            return helper.CitajPoruku<Poruka>();
        }
    }
}
