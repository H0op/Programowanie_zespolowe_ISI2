//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PzProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class FILM
    {
        public FILM()
        {
            this.SEANS = new HashSet<SEANS>();
        }
    
        public int id_film { get; set; }
        public string tytul { get; set; }
        public Nullable<int> czas_trwania { get; set; }
        public Nullable<short> rok_produkcji { get; set; }
        public string opis { get; set; }
        public string scenariusz { get; set; }
        public string rezyser { get; set; }
        public string kategoria_wiekowa { get; set; }
        public string obsada { get; set; }
        public string produkcja { get; set; }
        public string zdjecie { get; set; }
        public string zwiastun { get; set; }
        public Nullable<System.DateTime> data_konca { get; set; }
        public int id_gatunek { get; set; }
    
        public virtual GATUNEK GATUNEK { get; set; }
        public virtual ICollection<SEANS> SEANS { get; set; }
    }
}