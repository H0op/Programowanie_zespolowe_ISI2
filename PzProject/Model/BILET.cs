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
    
    public partial class BILET
    {
        public int id_bilet { get; set; }
        public Nullable<bool> potwierdzenie { get; set; }
        public Nullable<bool> realizacja { get; set; }
        public int id_seans { get; set; }
        public int id_film { get; set; }
        public int id_gatunek { get; set; }
        public int id_sala { get; set; }
        public int id_ulga { get; set; }
    
        public virtual ULGA ULGA { get; set; }
        public virtual SEANS SEANS { get; set; }
    }
}