using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerskiDeo
{
    public partial class FrmServer : Form
    {
        private BindingList<Korisnik> korisnici = new BindingList<Korisnik>(Kontroler.Instanca.VratiKorisnike());
        private BindingList<Poruka> poruke = new BindingList<Poruka>(Kontroler.Instanca.VratiPoruke());
        private Server server;
        public FrmServer()
        {
            InitializeComponent();
            dgvKorisnici.DataSource = korisnici;
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Server();
                server.Start();
                Thread nit = new Thread(server.ObradaKlijenata);
                nit.Start();
                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
                MessageBox.Show("Server je pokrenut");
                dgvPoruke.DataSource = poruke;
                dgvPoruke.Columns["Operacija"].Visible = false;
                dgvPoruke.Columns["Uspesno"].Visible = false;
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            server?.Close();
            server = null;
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            MessageBox.Show("Server je stopiran");
            dgvPoruke.DataSource = null;
            dgvPoruke.DataSource = Kontroler.Instanca.VratiPoruke();
            dgvPoruke.Columns["Operacija"].Visible = false;
            dgvPoruke.Columns["Uspesno"].Visible = false;
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
