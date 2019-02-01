using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Demo.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Gehalt { get; set; }
    }
}