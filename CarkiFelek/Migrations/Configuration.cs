namespace CarkiFelek.Migrations
{
    using CarkiFelek.Model.DBObjects;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarkiFelek.Model.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarkiFelek.Model.DatabaseContext context)
        {
            Gift gift = new Gift();

            gift.GiftName = "250 MB Internet Paketi";
            gift.Possibility = 20;
            gift.CanGetPoint = true;
            context.Gifts.Add(gift);
            context.SaveChanges();

            gift.GiftName = "1 GB Internet Paketi";
            gift.Possibility = 5;
            gift.CanGetPoint = false;
            context.Gifts.Add(gift);
            context.SaveChanges();

            gift.GiftName = "Boyner 25 TL Hediye Çeki";
            gift.Possibility = 5;
            gift.CanGetPoint = false;
            context.Gifts.Add(gift);
            context.SaveChanges();

            gift.GiftName = "Koton 10 TL Hediye Çeki ";
            gift.Possibility = 10;
            gift.CanGetPoint = true;
            context.Gifts.Add(gift);
            context.SaveChanges();

            gift.GiftName = "Blu TV 1 Aylık Abonelik ";
            gift.Possibility = 5;
            gift.CanGetPoint = false;
            context.Gifts.Add(gift);
            context.SaveChanges();

            gift.GiftName = "10 TL Steam Cüzdan Kodu";
            gift.Possibility = 10;
            gift.CanGetPoint = true;
            context.Gifts.Add(gift);
            context.SaveChanges();

            gift.GiftName = "Karavana";
            gift.Possibility = 45;
            gift.CanGetPoint = true;
            context.Gifts.Add(gift);
            context.SaveChanges();


            Point point = new Point();
            point.PointScore = 75;
            point.Possibility = 5;
            context.Points.Add(point);
            context.SaveChanges();

            point.PointScore = 100;
            point.Possibility = 4;
            context.Points.Add(point);
            context.SaveChanges();

            point.PointScore = 500;
            point.Possibility = 1;
            context.Points.Add(point);
            context.SaveChanges();

            point.PointScore = 5;
            point.Possibility = 50;
            context.Points.Add(point);
            context.SaveChanges();

            point.PointScore = 0;
            point.Possibility = 40;
            context.Points.Add(point);
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
