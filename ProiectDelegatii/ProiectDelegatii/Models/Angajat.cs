using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectDelegatii.Models
{
    public class Angajat
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Manager { get; set; }
        public string Filiala { get; set; }
        [OneToMany]
        public List<ListAngajat> ListAngajati { get; set; }
    }
}
