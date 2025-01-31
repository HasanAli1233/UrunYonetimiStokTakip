﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //veritabanı değişiklikleriin otomatik uygula
            AutomaticMigrationDataLossAllowed = false; //olası veritabanı kayıplarını kabul etme ayarı
            ContextKey = "DAL.DatabaseContext";
        }

        protected override void Seed(DAL.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
