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
    
    public partial class SALA
    {
        public SALA()
        {
            this.MIEJSCE = new HashSet<MIEJSCE>();
            this.SEANS = new HashSet<SEANS>();
        }
    
        public int id_sala { get; set; }
        public Nullable<int> ilosc_miejsc { get; set; }
    
        public virtual ICollection<MIEJSCE> MIEJSCE { get; set; }
        public virtual ICollection<SEANS> SEANS { get; set; }
    }
}