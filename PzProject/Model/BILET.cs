//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PzProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BILET
    {
        public int Id_bilet { get; set; }
        public Nullable<byte> Potwierdzenie { get; set; }
        public Nullable<byte> Realizacja { get; set; }
        public int Id_seans { get; set; }
        public Nullable<int> Id_ulga { get; set; }
    
        public virtual SEANS SEANS { get; set; }
        public virtual ULGA ULGA { get; set; }
    }
}