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
    
    public partial class GATUNEK
    {
        public GATUNEK()
        {
            this.FILM = new HashSet<FILM>();
        }
    
        public int id_gatunek { get; set; }
        public string nazwa { get; set; }
    
        public virtual ICollection<FILM> FILM { get; set; }
    }
}
