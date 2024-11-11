using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class FrmKlijent : Form
    {
        private List<Poruka> poruke = new List<Poruka>();
        public FrmKlijent()
        {
            InitializeComponent();
            gbLogin.Visible = true;
            gbSlanjeSvima.Visible = false;
            gbSlanjeOdredjenom.Visible = false;
            try
            {
                Komunikacija.Instanca.Connect();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Poruka poruka = new Poruka
            {
                Posiljalac = new Korisnik
                {
                    Email = txtEmail.Text,
                    Sifra = txtSifra.Text
                },
                Operacija = Operacija.Login
            };
            Komunikacija.Instanca.SaljiPoruku(poruka);
            Poruka odgovor = Komunikacija.Instanca.CitajPoruku();
            if(odgovor.Uspesno)
            {
                MessageBox.Show($"Dobrodosli {odgovor.Primalac.Ime} {odgovor.Primalac.Prezime}");
                gbLogin.Visible = false;
                gbSlanjeSvima.Visible = true;
                gbSlanjeOdredjenom.Visible = true;
                SlusajPoruke();
            }
            else
            {
                MessageBox.Show("Neuspesna prijava na sistem, probajte ponovo");
            }
        }

        private void SlusajPoruke()
        {
            Thread nit = new Thread(ObradaPoruka);
            nit.Start();
        }

        private void ObradaPoruka()
        {
            try
            {
                while(true)
                {
                    Poruka odgovor = Komunikacija.Instanca.CitajPoruku();
                    switch (odgovor.Operacija)
                    {
                        case Operacija.Login:
                            Invoke(new Action(() =>
                            {
                                cbKorisnici.DataSource = odgovor.UlogovaniKorisnici;
                                if (odgovor.Poruke.Count > 0) poruke = odgovor.Poruke;
                                dgvPoruke.DataSource = poruke;
                                dgvPoruke.Columns["Operacija"].Visible = false;
                                dgvPoruke.Columns["Uspesno"].Visible = false;
                            }));
                            break;
                        case Operacija.SaljiSvima:
                            Invoke(new Action(() =>
                            {
                                poruke.Add(odgovor);
                                dgvPoruke.DataSource = null;
                                dgvPoruke.DataSource = poruke;
                                dgvPoruke.Refresh();
                                dgvPoruke.Columns["Operacija"].Visible = false;
                                dgvPoruke.Columns["Uspesno"].Visible = false;
                            }));
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (SerializationException)
            {
                MessageBox.Show("Doslo je do prekida komunikacije sa serverom");
                Environment.Exit(0);
            }
        }

        private void btnSaljiSvima_Click(object sender, EventArgs e)
        {
            Poruka poruka = new Poruka
            {
                Tekst = rtbSlanjeSvima.Text,
                Primalac = new Korisnik
                {
                    Email = "svi",
                    Ime = "svi",
                    Prezime = "svi",
                    Sifra = "svi",
                },
                Vreme = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                Operacija = Operacija.SaljiSvima
            };
            Komunikacija.Instanca.SaljiPoruku(poruka);
        }

        private void btnSaljiOdredjenom_Click(object sender, EventArgs e)
        {
            Poruka poruka = new Poruka
            {
                Tekst = rtbSlanjeOdredjenom.Text,
                Primalac = (Korisnik)cbKorisnici.SelectedItem,
                Vreme = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                Operacija = Operacija.SaljiSvima
            };
            Komunikacija.Instanca.SaljiPoruku(poruka);
        }
    }
}
