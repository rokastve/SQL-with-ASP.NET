using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AnimalDB
{
    public class Kontekstas
    {
        public string ConnectionString { get; set; }

        public Kontekstas(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        #region Klasė
        public List<Klase> GetKlase()
        {
            List<Klase> klases = new List<Klase>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `klase`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Klase klase = new Klase();
                klase.Pavadinimas = reader[0].ToString();
                klase.Tipas = reader[1].ToString();
                klase.Potipis = reader[2].ToString();
                klases.Add(klase);
            }
            conn.Close();
            return klases;
        }

        public void EditKlase(string Pavadinimas, string Tipas, string Potipis)
        {
            if(Pavadinimas == ""||Tipas == "" || Potipis == "")
            {
                throw new Exception("neivesti visi langeliai");
            }
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE `klase` SET tipas='" + Tipas + "', potipis ='" +Potipis +"' WHERE pavadinimas='" + Pavadinimas + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveKlase(string Pavadinimas)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `veisle` WHERE fk_Klasepavadinimas='"+Pavadinimas+"';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk > 0)
            {
                throw new Exception("Negalima panaikinti klases kol yra ja turinciu veisiu");
            }
            cmd.CommandText = "DELETE FROM `klase` WHERE pavadinimas='" + Pavadinimas + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddKlase(string Pavadinimas, string tipas, string potipis)
        {
            if (Pavadinimas == "" || tipas == "" | potipis == "")
            {
                throw new Exception("Nenurodyti visi laukai");
            }
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `klase` WHERE pavadinimas ='" + Pavadinimas + "';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if(sk>0)
            {
                throw new Exception("Toks elementas jau yra");
            }
            cmd.CommandText = "INSERT INTO `klase` (pavadinimas, tipas, potipis) VALUES ('" + Pavadinimas + "','"+ tipas+"','"+potipis + "');";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
        #region Gyvūnai
        public List<Gyvunas> GetGyvunas()
        {
            List<Gyvunas> Gyvunai = new List<Gyvunas>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `gyvunas`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Gyvunas gyvunas = new Gyvunas();
                gyvunas.vardas = reader[0].ToString();
                gyvunas.gimimo_data = Convert.ToDateTime(reader[1]).Date;
                gyvunas.lytis_id = Convert.ToInt32(reader[2]);
                gyvunas.savininko_kodas = Convert.ToInt64(reader[3]);
                gyvunas.fk_Isvaizda_id = Convert.ToInt32(reader[4]);
                gyvunas.fk_veisle = reader[5].ToString();
                gyvunas.fk_vet_viz = Convert.ToDateTime(reader[6]).Date;
                gyvunas.fk_micro_id = Convert.ToInt32(reader[7]);
                gyvunas.fk_reg_id = Convert.ToInt32(reader[8]);

                Gyvunai.Add(gyvunas);
            }
            conn.Close();
            return Gyvunai;
        }

        public void EditGyvunas(string Vardas, DateTime data, int lytis_id, long savininkas_id, int isvaizda_id, string veisle,
            DateTime vet_vid, int micro_id, int reg_id)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE `gyvunas` SET lytis='" + lytis_id + "', fk_Savininkasasmens_kodas ='" + savininkas_id + "'" +
                ", fk_Isvaizdaid_Isvaizda ='" + isvaizda_id + "', fk_Veislepavadinimas='"+veisle+"'" +
                ", fk_Sveikatos_buklevizito_pas_veterinara_data='"+vet_vid+"', fk_Mikroschema_numeris='"+micro_id+"'," +
                "	fk_Registracija_numeris='"+reg_id+"'  WHERE vardas='" + Vardas + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveGyvunas(string Vardas, DateTime gimimo_data)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "DELETE FROM `gyvunas` WHERE vardas='" + Vardas + "' AND gimimo_data='"+gimimo_data+"';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddGyvunas(string Vardas, DateTime data, int lytis_id, long savininkas_id, int isvaizda_id, string veisle,
            DateTime vet_vid, int micro_id, int reg_id)
        {
            if (Vardas == "" || data == null|| veisle == "")
            {
                throw new Exception("Nenurodyti visi laukai");
            }

            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `gyvunas` WHERE vardas ='" + Vardas + "' AND gimimo_data='"+data+"';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk > 0)
            {
                throw new Exception("Toks elementas jau yra");
            }
            cmd.CommandText = "INSERT INTO `gyvunas` (vardas, gimimo_data, lytis,fk_Savininkasasmens_kodas," +
                "fk_Isvaizdaid_Isvaizda, fk_Veislepavadinimas, 	fk_Sveikatos_buklevizito_pas_veterinara_data," +
                "	fk_Mikroschema_numeris, fk_Registracija_numeris) VALUES ('" + Vardas + "','" + data + "','" + lytis_id + "','" + savininkas_id + "','" + isvaizda_id + "','" + veisle + "','" + vet_vid + "','" + micro_id + "','" + reg_id + "');";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
        #region Lytys
        public List<Lytis> GetLytis()
        {
            List<Lytis> Lytys = new List<Lytis>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `lytys`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Lytis lytis = new Lytis();
                lytis.id = Convert.ToInt32(reader[0]);
                lytis.name = reader[1].ToString();
                Lytys.Add(lytis);
            }
            conn.Close();
            return Lytys;
        }
        #endregion
        #region Savininkai
        public List<Savininkas> GetSavininkas()
        {
            List<Savininkas> Savininkai = new List<Savininkas>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `savininkas`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Savininkas savininkas = new Savininkas();
                savininkas.id = Convert.ToInt64(reader[0]);
                savininkas.vardas = reader[1].ToString();
                savininkas.pavarde = reader[2].ToString();
                savininkas.numeris = Convert.ToInt32(reader[3]);
                savininkas.email = reader[4].ToString();
                savininkas.gimimo_data = Convert.ToDateTime(reader[5]);
                savininkas.lytis = Convert.ToInt32(reader[6]);
                savininkas.adresas_id = Convert.ToInt32(reader[7]);
        Savininkai.Add(savininkas);
            }
            conn.Close();
            return Savininkai;
        }

        public void EditSavininkas(long id, string vardas, string pavarde, int numeris,
            string email, DateTime data, int lytis, int adresas)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE `savininkas` SET vardas='" + vardas + "', pavarde ='" + pavarde + "'" +
                ", telefono_numeris ='" + numeris + "', elektroninis_pastas='" + email + "'" +
                ", gimimo_data='" + data + "', lytis='" + lytis + "'," +
                " fk_Adresasid_Adresas='" + adresas + "'  WHERE asmens_kodas=" + id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveSavininkas(long id)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `gyvunas` WHERE fk_Savininkasasmens_kodas='" + id + "';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk > 0)
            {
                throw new Exception("Negalima panaikinti savininko kol yra ji turinciu gyvunu");
            }
            cmd.CommandText = "SELECT COUNT(*) FROM `registracija` WHERE fk_Savininkasasmens_kodas='" + id + "';";
            int sk2 = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk2 > 0)
            {
                throw new Exception("Negalima panaikinti savininko kol yra ji turinciu registraciju");
            }
            cmd.CommandText = "DELETE FROM `savininkas` WHERE asmens_kodas='" + id + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddSavininkas(long id, string vardas, string pavarde, int numeris,
            string email, DateTime data, int lytis, int adresas)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `savininkas` WHERE asmens_kodas ='" + id + "';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk > 0)
            {
                throw new Exception("Toks elementas jau yra");
            }
            cmd.CommandText = "INSERT INTO `savininkas` (asmens_kodas, vardas, pavarde, telefono_numeris," +
                "elektroninis_pastas, gimimo_data, lytis, fk_Adresasid_Adresas) VALUES ('" + id + "','" + vardas + "','" + pavarde + "','" + numeris + "','" + email + "','" + data + "','" + lytis + "','" + adresas + "');";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
        #region Isvaizda
        public List<Isvaizda> GetIsvaizda()
        {
            List<Isvaizda> Isvaizdos = new List<Isvaizda>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `isvaizda`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Isvaizda isvaizda = new Isvaizda();
                isvaizda.svoris = Convert.ToDouble(reader[0]);
                isvaizda.spalva = reader[1].ToString();
                isvaizda.danga = reader[2].ToString();
                isvaizda.aukstis = Convert.ToDouble(reader[3]);
                isvaizda.id = Convert.ToInt32(reader[4]);
                Isvaizdos.Add(isvaizda);
            }
            conn.Close();
            return Isvaizdos;
        }

        public void EditIsvaizda(double svoris, string spalva, string danga, double aukstis, int id)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE `isvaizda` SET svoris='" + svoris + "', spalva ='" + spalva + "'" +
                ", Kuno_danga ='" + danga + "', aukstis='" + aukstis+ "' WHERE id_Isvaizda=" + id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveIsvaizda(int id)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM `isvaizda` WHERE id_Isvaizda='" + id + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddIsvaizda(double svoris, string spalva, string danga, double aukstis, int id)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `isvaizda` WHERE id_Isvaizda ='" + id + "';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk > 0)
            {
                throw new Exception("Toks elementas jau yra");
            }
            cmd.CommandText = "INSERT INTO `isvaizda` (svoris, spalva, kuno_danga, aukstis, id_Isvaizda) " +
                "VALUES ('" + svoris + "','" + spalva + "','" + danga + "','" + aukstis + "','" + id + "');";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
        #region Mikroschema
        public List<Mikro> GetMikro()
        {
            List<Mikro> Mikroschemos = new List<Mikro>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `mikroschema`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Mikro mikroschema = new Mikro();
                mikroschema.pavadinimas = reader[0].ToString();
                mikroschema.numeris = Convert.ToInt32(reader[1]);
                mikroschema.gamintojas = reader[2].ToString();
                mikroschema.data = Convert.ToDateTime(reader[3]);
                Mikroschemos.Add(mikroschema);
            }
            conn.Close();
            return Mikroschemos;
        }
        #endregion
        #region Registracija
        public List<Registracija> GetRegistracija()
        {
            List<Registracija> Registracijos = new List<Registracija>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `registracija`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Registracija registracija = new Registracija();
                registracija.numeris = Convert.ToInt32(reader[0]);
                registracija.data = Convert.ToDateTime(reader[1]);
                registracija.vieta = reader[2].ToString();
                registracija.savininko_id = Convert.ToInt64(reader[3]);
                registracija.veterinaras_id = Convert.ToInt32(reader[4]);
                Registracijos.Add(registracija);
            }
            conn.Close();
            return Registracijos;
        }

        public void EditRegistracija(int numeris, DateTime data, string vieta, long sav_id, int vet_id)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE `registracija` SET data='" + data + "', vieta ='" + vieta + "'" +
                ", fk_Savininkasasmens_kodas ='" + sav_id + "', fk_Veterinarasasmens_kodas='" + vet_id + "' WHERE numeris=" + numeris + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveRegistracija(int id)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `gyvunas` WHERE fk_Registracija_numeris='" + id + "';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk > 0)
            {
                throw new Exception("Negalima panaikinti registracijos dar yra ji turinciu gyvunu");
            }
            cmd.CommandText = "DELETE FROM `registracija` WHERE numeris='" + id + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddRegistracija(int numeris, DateTime data, string vieta, long sav_id, int vet_id)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `registracija` WHERE numeris ='" + numeris + "';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk > 0)
            {
                throw new Exception("Toks elementas jau yra");
            }
            cmd.CommandText = "INSERT INTO `registracija` (numeris, data, vieta, fk_Savininkasasmens_kodas, fk_Veterinarasasmens_kodas) " +
                "VALUES ('" + numeris + "','" + data + "','" + vieta + "','" + sav_id + "','" + vet_id + "');";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
        #region Sveikata
        public List<Sveikata> GetSveikata()
        {
            List<Sveikata> sveikatos = new List<Sveikata>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `sveikatos_bukle`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sveikata sveikata = new Sveikata();
                sveikata.Vizito_data = Convert.ToDateTime(reader[0]).Date;
                sveikata.Skiepijymo_Data = Convert.ToDateTime(reader[1]).Date;
                sveikata.skiepu_galiojimas = Convert.ToInt32(reader[2]);
                sveikata.liga_id = Convert.ToInt32(reader[3]);
                sveikatos.Add(sveikata);
            }
            conn.Close();
            return sveikatos;
        }

        public void RemoveSveikata(DateTime data)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM `sveikatos_bukle` WHERE vizito_pas_veterinara_data='" + data + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
        #region Veisle
        public List<Veisle> GetVeisle()
        {
            List<Veisle> veisles = new List<Veisle>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `veisle`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Veisle veisle = new Veisle();
                veisle.kilmes_salis = reader[0].ToString();
                veisle.gyvenimo_trukme = Convert.ToInt32(reader[1]);
                veisle.pavadinimas = reader[2].ToString();
                veisle.klases_pavadinimas = reader[3].ToString();
                veisles.Add(veisle);
            }
            conn.Close();
            return veisles;
        }

        public void EditVeisle(string kilmes_salis, int gyv_trukme, string pavadinimas, string klase)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE `veisle` SET kilmes_salis='" + kilmes_salis + "', gyvenimo_trukme ='" + gyv_trukme + "'" +
                ", fk_Klasepavadinimas ='" + klase + "' WHERE pavadinimas='" + pavadinimas + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveVeisle(string Pavadinimas)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM `veisle` WHERE pavadinimas='" + Pavadinimas + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddVeisle(string kilmes_salis, int gyv_trukme, string pavadinimas, string klase)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM `veisle` WHERE pavadinimas ='" + pavadinimas + "';";
            int sk = Convert.ToInt32(cmd.ExecuteScalar());
            if (sk > 0)
            {
                throw new Exception("Toks elementas jau yra");
            }
            cmd.CommandText = "INSERT INTO `veisle` (kilmes_salis, gyvenimo_trukme, pavadinimas, fk_Klasepavadinimas) " +
                "VALUES ('" + kilmes_salis + "','" + gyv_trukme + "','" + pavadinimas + "','" + klase + "');";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
        #region adresas
        public List<Adresas> GetAdresas()
        {
            List<Adresas> Adresai = new List<Adresas>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `adresas`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Adresas adresas = new Adresas();
                adresas.gatve = reader[0].ToString();
                adresas.buto_nr = Convert.ToInt32(reader[1]);
                adresas.rajonas = reader[2].ToString();
                adresas.pasto_kodas = reader[3].ToString();
                adresas.fk_miestas = Convert.ToInt32(reader[4]);
                adresas.id_adresas = Convert.ToInt32(reader[5]);

                Adresai.Add(adresas);
            }
            conn.Close();
            return Adresai;
        }
        #endregion
        #region veterinaras
        public List<Veterinaras> GetVeterinaras()
        {
            List<Veterinaras> Veterinarai = new List<Veterinaras>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `veterinaras`;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Veterinaras veterinaras = new Veterinaras();
                veterinaras.vardas = reader[0].ToString();
                veterinaras.pavarde = reader[1].ToString();
                veterinaras.tel_nr = Convert.ToInt32(reader[2]);
                veterinaras.email = reader[3].ToString();
                veterinaras.kodas = Convert.ToInt32(reader[4]);
                veterinaras.lytis_id = Convert.ToInt32(reader[5]);
                Veterinarai.Add(veterinaras);
            }
            conn.Close();
            return Veterinarai;
        }
        #endregion
        #region PA1
        public List<PA1c> GetAnimalsIn2018()
        {
            List<PA1c> Animals = new List<PA1c>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT gyvunas.vardas, gyvunas.gimimo_data, gyvunas.fk_Mikroschema_numeris, mikroschema.idejimo_data  FROM gyvunas INNER JOIN mikroschema ON gyvunas.fk_Mikroschema_numeris = mikroschema.numeris WHERE mikroschema.idejimo_data >= '2018-01-01';", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PA1c data = new PA1c();
                data.Vardas = reader[0].ToString();
                data.Gimimo_Data = Convert.ToDateTime(reader[1]);
                data.Mikroschemos_Numeris = Convert.ToInt32(reader[2]);
                data.Idejimo_Data = Convert.ToDateTime(reader[3]);
                Animals.Add(data);
            }
            conn.Close();
            return Animals;
        }
        #endregion
        #region PA2
        public List<PA2c> GetAnimalsInPlace(string vieta, DateTime from, DateTime to)
        {
            if(vieta == "")
            {
                throw new Exception("Nenurodytas vietos pavadinimas");
            }
            List<PA2c> Animals = new List<PA2c>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT gyvunas.vardas, gyvunas.gimimo_data, gyvunas.fk_Registracija_numeris, registracija.vieta, registracija.data FROM `gyvunas` INNER JOIN registracija ON gyvunas.fk_Registracija_numeris = registracija.numeris WHERE registracija.vieta = '" + vieta + "'AND registracija.data >= '"+from+"' AND registracija.data <= '"+ to + "';", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PA2c data = new PA2c();
                data.Vardas = reader[0].ToString();
                data.Gimimo_Data = Convert.ToDateTime(reader[1]);
                data.Registracijos_Numeris = Convert.ToInt32(reader[2]);
                data.Registracijos_Vieta = reader[3].ToString();
                data.Registracijos_Data = Convert.ToDateTime(reader[4]);
                Animals.Add(data);
            }
            conn.Close();
            if (Animals.Count == 0)
                throw new Exception("Tuščias sąrašas su nurodytais parametrais");
            return Animals;
        }
        #endregion
        #region aa1
        public List<AA1c> GetAA1()
        {
            List<AA1c> Animals = new List<AA1c>();
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT gyvunas.fk_Veislepavadinimas, AVG(isvaizda.svoris) AS VID_Svoris, MAX(isvaizda.aukstis) as max_aukstis FROM `gyvunas` INNER JOIN isvaizda ON gyvunas.fk_Isvaizdaid_Isvaizda = isvaizda.id_Isvaizda GROUP BY fk_Veislepavadinimas", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AA1c data = new AA1c();
                data.Veisle = reader[0].ToString();
                data.VidSvoris = Convert.ToDouble(reader[1]);
                data.MaxAukstis = Convert.ToDouble(reader[2]);              
                Animals.Add(data);
            }
            conn.Close();
            return Animals;
        }
        #endregion
    }
}