﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ii303075Entities : DbContext
    {
        public ii303075Entities()
            : base("name=ii303075Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BILET> BILET { get; set; }
        public DbSet<FILM> FILM { get; set; }
        public DbSet<GATUNEK> GATUNEK { get; set; }
        public DbSet<MIEJSCE> MIEJSCE { get; set; }
        public DbSet<SALA> SALA { get; set; }
        public DbSet<SEANS> SEANS { get; set; }
        public DbSet<ULGA> ULGA { get; set; }
    }
}
