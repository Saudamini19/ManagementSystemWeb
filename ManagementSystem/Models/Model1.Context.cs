﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ManagementSystemEntities : DbContext
    {
        public ManagementSystemEntities()
            : base("name=ManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminDetail> AdminDetails { get; set; }
        public virtual DbSet<AssociateDetail> AssociateDetails { get; set; }
        public virtual DbSet<BatchDetail> BatchDetails { get; set; }
        public virtual DbSet<TrainerDetail> TrainerDetails { get; set; }
        public virtual DbSet<TrainingModule> TrainingModules { get; set; }
        public virtual DbSet<AllDetail> AllDetails { get; set; }
    }
}
