namespace SuperDealership.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SuperDealership.Models;
    using SuperDealership.DAL;
    using System.IO;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperDealership.DAL.AutoDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperDealership.DAL.AutoDBContext context)
        {
            string txt = @"C:\Users\Ashley\Documents\Visual Studio 2013\Projects\SuperDealership-1\CarList.txt";
            List<string> CarInfoList = new List<string>();

            using (StreamReader readerOfCSV = new StreamReader(txt))
            {
                string carLine;

                while ((carLine = readerOfCSV.ReadLine()) != null)
                {
                    CarInfoList.Add(carLine);
                }
            }

            foreach (var line in CarInfoList)
            {
                string [] carArray = line.Split(',');

                string userid = carArray[0];
                string vin = carArray[1];
                string type = carArray[2];
                string make = carArray[3];
                string model = carArray[4];
                string year = carArray[5];
                string mpgLow = carArray[6];
                string mpgHigh = carArray[7];
                string color = carArray[8];
                string msrp = carArray[9];
                string mileage = carArray[10];
                string img = carArray[11];
                 
                context.Vehicle.AddOrUpdate(i => i.VIN,
                    new Auto
                    {
                        VIN = Int32.Parse(vin),
                        Type = type,
                        Make = make,
                        Model = model,
                        Year = Int32.Parse(year),
                        MPGLow = Int32.Parse(mpgLow),
                        MPGHigh = Int32.Parse(mpgHigh),
                        Color = color,
                        MSRP = Double.Parse(msrp),
                        Mileage = Double.Parse(mileage),
                        CarImg = img,
                        IsOwned = false
                    }
                );
            }
        }
    }
}
