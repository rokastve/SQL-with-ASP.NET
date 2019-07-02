using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalDB
{
    public class Klase
    {
        public string Pavadinimas { get; set; }
        public string Tipas { get; set; }
        public string Potipis { get; set; }
    }
    public class Gyvunas
    {
        public string vardas { get; set; }
        public DateTime gimimo_data { get; set; }
        public int lytis_id { get; set; }
        public long savininko_kodas { get; set; }
        public int fk_Isvaizda_id { get; set; }
        public string fk_veisle { get; set; }
        public DateTime fk_vet_viz { get; set; }
        public int fk_micro_id { get; set; }
        public int fk_reg_id { get; set; }
    }
    public class Adresas
    {
        public int id_adresas { get; set; }
        public string gatve { get; set; }
        public int buto_nr { get; set; }
        public string rajonas { get; set; }
        public string pasto_kodas { get; set; }
        public int fk_miestas { get; set; }
    }
    public class Gresme
    {
        public int id { get; set; }
        public string pavadinimas { get; set; }
    }
    public class Isvaizda
    {
        public int id { get; set; }
        public double svoris { get; set; }
        public string spalva { get; set; }
        public string danga { get; set; }
        public double aukstis { get; set; }
    }
    public class Liga
    {
        public int id { get; set; }
        public string pavadinimas { get; set; }
        public int gresme_id { get; set; }
    }
    public class Lytis
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Miestas
    {
        public int id { get; set; }
        public string salis { get; set; }
        public int populiacija { get; set; }
        public string pavadinimas { get; set; }
        public int zemynas_id { get; set; }
    }
    public class Mikro
    {
        public string pavadinimas { get; set; }
        public int numeris { get; set; }
        public string gamintojas { get; set; }
        public DateTime data { get; set; }
    }
    public class Registracija
    {
        public int numeris { get; set; }
        public DateTime data { get; set; }
        public string vieta { get; set; }
        public long savininko_id { get; set; }
        public int veterinaras_id { get; set; }
    }
    public class Savininkas
    {
        public long id { get; set; }
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public int numeris { get; set; }
        public string email { get; set; }
        public DateTime gimimo_data { get; set; }
        public int lytis { get; set; }
        public int adresas_id { get; set; }
    }
    public class Veisle
    {
        public string kilmes_salis { get; set; }
        public int gyvenimo_trukme { get; set; }
        public string pavadinimas { get; set; }
        public string klases_pavadinimas { get; set; }
    }
    public class Veterinaras
    {
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public int tel_nr { get; set; }
        public string email { get; set; }
        public int kodas { get; set; }
        public int lytis_id { get; set; }
    }
    public class Zemynas
    {
        public int id { get; set; }
        public string pavadinimas { get; set; }
    }
    public class Sveikata
    {
        public DateTime Vizito_data { get; set; }
        public DateTime Skiepijymo_Data { get; set; }
        public int skiepu_galiojimas { get; set; }
        public int veterinaro_id { get; set; }
        public int liga_id { get; set; }
    }
    public class PA1c
    {
        public string Vardas { get; set; }
        public DateTime Gimimo_Data { get; set; }
        public int Mikroschemos_Numeris { get; set; }
        public DateTime Idejimo_Data { get; set; }
    }
    public class PA2c
    {
        public string Vardas { get; set; }
        public DateTime Gimimo_Data { get; set; }
        public int Registracijos_Numeris { get; set; }
        public string Registracijos_Vieta { get; set; }
        public DateTime Registracijos_Data { get; set; }
    }
    public class AA1c
    {
        public string Veisle { get; set; }
        public double VidSvoris { get; set; }
        public double MaxAukstis { get; set; }
    }
}