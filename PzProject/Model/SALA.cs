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
    
    public partial class SALA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALA()
        {
            this.MIEJSCE = new HashSet<MIEJSCE>();
            this.SEANS = new HashSet<SEANS>();
        }
    
        public int Id_sala { get; set; }
        public Nullable<int> Ilosc_kolumn { get; set; }
        public Nullable<int> Ilosc_wierszy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIEJSCE> MIEJSCE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEANS> SEANS { get; set; }
    }
}
