﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace kp
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class TourCompanyEntities1 : DbContext
{
        private static TourCompanyEntities1 _context;

    public TourCompanyEntities1()
        : base("name=TourCompanyEntities1")
    {

    }
            
        public static TourCompanyEntities1 GetContext()
        {
            if (_context == null)
                _context = new TourCompanyEntities1();
            return _context;
        }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TravelPackage> TravelPackages { get; set; }

    public virtual DbSet<Сountries> Сountries { get; set; }

    public virtual DbSet<User> Users { get; set; }

}

}
