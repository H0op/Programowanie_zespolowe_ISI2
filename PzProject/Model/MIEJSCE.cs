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
    
    public partial class MIEJSCE
    {
        public int Id_miejsce { get; set; }
        public Nullable<int> Rzad { get; set; }
        public Nullable<int> Miejsce1 { get; set; }
        public Nullable<byte> Zajete { get; set; }
        public int Id_sala { get; set; }
    
        public virtual SALA SALA { get; set; }
    }
}