using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace ProiectDelegatii.Models
{
    public class Delegatie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Tara { get; set; }
        public string Localitate { get; set; }
        public string Adresa { get; set; }
        public DateTime Data_Plecare { get; set; }
        public DateTime Data_Intoarcere { get; set; }
        public DateTime Data { get; set; }
        public String Documete { get; set; }
    }
}
