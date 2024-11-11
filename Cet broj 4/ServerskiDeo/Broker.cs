using Biblioteka;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class Broker
    {
        private SqlConnection connection;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Djes;Integrated Security=True;");
            
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            if(connection != null && connection.State != System.Data.ConnectionState.Closed)
            connection.Close();
        }

        internal List<Korisnik> VratiKorisnike()
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandText = "select * from korisnik";
            List<Korisnik> lista = new List<Korisnik>();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Korisnik korisnik = new Korisnik
                {
                    Email = reader.GetString(0),
                    Sifra = reader.GetString(1),
                    Ime = reader.GetString(2),
                    Prezime = reader.GetString(3)
                };
                lista.Add(korisnik);
            }
            reader.Close();
            return lista;
        }

        internal List<Poruka> VratiPoruke()
        {
            SqlCommand command = new SqlCommand("", connection);

            command.CommandText = "select * from Poruka p join Korisnik po on (p.posiljalac = po.email) join Korisnik pr on (p.primalac = pr.email)";
            List<Poruka> lista = new List<Poruka>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Poruka poruka = new Poruka
                {
                    Tekst = reader.GetString(1),
                    Vreme = reader.GetString(4),
                    Posiljalac = new Korisnik
                    {
                        Email = reader.GetString(5),
                        Sifra = reader.GetString(6),
                        Ime = reader.GetString(7),
                        Prezime = reader.GetString(8),
                    },
                    Primalac = new Korisnik
                    {
                        Email = reader.GetString(9),
                        Sifra = reader.GetString(10),
                        Ime = reader.GetString(11),
                        Prezime = reader.GetString(12),
                    }
                };
                lista.Add(poruka);
            }
            reader.Close();
            return lista;
        }

        internal void DodajPoruku(Poruka poruka)
        {
            SqlCommand command = new SqlCommand("", connection);

            command.CommandText = "insert into poruka values (@tekst, @posiljalac, @primalac, @vreme)";
            command.Parameters.AddWithValue("@tekst", poruka.Tekst);
            command.Parameters.AddWithValue("@posiljalac", poruka.Posiljalac.Email);
            command.Parameters.AddWithValue("@primalac", poruka.Primalac.Email);
            command.Parameters.AddWithValue("@vreme", poruka.Vreme);
        }
    }
}
