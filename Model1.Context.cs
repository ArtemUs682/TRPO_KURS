﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TRPO_KURSEntities : DbContext
    {
        public TRPO_KURSEntities()
            : base("name=TRPO_KURSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<RequestTypes> RequestTypes { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Specialties> Specialties { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
    }
}
