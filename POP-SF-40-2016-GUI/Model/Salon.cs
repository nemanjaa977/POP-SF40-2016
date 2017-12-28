using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_40_2016.Model
{
    public class Salon
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string AdresaInternetSajta { get; set; }
        public int PIB { get; set; }
        public int MaticniBroj { get; set; }
        public string BrojZiroRacuna { get; set; }

        public static ObservableCollection<Salon> GetAllSalon()
        {
            var listaSalona = new ObservableCollection<Salon>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Salon WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Salon");

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    var s = new Salon();
                    s.Id = int.Parse(row["Id"].ToString());
                    s.Naziv = row["Naziv"].ToString();
                    s.Adresa = row["Adresa"].ToString();
                    s.Telefon = row["Telefon"].ToString();
                    s.Email = row["Email"].ToString();
                    s.AdresaInternetSajta = row["AdresaInternetSajta"].ToString();
                    s.PIB = Convert.ToInt32(row["Pib"]);
                    s.MaticniBroj = Convert.ToInt32(row["MaticniBroj"]);
                    s.BrojZiroRacuna = row["BrojZiroRacuna"].ToString();
                    s.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    listaSalona.Add(s);
                }
            }
            return listaSalona;
        }
    }
}
