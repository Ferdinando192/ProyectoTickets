﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTickets
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_a7cc1a_ticketsdbEntities1 : DbContext
    {
        public db_a7cc1a_ticketsdbEntities1()
            : base("name=db_a7cc1a_ticketsdbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CANAL_ORIGEN> CANAL_ORIGEN { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<ESTADO> ESTADO { get; set; }
        public virtual DbSet<INCIDENTE> INCIDENTE { get; set; }
        public virtual DbSet<PRIORIDAD> PRIORIDAD { get; set; }
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTO { get; set; }
    }
}
