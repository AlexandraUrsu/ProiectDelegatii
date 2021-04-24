using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace ProiectDelegatii.Models
{
    public class Document
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Denumire { get; set; }
        public float Suma { get; set; }
        public string Cod { get; set; }
        [ForeignKey(typeof(Delegatie))]
        public int DelegatieID { get; set; }
        public Document() { }
        public Document(int DelegatieID)
        {
            this.DelegatieID = DelegatieID;
        }
    }
}