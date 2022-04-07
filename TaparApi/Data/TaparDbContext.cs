﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Extensions;
using TaparApi.Data.Common;

namespace TaparApi.Data
{
    public class TaparDbContext : DbContext
    {
        public TaparDbContext(DbContextOptions<TaparDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //in khat behtar hast aval az hame farakhani beshe

            var entitiesAssembly =
                typeof(IEntity)
                    .Assembly; //peyda kardane dll marbut be laye Entities(be jaye IEntity mitavanim har class dge az laye Entities estefade konim)

            modelBuilder
                .RegisterAllEntities<
                    IEntity>(entitiesAssembly); //dynamic kardane modelhaye proje(dge lazem nist bara har model dbset<> tarif konim)
            modelBuilder
                .AddRestrictDeleteBehaviorConvention(); //agar amalyate delete ru database emal beshe in taabe baaes mishe avval child haye parent delete beshan baad parent delete beshe ejaze nemidahad ke aval parent delete beshe
            modelBuilder.AddPluralizingTableNameConvention();

        }
        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }
    }
}

