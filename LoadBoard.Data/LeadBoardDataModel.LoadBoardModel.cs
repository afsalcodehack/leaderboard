﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 09-06-2020 1.54.39 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;
using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace LoadBoard_Data
{

    public partial class LoadBoardModel : DbContext
    {

        public LoadBoardModel() :
            base()
        {
            OnCreated();
        }

        public LoadBoardModel(DbContextOptions<LoadBoardModel> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                var a = GetConnectionString("LoadBoardModelConnectionString");
                optionsBuilder.UseSqlServer(GetConnectionString("LoadBoardModelConnectionString"));
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        private static string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<Game> Games
        {
            get;
            set;
        }

        public virtual DbSet<Score> Scores
        {
            get;
            set;
        }

        public virtual DbSet<User> Users
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.GameMapping(modelBuilder);
            this.CustomizeGameMapping(modelBuilder);

            this.ScoreMapping(modelBuilder);
            this.CustomizeScoreMapping(modelBuilder);

            this.UserMapping(modelBuilder);
            this.CustomizeUserMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region Game Mapping

        private void GameMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable(@"Game", @"dbo");
            modelBuilder.Entity<Game>().Property<int>(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Game>().Property<string>(x => x.GameName).HasColumnName(@"GameName").HasColumnType(@"varchar(250)").ValueGeneratedNever().HasMaxLength(250);
            modelBuilder.Entity<Game>().HasKey(@"Id");
        }

        partial void CustomizeGameMapping(ModelBuilder modelBuilder);

        #endregion

        #region Score Mapping

        private void ScoreMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>().ToTable(@"Score", @"dbo");
            modelBuilder.Entity<Score>().Property<int>(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Score>().Property<int?>(x => x.GameId).HasColumnName(@"GameId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<Score>().Property<int?>(x => x.UserId).HasColumnName(@"UserId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<Score>().Property<double?>(x => x.Score1).HasColumnName(@"Score").HasColumnType(@"float").ValueGeneratedNever();
            modelBuilder.Entity<Score>().Property<System.DateTime?>(x => x.Date).HasColumnName(@"Date").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<Score>().HasKey(@"Id");
        }

        partial void CustomizeScoreMapping(ModelBuilder modelBuilder);

        #endregion

        #region User Mapping

        private void UserMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(@"Users", @"dbo");
            modelBuilder.Entity<User>().Property<int>(x => x.UserId).HasColumnName(@"UserId").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property<string>(x => x.UserName).HasColumnName(@"UserName").HasColumnType(@"varchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<User>().HasKey(@"UserId");
        }

        partial void CustomizeUserMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
