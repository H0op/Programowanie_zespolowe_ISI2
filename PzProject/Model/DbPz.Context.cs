﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabasePZEntities : DbContext
    {
        public DatabasePZEntities()
            : base("name=DatabasePZEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BILET> BILET { get; set; }
        public virtual DbSet<SALA> SALA { get; set; }
        public virtual DbSet<SEANS> SEANS { get; set; }
        public virtual DbSet<ULGA> ULGA { get; set; }
        public virtual DbSet<GODZINY> GODZINY { get; set; }
        public virtual DbSet<UZYTKOWNICY> UZYTKOWNICY { get; set; }
    }
}
